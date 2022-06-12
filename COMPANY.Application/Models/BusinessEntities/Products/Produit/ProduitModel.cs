namespace COMPANY.Application.Models.BusinessEntitiesModels.ProduitModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Application.Models.BusinessEntitiesModels.CategoryProductModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.PrixProduitParAgenceModels;
    using COMPANY.Domain.Entities.OwnedEntities;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe produit model
    /// </summary>
    public class ProduitModel : EntityModel<string>
    {
        /// <summary>
        /// the reference of produit
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the name of produit
        /// </summary>
        public string Name { get; set; }

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

        /// <summary>
        /// the id of the agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the id of fournisseur associate with this produit
        /// </summary>
        public string FournisseurId { get; set; }

        /// <summary>
        /// the id of category associate with this entity
        /// </summary>
        /// <value></value>
        public string CategoryId { get; set; }

        /// <summary>
        /// the category associate with this entity
        /// </summary>
        /// <value></value>
        public CategoryProductModel Category { get; set; }

        /// <summary>
        /// the fournisseur associate with this produit
        /// </summary>
        public FournisseurModel Fournisseur { get; set; }

        /// <summary>
        /// the list of prix par agence
        /// </summary>
        public IEnumerable<PrixProduitParAgenceModel> PrixProduitParAgences { get; set; }
    }
}
