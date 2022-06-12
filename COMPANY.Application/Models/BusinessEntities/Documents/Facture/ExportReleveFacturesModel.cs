namespace COMPANY.Application.Models.BusinessEntities.Documents.Facture
{
    using System.Collections.Generic;

    /// <summary>
    /// a class describe export releve facture model
    /// </summary>
    public class ExportReleveFacturesModel
    {
        /// <summary>
        /// the releve of factures in format PDF
        /// </summary>
        public byte[] ReleveFacture { get; set; }

        /// <summary>
        /// the list of facture in format PDF
        /// </summary>
        public List<byte[]> Factures { get; set; }
    }
}
