namespace COMPANY.Infrastructure.PdfGenerateService
{
    using COMPANY.Application;
    using COMPANY.Application.Models.BusinessEntities.Documents.Facture;
    using COMPANY.Application.Models.GeneralModels.CalculationModels;
    using COMPANY.Application.Services.DataService.CalculationService;
    using COMPANY.Application.Services.PdfGenerateService;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;
    using COMPANY.Domain.Enums.General;
    using COMPANY.Infrastructure.Utilities;
    using Company.AutoInjection.Attributes;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Document = iTextSharp.text.Document;

    /// <summary>
    /// the implementation of IPdfGenerateService
    /// </summary>
    [Inject(typeof(IPdfGenerateService), ServiceLifetime.Singleton)]
    public class PdfGenerateService : IPdfGenerateService
    {
        // Service 
        private readonly ICalculationService _calculation;

        // images
        private readonly Image _logo = Image.GetInstance($@"{Directory.GetCurrentDirectory()}/Resources/Pictures/logo.png");

        // colors
        private static readonly BaseColor _fontPrimaryColor = new BaseColor(35, 31, 32);
        private static readonly BaseColor _fontSecondaryColor = new BaseColor(87, 88, 90, 1);
        private static readonly BaseColor _fontPrimaryColorTransparent = new BaseColor(209, 222, 235);
        private static readonly BaseColor _primaryColor = new BaseColor(27, 94, 156, 1);
        private static readonly BaseColor _secondaryColor = new BaseColor(255, 197, 39, 1);

        // fonts
        private readonly Font _font8 = PdfExtensions.GetFont(8, Font.NORMAL, _fontPrimaryColor);
        private readonly Font _font8Gray = PdfExtensions.GetFont(8, Font.NORMAL, BaseColor.Gray);
        private readonly Font _font8Bold = PdfExtensions.GetFont(8, Font.BOLD, _fontPrimaryColor);
        private readonly Font _font9 = PdfExtensions.GetFont(9, Font.NORMAL, _fontPrimaryColor);
        private readonly Font _font9White = PdfExtensions.GetFont(9, Font.NORMAL, BaseColor.White);
        private readonly Font _font9Bold = PdfExtensions.GetFont(9, Font.BOLD, _fontPrimaryColor);
        private readonly Font _font10Bold = PdfExtensions.GetFont(10, Font.BOLD, _fontPrimaryColor);
        private readonly Font _font12 = PdfExtensions.GetFont(12, Font.NORMAL, _fontPrimaryColor);
        private readonly Font _font24Secondary = PdfExtensions.GetFont(22, Font.NORMAL, _secondaryColor);

        public PdfGenerateService(ICalculationService calculation)
        {
            _calculation = calculation;
        }

