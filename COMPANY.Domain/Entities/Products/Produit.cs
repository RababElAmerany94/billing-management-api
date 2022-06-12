namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe produit entity
    /// </summary>
    public class Produit : Entity<string>, IRecordable, IMemoable, IReferencable, IFollowAgence
    {
        public Produit()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Produit");

            PrixParTranche = new HashSet<PrixParQuantite>();
            Labels = new HashSet<string>();
            Memos = new HashSet<Memo>();
            Historique = new HashSet<ChangesHistory>();
        }

        /// <summary>
        /// the reference of produit
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the price Achat of produit
        /// </summary>
        public decimal? PrixAchat { get; set; }

        /// <summary>
        /// the price HT of produit
        /// </summary>
        public decimal PrixHT { get; set; }

        /// <summary>
        /// the TVA of produit
        /// </summary>
        public double TVA { get; set; }

        /// <summary>
        /// the description of produit
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the designation of produit
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// prix par tranche.
        /// </summary>
        public ICollection<PrixParQuantite> PrixParTranche { get; set; }

        /// <summary>
        /// the unit of product
        /// </summary>
        public string Unite { get; set; }

        /// <summary>
        /// is this product accessible for all agence
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// the array of labels
        /// </summary>
        public ICollection<string> Labels { get; set; }

        /// <summary>
        /// the list of memos.
        /// </summary>
        public ICollection<Memo> Memos { get; set; }

        /// <summary>
        /// history of produit
        /// </summary>
        public ICollection<ChangesHistory> Historique { get; set; }

        #region relations

        /// <summary>
        /// the id of fournisseur associate with this produit
        /// </summary>
        public string FournisseurId { get; set; }

        /// <summary>
        /// the fournisseur associate with this produit
        /// </summary>
        public Fournisseur Fournisseur { get; set; }

        /// <summary>
        /// the id of category associate with this entity
        /// </summary>
        /// <value></value>
        public string CategoryId { get; set; }

        /// <summary>
        /// the category associate with this entity
        /// </summary>
        /// <value></value>
        public CategoryProduct Category { get; set; }

        /// <summary>
        /// the id of the agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence related to this produit, could be null
        /// </summary>
        public Agence Agence { get; set; }

        #endregion

        /// <summary>
        /// the list of prix par agence
        /// </summary>
        public virtual IEnumerable<PrixProduitParAgence> PrixProduitParAgences { get; set; }

        public override void BuildSearchTerms()
            => SearchTerms = $"{Reference} {Designation} {string.Join(",", Labels)}";
    }
}
