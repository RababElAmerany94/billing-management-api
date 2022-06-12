namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Interfaces;
    using OwnedEntities;

    /// <summary>
    /// a class describe document parameters entity
    /// </summary>
    public class DocumentParameters : Entity<string>, IFollowAgence
    {
        public DocumentParameters()
        {
            Id = Common.Helpers.IdentityDocument.Generate("DocumentParameters");

            TVA = new TvaParameters();
            Facture = new FactureDocumentParameters();
            Avoir = new AvoirDocumentParameters();
            Devis = new DevisDocumentParameters();
        }

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

        #region relationship

        /// <summary>
        /// the id of agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence associate with this document parameters
        /// </summary>
        public Agence Agence { get; set; }

        #endregion

        public override void BuildSearchTerms() 
            => SearchTerms = $"";
    }
}
