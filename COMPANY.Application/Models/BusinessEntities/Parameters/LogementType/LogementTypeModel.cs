namespace COMPANY.Application.Models.BusinessEntities.Parameters.LogementType
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;

    public class LogementTypeModel : EntityModel<string>
    {
        /// <summary>
        /// the name of logement
        /// </summary>
        public string Name { get; set; }
    }
}