        /// <summary>
        /// generation of devis PDF
        /// </summary>
        /// <param name="devis">a instance of devis entity</param>
        /// <returns>a array of byte</returns>
        public byte[] GenerateDevisPDF(Devis devis, DevisDocumentParameters parameters)
        {
            var isPrimeCEE = devis.DossierId.IsValid() && devis.Dossier.PrimeCEEId.IsValid() && devis.Type != DevisType.Normal;
            var primeCEELabel = isPrimeCEE ? devis.Dossier.PrimeCEE.LabelPrimeCEE : "";
            var primeCEENote = isPrimeCEE ? devis.Dossier.PrimeCEE.NoteDevis : "";
            var articlesTypeProduit = devis.Articles.Where(e => e.Type == ArticleType.Produit).ToList();
            var calculation = _calculation.CalculationGeneral(articlesTypeProduit, devis.Remise, RemiseType.Percent);
            var isRemise = devis.Remise > 0 ? true : false;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 30f, 30f, 35f, 100f);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                writer.PageEvent = new PdfFooter(_font8Gray, parameters.Footer.TransferHtmlToParagraph(), _secondaryColor);
                document.Open();
                document.Add(HeaderDocument(devis.Client, "DEVIS", $"Nº: {devis.Reference}", parameters.Header, (PdfPTable centerHeader) =>
                {
                    if (devis.UserId.IsValid())
                    {
                        var paragraphContact = new Paragraph() {
                            new Phrase("Contact ",_font8Bold),
                            new Phrase($"{devis.User.LastName} {devis.User.FirstName}",_font8)
                        };
                        centerHeader.AddCell(new PdfPCell(paragraphContact)
                        {
                            BorderWidth = 0,
                            BorderWidthBottom = 0.3f,
                            BorderColor = _fontSecondaryColor,
                            PaddingBottom = 4f
                        });
                    }

                    var paragraphDateVisit = new Paragraph() {
                        new Phrase("Date de viste préalable ",_font8Bold),
                        new Phrase($"{devis.DateVisit:dd/MM/yyyy}",_font8)
                    };
                    centerHeader.AddCell(new PdfPCell(paragraphDateVisit) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });

                    var addressChantier = devis?.SiteIntervention?.BuildAddressPhrase() ?? string.Empty;
                    var paragraphAddressChantier = new Paragraph() {
                        new Phrase($"Adresse du chantier {Environment.NewLine}",_font8Bold),
                        new Phrase(addressChantier,_font8)
                    };
                    centerHeader.AddCell(new PdfPCell(paragraphAddressChantier) { BorderWidth = 0 });
                }));
                document.Add(NoteTable(devis.Note));
                document.Add(ArticlesDocuments(devis.Articles.ToList()));
                document.Add(CalculationTable(calculation, devis.TotalReduction, devis.TotalPaid, isPrimeCEE, primeCEELabel, isRemise, devis.Remise, devis.RemiseType));
                document.Add(FooterDevisTable(primeCEENote, devis.TotalReduction, devis.Signe, devis.NameClientSignature));
                document.Close();

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// generate pdf of bon commande
        /// </summary>
        public byte[] GenerateBonComandePDF(BonCommande bonCommande, BonCommandeParameters parameters)
        {
            var isPrimeCEE = bonCommande.DossierId.IsValid() && bonCommande.Dossier.PrimeCEEId.IsValid() && bonCommande.Type != DevisType.Normal;
            var primeCEELabel = isPrimeCEE ? bonCommande.Dossier.PrimeCEE.LabelPrimeCEE : "";
            var primeCEENote = isPrimeCEE ? bonCommande.Dossier.PrimeCEE.NoteDevis : "";
            var articlesTypeProduit = bonCommande.Articles.Where(e => e.Type == ArticleType.Produit).ToList();
            var calculation = _calculation.CalculationGeneral(articlesTypeProduit, bonCommande.Remise, RemiseType.Percent);
            var isRemise = bonCommande.Remise > 0 ? true : false;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 30f, 30f, 35f, 100f);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                writer.PageEvent = new PdfFooter(_font8Gray, parameters.Footer.TransferHtmlToParagraph(), _secondaryColor);
                document.Open();
                document.Add(HeaderDocument(bonCommande.Client, "Bon Commande", $"Nº: {bonCommande.Reference}", parameters.Header, (PdfPTable centerHeader) =>
                {
                    if (bonCommande.UserId.IsValid())
                    {
                        var paragraphContact = new Paragraph() {
                            new Phrase("Contact ",_font8Bold),
                            new Phrase($"{bonCommande.User.LastName} {bonCommande.User.FirstName}",_font8)
                        };
                        centerHeader.AddCell(new PdfPCell(paragraphContact)
                        {
                            BorderWidth = 0,
                            BorderWidthBottom = 0.3f,
                            BorderColor = _fontSecondaryColor,
                            PaddingBottom = 4f
                        });
                    }

                    var paragraphDateVisit = new Paragraph() {
                        new Phrase("Date de viste préalable ",_font8Bold),
                        new Phrase($"{bonCommande.DateVisit:dd/MM/yyyy}",_font8)
                    };
                    centerHeader.AddCell(new PdfPCell(paragraphDateVisit) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });

                    var addressChantier = bonCommande?.SiteIntervention?.BuildAddressPhrase() ?? string.Empty;
                    var paragraphAddressChantier = new Paragraph() {
                        new Phrase($"Adresse du chantier {Environment.NewLine}",_font8Bold),
                        new Phrase(addressChantier,_font8)
                    };
                    centerHeader.AddCell(new PdfPCell(paragraphAddressChantier) { BorderWidth = 0 });
                }));
                document.Add(NoteTable(bonCommande.Note));
                document.Add(ArticlesDocuments(bonCommande.Articles.ToList()));
                document.Add(CalculationTable(calculation, bonCommande.TotalReduction, bonCommande.TotalPaid, isPrimeCEE, primeCEELabel, isRemise, bonCommande.Remise, bonCommande.RemiseType));
                document.Add(FooterDevisTable(primeCEENote, bonCommande.TotalReduction, bonCommande.Signe, bonCommande.NameClientSignature));
                document.Close();

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// generation of facture PDF
        /// </summary>
        /// <param name="facture">a instance of facture entity</param>
        /// <param name="parameters">facture parameters</param>
        /// <returns>a array of byte</returns>
        public byte[] GenerateFacturePDF(Facture facture, FactureDocumentParameters parameters)
        {
            var articlesTypeProduit = facture.Articles.Where(e => e.Type == ArticleType.Produit).ToList();
            var calculation = _calculation.CalculationGeneral(articlesTypeProduit, facture.Remise, RemiseType.Percent);
            var isRemise = facture.Remise > 0 ? true : false;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 30f, 30f, 35f, 100f);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                writer.PageEvent = new PdfFooter(_font8Gray, parameters.Footer.TransferHtmlToParagraph(), _secondaryColor);
                document.Open();
                if (facture.Type != FactureType.Classic)
                {
                    document.Add(HeaderDocument(facture.Client, $"Facture {facture.Type}", $"Nº: {facture.Reference}", parameters.Header, (PdfPTable centerHeader) =>
                    {
                        var paragraphDateCreation = new Paragraph() {
                        new Phrase("Date de création ",_font8Bold),
                        new Phrase($"{facture.DateCreation:dd/MM/yyyy}",_font8)
                    };
                        centerHeader.AddCell(new PdfPCell(paragraphDateCreation) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });

                        var paragraphEcheance = new Paragraph() {
                        new Phrase("Date d'écheance ",_font8Bold),
                        new Phrase($"{facture.DateEcheance:dd/MM/yyyy}",_font8)
                    };
                        centerHeader.AddCell(new PdfPCell(paragraphEcheance) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });

                        var paragraphRegulationMode = new Paragraph() {
                        new Phrase("Mode de réglement ",_font8Bold),
                        new Phrase($"{facture?.Client?.RegulationMode?.Name ?? string.Empty}",_font8)
                    };
                        centerHeader.AddCell(new PdfPCell(paragraphRegulationMode) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });

                        var paragraphObject = new Paragraph() {
                        new Phrase($"Objet {Environment.NewLine}",_font8Bold),
                        new Phrase(facture.Objet,_font8)
                    };
                        centerHeader.AddCell(new PdfPCell(paragraphObject) { BorderWidth = 0 });
                    }));
                }
                else
                {
                    document.Add(HeaderDocument(facture.Client, "Facture ", $"Nº: {facture.Reference}", parameters.Header, (PdfPTable centerHeader) =>
                    {
                        var paragraphDateCreation = new Paragraph() {
                        new Phrase("Date de création ",_font8Bold),
                        new Phrase($"{facture.DateCreation:dd/MM/yyyy}",_font8)
                    };
                        centerHeader.AddCell(new PdfPCell(paragraphDateCreation) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });

                        var paragraphEcheance = new Paragraph() {
                        new Phrase("Date d'écheance ",_font8Bold),
                        new Phrase($"{facture.DateEcheance:dd/MM/yyyy}",_font8)
                    };
                        centerHeader.AddCell(new PdfPCell(paragraphEcheance) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });

                        var paragraphRegulationMode = new Paragraph() {
                        new Phrase("Mode de réglement ",_font8Bold),
                        new Phrase($"{facture?.Client?.RegulationMode?.Name ?? string.Empty}",_font8)
                    };
                        centerHeader.AddCell(new PdfPCell(paragraphRegulationMode) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });

                        var paragraphObject = new Paragraph() {
                        new Phrase($"Objet {Environment.NewLine}",_font8Bold),
                        new Phrase(facture.Objet,_font8)
                    };
                        centerHeader.AddCell(new PdfPCell(paragraphObject) { BorderWidth = 0 });
                    }));
                }

                document.Add(NoteTable(facture.Note));
                if (facture.Type != FactureType.Acompte)
                {
                    document.Add(ArticlesDocuments(facture.Articles.ToList()));
                    document.Add(CalculationTable(calculation, 0, 0, false, string.Empty, isRemise, facture.Remise, facture.RemiseType));
                    if (facture.Type == FactureType.Cloture)
                    {
                        foreach (var fact in facture.Devis)
                        {
                            foreach (var factureDevis in fact.Devis.Factures)
                            {
                                if (factureDevis.Facture.Reference == facture.Reference)
                                    continue;
                                document.Add(FactureAcompteCloture(factureDevis));
                            }
                        }
                        document.Add(FactureCloture(facture));
                    }
                }
                else
                {
                    foreach (var fact in facture.Devis)
                    {
                        document.Add(TableTotalDevis(fact.Devis));
                    }
                    document.Add(TitleTable("Situation à facturer : "));
                    document.Add(FactureAcompte(facture.Articles.ToList()));
                }

                document.Add(FooterTable(facture.ReglementCondition));
                document.Close();
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// generation of facture PDF
        /// </summary>
        /// <param name="avoir">a instance of facture entity</param>
        /// <param name="parameters">facture parameters</param>
        /// <returns>a array of byte</returns>
        public byte[] GenerateAvoirPDF(Avoir avoir, AvoirDocumentParameters parameters)
        {
            var articlesTypeProduit = avoir.Articles.Where(e => e.Type == ArticleType.Produit).ToList();
            var calculation = _calculation.CalculationGeneral(articlesTypeProduit, avoir.Remise, RemiseType.Percent);
            var isRemise = avoir.Remise > 0 ? true : false;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 30f, 30f, 35f, 100f);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                writer.PageEvent = new PdfFooter(_font8Gray, parameters.Footer.TransferHtmlToParagraph(), _secondaryColor);
                document.Open();
                document.Add(HeaderDocument(avoir.Client, "Avoir", $"Nº: {avoir.Reference}", parameters.Header, (PdfPTable centerHeader) =>
                {
                    var paragraphDateCreation = new Paragraph() {
                        new Phrase("Date de création ",_font8Bold),
                        new Phrase($"{avoir.DateCreation:dd/MM/yyyy}",_font8)
                    };
                    centerHeader.AddCell(new PdfPCell(paragraphDateCreation) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });

                    var paragraphEcheance = new Paragraph() {
                        new Phrase("Date d'écheance ",_font8Bold),
                        new Phrase($"{avoir.DateEcheance:dd/MM/yyyy}",_font8)
                    };
                    centerHeader.AddCell(new PdfPCell(paragraphEcheance) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });

                    var paragraphRegulationMode = new Paragraph() {
                        new Phrase("Mode de réglement ",_font8Bold),
                        new Phrase($"{avoir?.Client?.RegulationMode?.Name ?? string.Empty}",_font8)
                    };
                    centerHeader.AddCell(new PdfPCell(paragraphRegulationMode) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });

                    var paragraphObject = new Paragraph() {
                        new Phrase($"Objet {Environment.NewLine}",_font8Bold),
                        new Phrase(avoir.Objet,_font8)
                    };
                    centerHeader.AddCell(new PdfPCell(paragraphObject) { BorderWidth = 0 });
                }));
                document.Add(NoteTable(avoir.Note));
                document.Add(ArticlesDocuments(avoir.Articles.ToList()));
                document.Add(CalculationTable(calculation, 0, 0, false, string.Empty, isRemise, avoir.Remise, avoir.RemiseType));
                document.Add(FooterTable(avoir.ReglementCondition));
                document.Close();
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// generate pdf releve factures
        /// </summary>
        /// <param name="client"></param>
        /// <param name="factures"></param>
        /// <param name="parameters"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public byte[] GenerateReleveFacturesPDF(Client client, List<ReleveFactureItemExport> factures, FactureDocumentParameters parameters, DateTime dateFrom, DateTime dateTo)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 30f, 30f, 35f, 100f);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                writer.PageEvent = new PdfFooter(_font8Gray, parameters.Footer.TransferHtmlToParagraph(), _secondaryColor);
                document.Open();
                document.Add(HeaderDocument(client, "Relevé des Factures", $"Du {dateFrom:dd/MM/yyyy} à {dateTo:dd/MM/yyyy}", parameters.Header, (PdfPTable centerHeader) =>
                {
                    var paragraphRegulationMode = new Paragraph() {
                        new Phrase("Mode de réglement ",_font8Bold),
                        new Phrase($"{client.RegulationMode?.Name ?? string.Empty}",_font8)
                    };
                    centerHeader.AddCell(new PdfPCell(paragraphRegulationMode) { BorderWidth = 0, BorderWidthBottom = 0.3f, BorderColor = _fontSecondaryColor, PaddingBottom = 4f });
                }));
                document.Add(BodyReleveFacturesTable(factures));
                document.Add(FooterTable(parameters.RegulationCondition));
                document.Close();
                return memoryStream.ToArray();
            }
        }


        #region revelve factures

        /// <summary>
        /// the body of releve of factures
        /// </summary>
        /// <param name="factures">the list of factures</param>
        /// <returns>a instance pdf table</returns>
        private PdfPTable BodyReleveFacturesTable(List<ReleveFactureItemExport> factures)
        {
            #region articles table

            PdfPTable articlesTable = new PdfPTable(4) { WidthPercentage = 100 };
            articlesTable.DefaultCell.Border = Rectangle.NO_BORDER;

            // Header table
            articlesTable.AddCell(TableHeaderElement("Date création", Element.ALIGN_LEFT));
            articlesTable.AddCell(TableHeaderElement("Référence interne", Element.ALIGN_LEFT));
            articlesTable.AddCell(TableHeaderElement("Montant (€)", Element.ALIGN_CENTER));
            articlesTable.AddCell(TableHeaderElement("Reste à payer (€)", Element.ALIGN_RIGHT));

            foreach (var facture in factures)
            {

                articlesTable.AddCell(TableBodyElement(facture.DateCreation.ToString("dd/MM/yyyy"), Element.ALIGN_LEFT));
                articlesTable.AddCell(TableBodyElement(facture.Reference, Element.ALIGN_LEFT));
                articlesTable.AddCell(TableBodyElement($"{string.Format("{0:0.00}", facture.TotalTTC)} €", Element.ALIGN_CENTER));
                articlesTable.AddCell(TableBodyElement($"{string.Format("{0:0.00}", facture.RestToPay)} €", Element.ALIGN_RIGHT));
            }

            if (factures.Count == 0)
                articlesTable.AddCell(TableBodyElement(string.Empty, Element.ALIGN_LEFT, 4));

            #endregion

            #region tables calculation

            PdfPTable calculationTable = new PdfPTable(2) { WidthPercentage = 100, SpacingBefore = 50f };
            calculationTable.DefaultCell.Border = Rectangle.NO_BORDER;

            #region right table

            PdfPTable totalsTable = new PdfPTable(3) { WidthPercentage = 100, SpacingBefore = 10f }; ;

            // Total HT
            totalsTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0
            });
            totalsTable.AddCell(new PdfPCell(new Paragraph("Montant", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });
            totalsTable.AddCell(new PdfPCell(new Paragraph($"{string.Format("{0:0.00}", factures.Sum(e => e.RestToPay))} €", _font9White))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BackgroundColor = _secondaryColor,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT,
            });


            #endregion

            // add data to table footer
            calculationTable.AddCell(new PdfPCell() { BorderWidth = 0 });
            calculationTable.AddCell(new PdfPCell(totalsTable) { BorderWidth = 0 });

            #endregion

            PdfPTable bodyTable = new PdfPTable(1) { WidthPercentage = 100, SpacingBefore = 20f };
            bodyTable.DefaultCell.Border = Rectangle.NO_BORDER;
            bodyTable.AddCell(articlesTable);
            bodyTable.AddCell(calculationTable);

            return bodyTable;
        }

        #endregion

        /// <summary>
        /// header document
        /// </summary>
        /// <param name="client"></param>
        /// <param name="underLogoText"></param>
        /// <returns></returns>
        private PdfPTable HeaderDocument(Client client, string title, string subtitle, string underLogoText, Action<PdfPTable> underTitle)
        {
            var header = new PdfPTable(20)
            {
                WidthPercentage = 100,
                SpacingAfter = 7
            };

            #region left header
            header.AddCell(new PdfPCell(LeftHeaderDocumentTable(underLogoText)) { BorderWidth = 0, Colspan = 6 });
            #endregion

            #region center header
            var centerHeader = new PdfPTable(1)
            {
                WidthPercentage = 100
            };
            centerHeader.AddCell(new PdfPCell(new Paragraph()) { BorderWidth = 0, BorderWidthTop = 1.5f, BorderColor = _secondaryColor });
            centerHeader.AddCell(new PdfPCell(new Paragraph(title, _font24Secondary)) { BorderWidth = 0 });
            centerHeader.AddCell(new PdfPCell(new Paragraph(subtitle, _font12)) { BorderWidth = 0, PaddingBottom = 10f });

            underTitle(centerHeader);

            header.AddCell(new PdfPCell(centerHeader) { BorderWidth = 0, Colspan = 5 });
            #endregion

            #region right header
            var rightHeader = new PdfPTable(1)
            {
                WidthPercentage = 100
            };
            var rightHeaderPaddingLeft = 50f;

            rightHeader.AddCell(new PdfPCell(new Paragraph())
            {
                BorderWidth = 0,
                BorderWidthTop = 1.5f,
                BorderColor = _secondaryColor
            });

            rightHeader.AddCell(new PdfPCell(new Paragraph($"Client : {client.Reference}", _font10Bold))
            {
                BorderWidth = 0,
                PaddingTop = 30f,
                PaddingBottom = 10f,
                PaddingLeft = rightHeaderPaddingLeft
            });

            var paragraphAddressClient = new Paragraph() {
                new Phrase($"{client.FirstName} {client.LastName} {Environment.NewLine}",_font9Bold)
            };

            if (client.Addresses != null && client.Addresses.Any())
            {
                var address = client.Addresses.FirstOrDefault(e => e.IsDefault.HasValue && e.IsDefault.Value);
                if (address != null)
                    paragraphAddressClient.Add(new Phrase(address.BuildAddressPhrase(), _font8));
            }

            rightHeader.AddCell(new PdfPCell(paragraphAddressClient) { BorderWidth = 0, PaddingBottom = 10f, PaddingLeft = rightHeaderPaddingLeft });
            rightHeader.AddCell(new PdfPCell(new Paragraph()) { BorderWidth = 0, PaddingLeft = rightHeaderPaddingLeft });

            header.AddCell(new PdfPCell(rightHeader) { BorderWidth = 0, Colspan = 9 });
            #endregion

            return header;
        }

        /// <summary>
        /// the header of document
        /// </summary>
        private PdfPTable LeftHeaderDocumentTable(string headerText)
        {
            PdfPTable leftHeader = new PdfPTable(1)
            {
                WidthPercentage = 100,
            };

            _logo.ScaleAbsolute(100f, 66f);
            leftHeader.AddCell(new PdfPCell(_logo)
            {
                BorderWidth = 0,
                PaddingBottom = 5f
            });

            leftHeader.AddCell(new PdfPCell(new Paragraph(headerText.TransferHtmlToParagraph()))
            {
                BorderWidth = 0,
            });

            // clearfix
            leftHeader.AddCell(new PdfPCell(new Paragraph()) { BorderWidth = 0 });

            return leftHeader;
        }

        /// <summary>
        /// tables calculation
        /// </summary>
        /// <param name="calculation"></param>
        /// <param name="totalReduction"></param>
        /// <param name="isPrimeCEE"></param>
        /// <param name="primeCEELabel"></param>
        /// <returns></returns>
        private PdfPTable CalculationTable(
            CalculationResultModel calculation,
            decimal totalReduction,
            decimal totalPaid,
            bool isPrimeCEE,
            string primeCEELabel,
            bool isRemise,
            decimal remise,
            RemiseType remiseType)
        {
            PdfPTable calculationTable = new PdfPTable(2)
            {
                WidthPercentage = 100,
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            calculationTable.DefaultCell.Border = Rectangle.NO_BORDER;

            #region left Table

            PdfPTable tvaTable = new PdfPTable(7);

            // Header
            tvaTable.AddCell(TableHeaderElement("TVA", Element.ALIGN_LEFT, 3));
            tvaTable.AddCell(TableHeaderElement("Base H.T", Element.ALIGN_RIGHT, 2));
            tvaTable.AddCell(TableHeaderElement("Montant", Element.ALIGN_RIGHT, 2));

            // Data
            foreach (var item in calculation.CalculationTvas)
            {
                tvaTable.AddCell(TableBodyElement($"TVA collectée {string.Format("{0:0.00} % ", item.TVA)}", Element.ALIGN_LEFT, 3));
                tvaTable.AddCell(TableBodyElement($"{string.Format("{0:0.00}", item.TotalHT)} €", Element.ALIGN_RIGHT, 2));
                tvaTable.AddCell(TableBodyElement($"{string.Format("{0:0.00}", item.TotalTVA)} €", Element.ALIGN_RIGHT, 2));
            }

            // clear fix
            tvaTable.AddCell(new PdfPCell() { Colspan = 7, BorderWidth = 0 });

            #endregion

            #region right table

            PdfPTable totalsTable = new PdfPTable(3);

            // total HT
            totalsTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0
            });
            totalsTable.AddCell(new PdfPCell(new Paragraph("Total H.T.", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });
            totalsTable.AddCell(new PdfPCell(new Paragraph(string.Format("{0:0.00}", calculation.TotalHTRemise) + " €", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });

            // total TTC
            totalsTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0
            });
            totalsTable.AddCell(new PdfPCell(new Paragraph("Total T.T.C.", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });
            totalsTable.AddCell(new PdfPCell(new Paragraph(string.Format("{0:0.00}", calculation.TotalTTC) + " €", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT,
            });

            if (isRemise)
            {
                // Remise 
                totalsTable.AddCell(new PdfPCell(new Paragraph("", _font9))
                {
                    BorderWidth = 0
                });
                totalsTable.AddCell(new PdfPCell(new Paragraph("Remise", _font9))
                {
                    BorderWidth = 0,
                    PaddingBottom = 8f,
                    BorderWidthBottom = 0.3f,
                    BorderColorBottom = _secondaryColor,
                });
                totalsTable.AddCell(new PdfPCell(new Paragraph($"{remise.BuildDiscountPhrase(remiseType)}", _font9))
                {
                    BorderWidth = 0,
                    PaddingBottom = 8f,
                    BorderWidthBottom = 0.3f,
                    BorderColorBottom = _secondaryColor,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                });
            }
            if (isPrimeCEE)
            {
                // Prime CEE DEE
                totalsTable.AddCell(new PdfPCell(new Paragraph("", _font9))
                {
                    BorderWidth = 0
                });
                totalsTable.AddCell(new PdfPCell(new Paragraph(primeCEELabel.IsValid() ? primeCEELabel : "Prime CEE EDF", _font9))
                {
                    BorderWidth = 0,
                    PaddingBottom = 8f,
                    BorderWidthBottom = 0.3f,
                    BorderColorBottom = _secondaryColor,
                });
                totalsTable.AddCell(new PdfPCell(new Paragraph($"{string.Format("{0:0.00}", totalReduction)} €", _font9))
                {
                    BorderWidth = 0,
                    PaddingBottom = 8f,
                    BorderWidthBottom = 0.3f,
                    BorderColorBottom = _secondaryColor,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                });

                // total dû
                totalsTable.AddCell(new PdfPCell(new Paragraph("", _font9))
                {
                    BorderWidth = 0
                });
                totalsTable.AddCell(new PdfPCell(new Paragraph("Total dû", _font9))
                {
                    BorderWidth = 0,
                    PaddingBottom = 8f,
                    BorderWidthBottom = 0.3f,
                    BorderColorBottom = _secondaryColor,
                });
                totalsTable.AddCell(new PdfPCell(new Paragraph($"{string.Format("{0:0.00}", totalPaid)} €", _font9White))
                {
                    BorderWidth = 0,
                    PaddingBottom = 8f,
                    BorderWidthBottom = 0.3f,
                    BackgroundColor = _secondaryColor,
                    BorderColorBottom = _secondaryColor,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                });
            }
            else
            {
                // NET to pay
                totalsTable.AddCell(new PdfPCell(new Paragraph("", _font9))
                {
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    BorderWidth = 0
                });
                totalsTable.AddCell(new PdfPCell(new Paragraph("Net à payer", _font9))
                {
                    BorderWidth = 0,
                    PaddingBottom = 8f,
                    BorderWidthBottom = 0.3f,
                    BorderColorBottom = _secondaryColor,
                });
                totalsTable.AddCell(new PdfPCell(new Paragraph($"{string.Format("{0:0.00}", calculation.TotalTTC)} €", _font9White))
                {
                    BorderWidth = 0,
                    PaddingBottom = 8f,
                    BorderWidthBottom = 0.3f,
                    BackgroundColor = _secondaryColor,
                    BorderColorBottom = _secondaryColor,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                });
            }

            // clear fix
            totalsTable.AddCell(new PdfPCell() { Colspan = 3, BorderWidth = 0 });

            #endregion

            // add data to table footer
            calculationTable.AddCell(new PdfPCell(tvaTable) { BorderWidth = 0 });
            calculationTable.AddCell(new PdfPCell(totalsTable) { BorderWidth = 0 });

            return calculationTable;
        }

        /// <summary>
        /// tables factureCloture
        /// </summary>
        /// <param name="facture"></param>
        /// <returns></returns>
        private PdfPTable FactureCloture(Facture facture)
        {
            PdfPTable calculationTable = new PdfPTable(2)
            {
                WidthPercentage = 100,
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            calculationTable.DefaultCell.Border = Rectangle.NO_BORDER;

            #region right

            PdfPTable spaceTable = new PdfPTable(7);

            #endregion

            #region cloture Table

            PdfPTable clotureTable = new PdfPTable(3);

            // title
            clotureTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0,
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph("Facture de clôture :", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });

            // total HT
            clotureTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph("Total H.T.", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph(string.Format("{0:0.00}", facture.TotalHT) + " €", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });

            // total tva
            clotureTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph("TVA", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph(string.Format("{0:0.00}", facture.TotalTTC - facture.TotalHT) + " €", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });

            // total ttc
            clotureTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph("Total T.T.C", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph(string.Format("{0:0.00}", facture.TotalTTC) + " €", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });

            // total Reste à payer
            clotureTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph("Reste à payer", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph(string.Format("{0:0.00}", facture.TotalTTC) + " €", _font9White))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BackgroundColor = _secondaryColor,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });
            #endregion

            // add data to table footer
            calculationTable.AddCell(new PdfPCell(spaceTable) { BorderWidth = 0 });
            calculationTable.AddCell(new PdfPCell(clotureTable) { BorderWidth = 0 });

            return calculationTable;
        }

        /// <summary>
        /// tables facture Acompte cloture
        /// </summary>
        /// <param name="facturedevis"></param>
        /// <returns></returns>
        private PdfPTable FactureAcompteCloture(FactureDevis facturedevis)
        {
            PdfPTable calculationTable = new PdfPTable(2)
            {
                WidthPercentage = 100,
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            calculationTable.DefaultCell.Border = Rectangle.NO_BORDER;

            #region right

            PdfPTable spaceTable = new PdfPTable(7);

            #endregion

            #region acompte table

            PdfPTable clotureAcompteTable = new PdfPTable(3);

            // title
            clotureAcompteTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0,
            });
            clotureAcompteTable.AddCell(new PdfPCell(new Paragraph($"Acompte : {facturedevis.Facture.Reference} Le {facturedevis.Facture.DateCreation:dd/MM/yyyy}", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                Colspan = 2,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });

            // total HT
            clotureAcompteTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0
            });
            clotureAcompteTable.AddCell(new PdfPCell(new Paragraph("Total H.T.", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });
            clotureAcompteTable.AddCell(new PdfPCell(new Paragraph(string.Format("{0:0.00}", facturedevis.Facture.TotalHT) + " €", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });

            // total tva
            clotureAcompteTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0
            });
            clotureAcompteTable.AddCell(new PdfPCell(new Paragraph("TVA", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });
            clotureAcompteTable.AddCell(new PdfPCell(new Paragraph(string.Format("{0:0.00}", facturedevis.Facture.TotalTTC - facturedevis.Facture.TotalHT) + " €", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });

            // total ttc
            clotureAcompteTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0
            });
            clotureAcompteTable.AddCell(new PdfPCell(new Paragraph("Total T.T.C", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
            });
            clotureAcompteTable.AddCell(new PdfPCell(new Paragraph(string.Format("{0:0.00}", facturedevis.Facture.TotalTTC) + " €", _font9White))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.3f,
                BorderColorBottom = _secondaryColor,
                BackgroundColor = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });
            #endregion

            // add data to table footer
            calculationTable.AddCell(new PdfPCell(spaceTable) { BorderWidth = 0 });
            calculationTable.AddCell(new PdfPCell(clotureAcompteTable) { BorderWidth = 0 });
            return calculationTable;
        }

        /// <summary>
        /// tables facture Acompte
        /// </summary>
        /// <returns></returns>
        private PdfPTable FactureAcompte(List<Article> articles)
        {
            PdfPTable factureAcompteTable = new PdfPTable(1)
            {
                WidthPercentage = 100,
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            #region header table

            PdfPTable calculateTable = new PdfPTable(4)
            {
                WidthPercentage = 100,
                SpacingAfter = 5,
            };
            foreach (var article in articles)
            {
                calculateTable.AddCell(TableHeaderElement($"{article.Designation}", Element.ALIGN_LEFT, 1));
                calculateTable.AddCell(TableHeaderElement("P.U.H.T", Element.ALIGN_RIGHT, 1));
                calculateTable.AddCell(TableHeaderElement("TVA", Element.ALIGN_RIGHT, 1));
                calculateTable.AddCell(TableHeaderElement("P.U.T.T.C", Element.ALIGN_RIGHT, 1));


                calculateTable.AddCell(TableBodyElement($"{string.Format("{0:0.00}", article.TotalTTC)} €", Element.ALIGN_LEFT, 1));
                calculateTable.AddCell(TableBodyElement($"{string.Format("{0:0.00}", article.TotalHT)} €", Element.ALIGN_RIGHT, 1));
                calculateTable.AddCell(TableBodyElement($"{string.Format("{0:0.00}", article.TotalTTC - article.TotalHT)} €", Element.ALIGN_RIGHT, 1));
                calculateTable.AddCell(TableBodyElement($"{string.Format("{0:0.00}", article.TotalTTC)} €", Element.ALIGN_RIGHT, 1));
            }


            #endregion


            // add data to table
            factureAcompteTable.AddCell(new PdfPCell(calculateTable) { BorderWidth = 0 });

            return factureAcompteTable;
        }

        /// <summary>
        /// tables total devis Facture
        /// </summary>
        /// <param name="devisFacture"></param>
        /// <returns></returns>
        private PdfPTable TableTotalDevis(Devis devisFacture)
        {
            PdfPTable calculationTable = new PdfPTable(2)
            {
                WidthPercentage = 100,
                SpacingBefore = 10,
                SpacingAfter = 10
            };
            calculationTable.DefaultCell.Border = Rectangle.NO_BORDER;

            #region right

            PdfPTable spaceTable = new PdfPTable(1);
            spaceTable.AddCell(new PdfPCell(new Paragraph($"Total du devis : {devisFacture.Reference} ", _font12))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderWidthBottom = 0.0f,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_LEFT
            });
            #endregion

            #region cloture Table

            PdfPTable clotureTable = new PdfPTable(3);

            // total ttc
            clotureTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph("", _font9))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BorderColorBottom = _secondaryColor,
            });
            clotureTable.AddCell(new PdfPCell(new Paragraph(string.Format("{0:0.00}", devisFacture.TotalTTC) + " €", _font9White))
            {
                BorderWidth = 0,
                PaddingBottom = 8f,
                BackgroundColor = _secondaryColor,
                BorderColorBottom = _secondaryColor,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });

            #endregion

            // add data to table footer
            calculationTable.AddCell(new PdfPCell(spaceTable) { BorderWidth = 0 });
            calculationTable.AddCell(new PdfPCell(clotureTable) { BorderWidth = 0 });

            return calculationTable;
        }

        /// <summary>
        /// title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private PdfPTable TitleTable(string title)
        {
            var table = new PdfPTable(1)
            {
                WidthPercentage = 100,
                SpacingAfter = 2,
                SpacingBefore = 2,
            };

            table.AddCell(new PdfPCell(new Paragraph(title, _font12))
            {
                BorderWidth = 0,
            });

            return table;
        }
        /// <summary>
        /// footer devis table
        /// </summary>
        /// <param name="primeCEENote"></param>
        /// <param name="totalReduction"></param>
        /// <param name="signatureBase64"></param>
        /// <param name="nameSignataire"></param>
        /// <returns>a pdf table</returns>
        private PdfPTable FooterDevisTable(string primeCEENote, decimal totalReduction, string signatureBase64, string nameSignataire)
        {
            var footerTable = new PdfPTable(3)
            {
                WidthPercentage = 100,
                KeepTogether = true
            };

            if (primeCEENote.IsValid())
            {
                var notePrimeCEEFinal = primeCEENote.Replace("#montant#", $"{string.Format("{0:0.00}", totalReduction)} €");
                footerTable.AddCell(new PdfPCell(notePrimeCEEFinal.TransferHtmlToParagraph()) { BorderWidth = 0, Colspan = 3 });
            }

            if (signatureBase64.IsValid())
            {
                footerTable.AddCell(new PdfPCell(new Paragraph()) { BorderWidth = 0, Colspan = 2, PaddingTop = 7f });
                footerTable.AddCell(new PdfPCell(new Paragraph() {
                    new Phrase($"Nom du client {Environment.NewLine}", _font9Bold),
                    new Phrase(nameSignataire, _font9)
                })
                {
                    BorderWidth = 0,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                footerTable.AddCell(new PdfPCell(new Paragraph()) { BorderWidth = 0, Colspan = 2 });

                var signature = Image.GetInstance(Convert.FromBase64String(signatureBase64.FixBase64()));
                signature.ScaleAbsolute(80f, 80f);
                footerTable.AddCell(new PdfPCell(signature)
                {
                    BorderWidth = 0,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                });
            }

            return footerTable;
        }

        private PdfPTable FooterTable(string conditionReglement)
        {
            var footerTable = new PdfPTable(1)
            {
                WidthPercentage = 100,
                KeepTogether = true
            };

            footerTable.AddCell(new PdfPCell(new Paragraph("Conditions de réglements", _font9Bold))
            {
                BorderWidth = 0
            });

            footerTable.AddCell(new PdfPCell(conditionReglement.TransferHtmlToParagraph())
            {
                BorderWidth = 0
            });

            return footerTable;
        }

        private PdfPTable NoteTable(string note)
        {
            var table = new PdfPTable(1)
            {
                WidthPercentage = 100,
                SpacingAfter = 5,
            };

            if (note.IsValid())
            {
                table.AddCell(new PdfPCell(new Paragraph("Notes : ", _font10Bold))
                {
                    BorderWidth = 0
                });

                table.AddCell(new PdfPCell(note.TransferHtmlToParagraph())
                {
                    BorderWidth = 0
                });
            }

            return table;
        }

        /// <summary>
        /// the articles of document
        /// </summary>
        /// <param name="articles">the list of articles</param>
        /// <returns>a instance </returns>
        private PdfPTable ArticlesDocuments(List<Article> articles)
        {
            var isAllArticleHasNotRemise = articles.All(e => e.Remise == 0);
            var articlesTableNumberColumns = isAllArticleHasNotRemise ? 10 : 11;

            var articlesTable = new PdfPTable(articlesTableNumberColumns)
            {
                WidthPercentage = 100,
                SpacingAfter = 7,
                SpacingBefore = 5,
            };

            #region header table

            articlesTable.AddCell(TableHeaderElement("Description", Element.ALIGN_LEFT, 6));
            articlesTable.AddCell(TableHeaderElement("Qté", Element.ALIGN_CENTER, 1));
            if (!isAllArticleHasNotRemise)
                articlesTable.AddCell(TableHeaderElement("Remise", Element.ALIGN_CENTER, 1));
            articlesTable.AddCell(TableHeaderElement("TVA", Element.ALIGN_RIGHT, 1));
            articlesTable.AddCell(TableHeaderElement("P.U.H.T", Element.ALIGN_RIGHT, 1));
            articlesTable.AddCell(TableHeaderElement("Total H.T", Element.ALIGN_RIGHT, 1));

            #endregion

            #region body table

            foreach (var article in articles)
            {
                if (article.Type == ArticleType.Produit)
                {
                    var descriptionParagraph = new Paragraph();
                    var designationChunk = new Chunk($"{article.Designation}\n\n", _font9Bold);
                    var descriptionChunk = new Chunk(article.Description, _font9);
                    descriptionParagraph.Add(designationChunk);
                    descriptionParagraph.Add(descriptionChunk);
                    articlesTable.AddCell(TableBodyElement(descriptionParagraph, Element.ALIGN_LEFT, 6));
                    articlesTable.AddCell(TableBodyElement(string.Format("{0:0.00}", article.Qte), Element.ALIGN_CENTER, 1));
                    if (!isAllArticleHasNotRemise)
                        articlesTable.AddCell(TableBodyElement(article.Remise.BuildDiscountPhrase(article.RemiseType), Element.ALIGN_CENTER, 1));
                    articlesTable.AddCell(TableBodyElement($"{string.Format("{0:0.00}", article.TVA)} %", Element.ALIGN_RIGHT, 1));
                    articlesTable.AddCell(TableBodyElement($"{string.Format("{0:0.00}", article.PrixHT)} €", Element.ALIGN_RIGHT, 1));
                    articlesTable.AddCell(TableBodyElement($"{string.Format("{0:0.00}", article.TotalHT)} €", Element.ALIGN_RIGHT, 1));
                }
                else
                {
                    var descriptionParagraph = new Paragraph();
                    var designationChunk = new Chunk($"{article.Designation}\n\n", _font9Bold);
                    descriptionParagraph.Add(designationChunk);
                    descriptionParagraph.Add(article.Description.TransferHtmlToParagraph());
                    articlesTable.AddCell(TableBodyElement(descriptionParagraph, Element.ALIGN_LEFT, 6));
                    articlesTable.AddCell(TableBodyElement("", Element.ALIGN_LEFT, isAllArticleHasNotRemise ? 4 : 5));
                }
            }

            #endregion

            if (articles.Count() == 0)
                articlesTable.AddCell(TableBodyElement(" ", Element.ALIGN_LEFT, articlesTableNumberColumns));

            // clear fix
            articlesTable.AddCell(new PdfPCell(new Paragraph("")) { BorderWidth = 0, Colspan = articlesTableNumberColumns });

            return articlesTable;
        }

        /// <summary>
        /// table header element
        /// </summary>
        /// <param name="name">the name of element</param>
        /// <param name="colspan">the number of colspan</param>
        /// <returns></returns>
        private PdfPCell TableHeaderElement(string name, int alignment = Element.ALIGN_LEFT, int colspan = 1)
        {
            return new PdfPCell(new Paragraph(name.ToUpper(), _font9White))
            {
                BorderWidth = 0,
                //BorderWidthBottom = 1.3f,
                //BorderColor = _secondaryColor,
                PaddingRight = 5f,
                PaddingLeft = 5f,
                PaddingTop = 5f,
                PaddingBottom = 8f,
                BackgroundColor = _secondaryColor,
                HorizontalAlignment = alignment,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Colspan = colspan
            };
        }

        /// <summary>
        /// table body element
        /// </summary>
        /// <param name="text">the text to show</param>
        /// <param name="alignment">alignment of text</param>
        /// <param name="colspan">the number of colspan</param>
        /// <returns></returns>
        private PdfPCell TableBodyElement(string text, int alignment = Element.ALIGN_LEFT, int colspan = 1, bool bottomBorder = true)
        {
            return new PdfPCell(new Paragraph(text, _font9))
            {
                PaddingRight = 5f,
                PaddingLeft = 5f,
                PaddingTop = 7f,
                PaddingBottom = 8f,
                BorderWidth = 0,
                BorderWidthBottom = bottomBorder ? 0.3f : 0f,
                BorderColor = _fontSecondaryColor,
                HorizontalAlignment = alignment,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Colspan = colspan
            };
        }

        /// <summary>
        /// table body element
        /// </summary>
        /// <param name="paragraph">the paragraph to show</param>
        /// <param name="alignment">alignment of text</param>
        /// <param name="colspan">the number of colspan</param>
        /// <returns></returns>
        private PdfPCell TableBodyElement(Paragraph paragraph, int alignment = Element.ALIGN_LEFT, int colspan = 1, bool bottomBorder = true)
        {
            return new PdfPCell(paragraph)
            {
                PaddingRight = 5f,
                PaddingLeft = 5f,
                PaddingTop = 7f,
                PaddingBottom = 8f,
                BorderWidth = 0,
                BorderWidthBottom = bottomBorder ? 0.3f : 0f,
                BorderColor = _fontSecondaryColor,
                HorizontalAlignment = alignment,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Colspan = colspan
            };
        }

        /// <summary>
        /// a class describe PDF page event helper
        /// </summary>
        public partial class PdfFooter : PdfPageEventHelper
        {
            private readonly BaseColor _borderTopColor;
            private readonly Font _font;
            private readonly Paragraph _footer;
            private readonly Image _qualibatLogo = Image.GetInstance(Directory.GetCurrentDirectory() + @"/Resources/Pictures/qualibat-logo.png");
            private readonly string _certificatNumber = "Certificat Nº: E102459";

            public PdfFooter(
                Font font,
                Paragraph footer,
                BaseColor borderTopColor)
            {
                _borderTopColor = borderTopColor;
                _font = font;
                _footer = footer;
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                PdfPTable footer = new PdfPTable(1)
                {
                    HorizontalAlignment = Element.ALIGN_BOTTOM,
                    TotalWidth = 550,
                };

                PdfPTable content = new PdfPTable(5);

                content.AddCell(new PdfPCell(new Paragraph(_certificatNumber, _font))
                {
                    BorderWidth = 0,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    VerticalAlignment = Element.ALIGN_BOTTOM,
                });

                content.AddCell(new PdfPCell(_footer)
                {
                    BorderWidth = 0,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_BOTTOM,
                    Colspan = 3
                });

                _qualibatLogo.ScaleAbsolute(25f, 32f);
                content.AddCell(new PdfPCell(_qualibatLogo)
                {
                    BorderWidth = 0,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_BOTTOM,
                    PaddingBottom = 1
                });

                footer.AddCell(new PdfPCell(content)
                {
                    BorderWidth = 0
                });

                footer.AddCell(new PdfPCell(new Paragraph())
                {
                    BorderWidth = 0,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BorderWidthTop = 1,
                    BorderColor = _borderTopColor,
                    PaddingTop = 5
                });

                footer.AddCell(new PdfPCell(new Paragraph($"{writer.PageNumber}", _font))
                {
                    BorderWidth = 0,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                });

                footer.WriteSelectedRows(0, -2, 18, 70, writer.DirectContent);
            }
        }
    }
}
