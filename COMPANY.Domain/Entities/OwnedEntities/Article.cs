namespace COMPANY.Domain.Entities.OwnedEntities
{
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.General;

    /// <summary>
    /// a class describe article 
    /// </summary>
    public class Article
    {
        /// <summary>
        /// the id of articles
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the reference of produit
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the price Achat of article
        /// </summary>
        public decimal? PrixAchat { get; set; }

        /// <summary>
        /// the price HT of produit
        /// </summary>
        public decimal PrixHT { get; set; }

        /// <summary>
        /// the TVA of produit
        /// </summary>
        public decimal TVA { get; set; }

        /// <summary>
        /// the description of article
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// the designation of article
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// prix par tranche. see more <see cref="PrixParQuantite"/>
        /// </summary>
        public PrixParQuantite[] PrixParTranche { get; set; }

        /// <summary>
        /// the unit of product
        /// </summary>
        public string Unite { get; set; }

        /// <summary>
        /// the id of category product 
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// the category product 
        /// </summary>
        public CategoryProduct Category { get; set; }

        /// <summary>
        /// the id of fournisseur associate with this article
        /// </summary>
        public string FournisseurId { get; set; }

        /// <summary>
        /// the quantity of articles
        /// </summary>
        public int Qte { get; set; }

        /// <summary>
        /// the original price
        /// </summary>
        public decimal? PrixOriginal { get; set; }

        /// <summary>
        /// the total HT
        /// </summary>
        public decimal TotalHT { get; set; }

        /// <summary>
        /// the total TTC
        /// </summary>
        public decimal TotalTTC { get; set; }

        /// <summary>
        /// the discount of demande RDV
        /// </summary>
        public decimal Remise { get; set; }

        /// <summary>
        /// the type discount of demande RDV
        /// </summary>
        public RemiseType RemiseType { get; set; }

        /// <summary>
        /// the type of article
        /// </summary>
        /// <value></value>
        public ArticleType Type { get; set; }
    }
}
