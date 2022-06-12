namespace COMPANY.Application.Models.BusinessEntities.Parameters.ModeleSms
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;

    public class ModeleSmsModel : EntityModel<string>
    {
        /// <summary>
        /// the Nom with SMS
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the Text with SMS
        /// </summary>
        public string Text { get; set; }
    }
}
