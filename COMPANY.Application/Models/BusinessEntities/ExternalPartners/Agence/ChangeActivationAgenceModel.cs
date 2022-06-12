using System;
using System.Collections.Generic;
using System.Text;

namespace COMPANY.Application.Models.BusinessEntities.ExternalPartners.Agence
{
    public class ChangeActivationAgenceModel
    {
        /// <summary>
        /// the id of agence
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// is this agence active
        /// </summary>
        public bool IsActive { get; set; }
    }
}
