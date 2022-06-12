namespace COMPANY.Application.Services.FileService
{
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.Accounting.Comptabilite;
    using System.Collections.Generic;

    /// <summary>
    /// the base interface for all File Services
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// generate the Excel file for agence
        /// </summary>
        /// <param name="agences">the list of agences</param>
        /// <returns>excel file as a Byte Array</returns>
        byte[] GenerateAgenceExcelFile(IEnumerable<AgenceModel> agences);

        /// <summary>
        /// generate the Excel file for Clients
        /// </summary>
        /// <param name="clients">the list of Clients</param>
        /// <returns>excel file as a Byte Array</returns>
        byte[] GenerateClientExcelFile(IEnumerable<ClientModel> clients);

        /// <summary>
        /// generate the Excel file for Suppliers
        /// </summary>
        /// <param name="fournissuers">the list of Suppliers</param>
        /// <returns>excel file as a Byte Array</returns>
        byte[] GenerateFournisseurExcelFile(IEnumerable<FournisseurModel> fournissuers);

        /// <summary>
        /// get data of excel
        /// </summary>
        /// <param name="file">the file format base64</param>
        /// <returns>the list of items</returns>
        List<List<string>> GetDataExcel(string file);

        /// <summary>
        /// generate the Excel file for Ventes Journal
        /// </summary>
        /// <param name="ventesJournal">the list of Ventes Journal</param>
        /// <returns>excel file as a Byte Array</returns>
        byte[] GenerateVentesJournalExcelFile(IEnumerable<VentesJournalModel> ventesJournal);

        /// <summary>
        /// generate the Excel file for Accounts Journal
        /// </summary>
        /// <param name="comptesJournal">the list of comptabilite Journal</param>
        /// <returns>excel file as a Byte Array</returns>
        byte[] GenerateComptesJournalExcelFile(List<ComptesJournalModel> comptesJournal);
    }
}
