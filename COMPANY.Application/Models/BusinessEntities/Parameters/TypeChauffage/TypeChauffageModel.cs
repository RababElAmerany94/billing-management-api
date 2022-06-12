namespace COMPANY.Application.Models.BusinessEntities.Parameters.TypeChauffage
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;

    public class TypeChauffageModel : EntityModel<string>
    {
        /// <summary>
        /// the name de type de chauffage
        /// </summary>
        public string Name { get; set; }
    }
}
