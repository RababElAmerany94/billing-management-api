namespace COMPANY.Application.Services.PdfGenerateService
{
    using COMPANY.Application.Models.BusinessEntities.Documents.Facture;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// the base interface for all PDF generate service
    /// </summary>
    public interface IPdfGenerateService
    {
        /// <summary>
        /// generation of devis PDF
        /// </summary>
        /// <param name="devis">a instance of devis entity</param>
        /// <param name="parameters">devis parameters</param>
        /// <returns>a array of byte</returns>
        byte[] GenerateDevisPDF(Devis devis, DevisDocumentParameters parameters);

        /// <summary>
        /// generation of facture PDF
        /// </summary>
        /// <param name="facture">a instance of facture entity</param>
        /// <param name="parameters">facture parameters</param>
        /// <returns>a array of byte</returns>
        byte[] GenerateFacturePDF(Facture facture, FactureDocumentParameters parameters);

        /// <summary>
        /// generation of facture PDF
        /// </summary>
        /// <param name="avoir">a instance of facture entity</param>
        /// <param name="parameters">facture parameters</param>
        /// <returns>a array of byte</returns>
        byte[] GenerateAvoirPDF(Avoir avoir, AvoirDocumentParameters parameters);

        /// <summary>
        /// generate pdf releve factures
        /// </summary>
        /// <param name="client"></param>
        /// <param name="factures"></param>
        /// <param name="parameters"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        byte[] GenerateReleveFacturesPDF(Client client, List<ReleveFactureItemExport> factures, FactureDocumentParameters parameters, DateTime dateFrom, DateTime dateTo);

        /// <summary>
        /// generate pdf of bon commande
        /// </summary>
        byte[] GenerateBonComandePDF(BonCommande bonCommande, BonCommandeParameters parameters);
    }
}
