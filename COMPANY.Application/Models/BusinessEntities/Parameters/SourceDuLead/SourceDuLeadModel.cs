namespace COMPANY.Application.Models.BusinessEntities.Parameters.SourceDuLead
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;

    public class SourceDuLeadModel : EntityModel<string>
    {
        /// <summary>
        /// the name of source du lead
        /// </summary>
        public string Name { get; set; }
    }
}
