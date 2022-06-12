namespace COMPANY.Application.Models.Generals.Antsroute
{
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe base create basket order
    /// </summary>
    public class BasketOrderCreateModel : BaseBasketOrder
    {
        public BasketOrderCreateModel() : base()
        { }

        public BasketOrderCreateModel(Dossier dossier) : this()
        {
            //ExternalId = dossier.Id;
            DueDate = dossier.DatePose.Value.ToString("yyyy-MM-dd");
            Type = OrderType.Delivery;
            Duration = 30;
            var siteIntervention = dossier?.SiteIntervention?.BuildAddressFormatAnsroute();
            Customer = new Customer(dossier.Client, siteIntervention);
            CustomFields.Add(new CustomField()
            {
                Name = "N° Dossier",
                Value = dossier.Reference
            });
        }
    }
}
