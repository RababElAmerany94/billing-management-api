namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Entities.OwnedEntities;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe proces verbal of dossier
    /// </summary>
    public class DossierPV : Entity<string>
    {
        public DossierPV()
        {
            Id = Common.Helpers.IdentityDocument.Generate("DossierPV");

            Photos = new HashSet<PhotoDocument>();
            Articles = new HashSet<Article>();
        }

        /// <summary>
        /// the photos of dossier PV.
        /// </summary>
        public ICollection<PhotoDocument> Photos { get; set; }

        /// <summary>
        /// the articles of dossier PV
        /// </summary>
        public ICollection<Article> Articles { get; set; }

        /// <summary>
        /// is the client satisfied of service offered
        /// </summary>
        public bool IsSatisfied { get; set; }

        /// <summary>
        /// the reason of no satisfaction of client
        /// </summary>
        public string ReasonNoSatisfaction { get; set; }

        /// <summary>
        /// the name of client who sign PV
        /// </summary>
        public string NameClientSignature { get; set; }

        /// <summary>
        /// the signature of client
        /// </summary>
        public string SignatureClient { get; set; }

        /// <summary>
        /// the signature of techncien
        /// </summary>
        public string SignatureTechnicien { get; set; }

        #region relationships

        /// <summary>
        /// the fiche controle id associate with this entity
        /// </summary>
        public string FicheControleId { get; set; }

        /// <summary>
        /// the fiche controle associate with this entity
        /// </summary>
        public FicheControle FicheControle { get; set; }

        /// <summary>
        /// the dossier id of dossier PV
        /// </summary>
        public string DossierId { get; set; }

        /// <summary>
        /// the dossier of dossier PV
        /// </summary>
        public Dossier Dossier { get; set; }

        #endregion

        public override void BuildSearchTerms()
            => SearchTerms = $"";
    }
}
