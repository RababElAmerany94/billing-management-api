namespace COMPANY.Domain.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// a class describe category product entity
    /// </summary>
    public class CategoryProduct : Entity<string>
    {
        public CategoryProduct()
        {
            Id = Common.Helpers.IdentityDocument.Generate("CategoryProduct");
        }

        /// <summary>
        /// the name of category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the accounting code
        /// </summary>
        public string AccountingCode { get; set; }

        /// <summary>
        /// the list produits associate with this category
        /// </summary>
        public ICollection<Produit> Produits { get; set; }

        /// <summary>
        /// the search builder
        /// </summary>
        public override void BuildSearchTerms() => SearchTerms = $"{Name}";
    }
}
