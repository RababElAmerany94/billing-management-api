namespace COMPANY.Infrastructure.FileService
{
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.Accounting.Comptabilite;
    using COMPANY.Application.Services.FileService;
    using COMPANY.Common.Helpers;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// the implementation of <see cref="IFileService"/>
    /// </summary>
    [Inject(typeof(IFileService), ServiceLifetime.Singleton)]
    public class FileService : IFileService
    {
        /// <summary>
        /// generate the Excel file for agence
        /// </summary>
        /// <param name="agences">the list of agences</param>
        /// <returns>excel file as a Byte Array</returns>
        public byte[] GenerateAgenceExcelFile(IEnumerable<AgenceModel> agences)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                // Sets Headers
                ws.Cells[1, 1].Value = "Réference";
                ws.Cells[1, 2].Value = "RaisonSociale";
                ws.Cells[1, 3].Value = "Siret";
                ws.Cells[1, 4].Value = "Civilité";
                ws.Cells[1, 5].Value = "Nom";
                ws.Cells[1, 6].Value = "Prénom";
                ws.Cells[1, 7].Value = "Fonction";
                ws.Cells[1, 8].Value = "Email";
                ws.Cells[1, 9].Value = "Mobile";
                ws.Cells[1, 10].Value = "Fixe";
                ws.Cells[1, 11].Value = "Commentaire";
                ws.Cells[1, 12].Value = "Address";
                ws.Cells[1, 13].Value = "Complément Address";
                ws.Cells[1, 14].Value = "Ville";
                ws.Cells[1, 15].Value = "Code Postal";
                ws.Cells[1, 16].Value = "Département";
                ws.Cells[1, 17].Value = "Pays";

                int i = 0;
                foreach (var agence in agences)
                {
                    ws.Cells[i + 2, 1].Value = agence.Reference;
                    ws.Cells[i + 2, 2].Value = agence.RaisonSociale;
                    ws.Cells[i + 2, 3].Value = agence.Siret;

                    var contact = agence?.Contacts?.FirstOrDefault();

                    if (!(contact is null))
                    {
                        ws.Cells[i + 2, 4].Value = contact.Civilite;
                        ws.Cells[i + 2, 5].Value = contact.Nom;
                        ws.Cells[i + 2, 6].Value = contact.Prenom;
                        ws.Cells[i + 2, 7].Value = contact.Fonction;
                        ws.Cells[i + 2, 8].Value = contact.Email;
                        ws.Cells[i + 2, 9].Value = contact.Mobile;
                        ws.Cells[i + 2, 10].Value = contact.Fixe;
                        ws.Cells[i + 2, 11].Value = contact.Commentaire;
                    }

                    var adresse = agence?.AdressesFacturation?.FirstOrDefault();

                    if (!(adresse is null))
                    {
                        ws.Cells[i + 2, 12].Value = adresse.Adresse;
                        ws.Cells[i + 2, 13].Value = adresse.ComplementAdresse;
                        ws.Cells[i + 2, 14].Value = adresse.Ville;
                        ws.Cells[i + 2, 15].Value = adresse.CodePostal;
                        ws.Cells[i + 2, 16].Value = adresse.Departement;
                        ws.Cells[i + 2, 17].Value = adresse.Pays;
                    }

                    i += 1;
                }

                // Format Header of Table
                using (ExcelRange rng = ws.Cells["A1:Q1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid; //Set Pattern for the background to Solid 
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gold); //Set color to DarkGray 
                    rng.Style.Font.Color.SetColor(Color.Black);
                    rng.AutoFitColumns();
                }

                var excelsBytes = excelPackage.GetAsByteArray();
                return excelsBytes;
            }
        }

        /// <summary>
        /// generate the Excel file for Clients
        /// </summary>
        /// <param name="clients">the list of Clients</param>
        /// <returns>excel file as a Byte Array</returns>
        public byte[] GenerateClientExcelFile(IEnumerable<ClientModel> clients)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                // Sets Headers
                ws.Cells[1, 1].Value = "Référence";
                ws.Cells[1, 2].Value = "Nom";
                ws.Cells[1, 3].Value = "Téléphone";
                ws.Cells[1, 4].Value = "Email";
                ws.Cells[1, 5].Value = "Site Web";
                ws.Cells[1, 6].Value = "Siret";
                ws.Cells[1, 7].Value = "Code Comptable";
                ws.Cells[1, 8].Value = "Adresse";
                ws.Cells[1, 9].Value = "Complement Address";
                ws.Cells[1, 10].Value = "Ville";
                ws.Cells[1, 11].Value = "Code Postal";
                ws.Cells[1, 12].Value = "Pays";
                ws.Cells[1, 13].Value = "Département";


                int i = 0;
                foreach (var client in clients)
                {
                    ws.Cells[i + 2, 1].Value = client.Reference;
                    ws.Cells[i + 2, 2].Value = client.FullName;
                    ws.Cells[i + 2, 3].Value = client.PhoneNumber;
                    ws.Cells[i + 2, 4].Value = client.Email;
                    ws.Cells[i + 2, 5].Value = client.WebSite;
                    //ws.Cells[i + 2, 6].Value = client.Siret;
                    ws.Cells[i + 2, 7].Value = client.CodeComptable;

                    var adresse = client?.Addresses?.FirstOrDefault();

                    if (!(adresse is null))
                    {
                        ws.Cells[i + 2, 8].Value = adresse.Adresse;
                        ws.Cells[i + 2, 9].Value = adresse.ComplementAdresse;
                        ws.Cells[i + 2, 10].Value = adresse.Ville;
                        ws.Cells[i + 2, 11].Value = adresse.CodePostal;
                        ws.Cells[i + 2, 12].Value = adresse.Departement;
                        ws.Cells[i + 2, 13].Value = adresse.Pays;
                    }

                    i = i + 1;
                }

                // Format Header of Table
                using (ExcelRange rng = ws.Cells["A1:M1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid; //Set Pattern for the background to Solid 
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gold); //Set color to DarkGray 
                    rng.Style.Font.Color.SetColor(Color.Black);
                    rng.AutoFitColumns();
                }
                //return pck;
                var excelsBytes = excelPackage.GetAsByteArray();
                return excelsBytes;
            }
        }

        /// <summary>
        /// generate the Excel file for Suppliers
        /// </summary>
        /// <param name="fournisseur">the list of Suppliers</param>
        /// <returns>excel file as a Byte Array</returns>
        public byte[] GenerateFournisseurExcelFile(IEnumerable<FournisseurModel> fournisseur)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                // Sets Headers
                ws.Cells[1, 1].Value = "RaisonSociale";
                ws.Cells[1, 2].Value = "Adresse";
                ws.Cells[1, 3].Value = "Complement Address";
                ws.Cells[1, 4].Value = "Ville";
                ws.Cells[1, 6].Value = "Code Postal";
                ws.Cells[1, 7].Value = "Pays";
                ws.Cells[1, 8].Value = "Département";

                int i = 0;
                foreach (var supplier in fournisseur)
                {
                    ws.Cells[i + 2, 1].Value = supplier.RaisonSociale;

                    var adresse = supplier?.Addresses?.FirstOrDefault();

                    if (!(adresse is null))
                    {
                        ws.Cells[i + 2, 2].Value = adresse.Adresse;
                        ws.Cells[i + 2, 3].Value = adresse.ComplementAdresse;
                        ws.Cells[i + 2, 4].Value = adresse.Ville;
                        ws.Cells[i + 2, 6].Value = adresse.CodePostal;
                        ws.Cells[i + 2, 7].Value = adresse.Departement;
                        ws.Cells[i + 2, 8].Value = adresse.Pays;
                    }

                    i = i + 1;
                }

                // Format Header of Table
                using (ExcelRange rng = ws.Cells["A1:H1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid; //Set Pattern for the background to Solid 
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gold); //Set color to DarkGray 
                    rng.Style.Font.Color.SetColor(Color.Black);
                    rng.AutoFitColumns();
                }

                var excelsBytes = excelPackage.GetAsByteArray();
                return excelsBytes;
            }
        }

        /// <summary>
        /// generate the Excel file for Ventes Journal
        /// </summary>
        /// <param name="journal">the list of Ventes Journal</param>
        /// <returns>excel file as a Byte Array</returns>
        public byte[] GenerateVentesJournalExcelFile(IEnumerable<VentesJournalModel> journal)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                // Sets Headers
                ws.Cells[1, 1].Value = "Code journal";
                ws.Cells[1, 2].Value = "Date";
                ws.Cells[1, 3].Value = "Numéro de compte";
                ws.Cells[1, 4].Value = "Numéro de pièce";
                ws.Cells[1, 5].Value = "Client";
                ws.Cells[1, 6].Value = "Débit";
                ws.Cells[1, 7].Value = "Crédit";

                int i = 0;
                foreach (var item in journal)
                {
                    ws.Cells[i + 2, 1].Value = item.CodeJournal;
                    ws.Cells[i + 2, 2].Value = item.DateCreation.ToString("dd/MM/yyyy");
                    ws.Cells[i + 2, 3].Value = item.NumeroCompte;
                    ws.Cells[i + 2, 4].Value = item.NumeroPiece;
                    ws.Cells[i + 2, 5].Value = item.ClientName;
                    ws.Cells[i + 2, 6].Value = item.Debit;
                    ws.Cells[i + 2, 7].Value = item.Credit;
                    i += 1;
                }

                // Format Header of Table
                using (ExcelRange rng = ws.Cells["A1:G1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid; //Set Pattern for the background to Solid 
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gold); //Set color to DarkGray 
                    rng.Style.Font.Color.SetColor(Color.Black);
                    rng.AutoFitColumns();
                }
                //return pck;
                var excelsBytes = excelPackage.GetAsByteArray();

                return excelsBytes;
            }
        }

        /// <summary>
        /// generate the Excel file for Accounts Journal
        /// </summary>
        /// <param name="comptesJournal">the list of comptabilite Journal</param>
        /// <returns>excel file as a Byte Array</returns>
        public byte[] GenerateComptesJournalExcelFile(List<ComptesJournalModel> comptesJournal)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                // Sets Headers
                ws.Cells[1, 1].Value = "Code journal";
                ws.Cells[1, 2].Value = "Date";
                ws.Cells[1, 3].Value = "Numéro de compte";
                ws.Cells[1, 4].Value = "Numéro de pièce";
                ws.Cells[1, 5].Value = "Tiers";
                ws.Cells[1, 6].Value = "Débit";
                ws.Cells[1, 7].Value = "Crédit";
                ws.Cells[1, 8].Value = "Type paiement";

                int i = 0;
                foreach (var accountJournal in comptesJournal)
                {
                    ws.Cells[i + 2, 1].Value = accountJournal.CodeJournal;
                    ws.Cells[i + 2, 2].Value = accountJournal.DatePaiment.ToString("dd/MM/yyyy");
                    ws.Cells[i + 2, 3].Value = accountJournal.NumeroCompte;
                    ws.Cells[i + 2, 4].Value = accountJournal.NumeroPiece;
                    ws.Cells[i + 2, 5].Value = accountJournal.Tiers;
                    ws.Cells[i + 2, 6].Value = accountJournal.Debit;
                    ws.Cells[i + 2, 7].Value = accountJournal.Credit;
                    ws.Cells[i + 2, 8].Value = accountJournal.PaimentMethod;
                    i += 1;
                }

                // Format Header of Table
                using (ExcelRange rng = ws.Cells["A1:H1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid; //Set Pattern for the background to Solid 
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gold); //Set color to DarkGray 
                    rng.Style.Font.Color.SetColor(Color.Black);
                    rng.AutoFitColumns();
                }
                //return pck;
                var excelsBytes = excelPackage.GetAsByteArray();

                return excelsBytes;
            }
        }


        /// <summary>
        /// get data of excel
        /// </summary>
        /// <param name="file">the file format base64</param>
        /// <returns>the list of items</returns>
        public List<List<string>> GetDataExcel(string file)
        {
            try
            {
                var data = Convert.FromBase64String(file.FixBase64());
                var stream = new MemoryStream(data);
                var result = new List<List<string>>();

                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();

                    int rows = worksheet.Dimension.Rows;
                    int columns = worksheet.Dimension.Columns;

                    // loop through the worksheet rows and columns
                    for (int i = 1; i <= rows; i++)
                    {
                        var line = new List<string>();
                        for (int j = 1; j <= columns; j++) {
                            line.Add(worksheet.Cells[i, j].Value.ToString());
                        }
                        result.Add(line);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
