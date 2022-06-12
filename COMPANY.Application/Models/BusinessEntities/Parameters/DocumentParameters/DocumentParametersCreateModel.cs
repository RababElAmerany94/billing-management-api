namespace COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels
{
    using COMPANY.Domain.Entities.OwnedEntities;

    /// <summary>
    /// a class describe document parameteres create model
    /// </summary>
    public class DocumentParametersCreateModel
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

        /// <summary>
        /// the associate id of document parameters
        /// </summary>
        public string AgenceId { get; set; }
    }
}
