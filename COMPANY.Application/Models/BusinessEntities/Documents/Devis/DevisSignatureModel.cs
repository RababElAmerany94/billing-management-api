using System;
using System.Collections.Generic;
using System.Text;

namespace COMPANY.Application.Models.BusinessEntities.Documents.Devis
{
    public class DevisSignatureModel
    {
        /// <summary>
        /// the id of devis
        /// </summary>
        public string DevisId { get; set; }

        /// <summary>
        /// the signature image base64 of devis
        /// </summary>
        public string Signe { get; set; }

        /// <summary>
        /// the name of who sign devis
        /// </summary>
        public string NameClientSignature { get; set; }
    }
}
