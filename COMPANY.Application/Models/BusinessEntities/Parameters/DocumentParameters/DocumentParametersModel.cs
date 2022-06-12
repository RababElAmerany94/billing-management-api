namespace COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.OwnedEntities;

    /// <summary>
    /// a class describe document parameteres model
    /// </summary>
    public class DocumentParametersModel : EntityModel<string>
    {
        /// <summary>
        /// the parameters tva of document parameters.
        /// </summary>
        public TvaParameters TVA { get; set; }

        /// <summary>
        /// the parameters facture of document parameters.
        /// </summary>
        public FactureDocumentParameters Facture { get; set; }

        /// <summary>
        /// the parameters avoir of document parameters.
        /// </summary>
        public AvoirDocumentParameters Avoir { get; set; }

        /// <summary>
        /// the parameters devis of document parameters. 
        /// </summary>
        public DevisDocumentParameters Devis { get; set; }

        /// <summary>
        /// the parameters bon commande of document parameters. 
        /// </summary>
        public BonCommandeParameters BonCommande { get; set; }
    }
}
