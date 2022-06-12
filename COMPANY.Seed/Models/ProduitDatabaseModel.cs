namespace COMPANY.Seed.Models
{
    public class ProduitDatabaseModel
    {
        public string Reference { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public decimal PrixAchat { get; set; }
        public decimal PrixHT { get; set; }
        public decimal TVA { get; set; }
        public string Unite { get; set; }
        public bool Visible { get; set; }
        public string Labels { get; set; }
        public string Fournisseur { get; set; }
        public string Categorie { get; set; }

        public ProduitDatabaseModel(
            string reference, 
            string designation, 
            string description, 
            decimal prixAchat,
            decimal prixHT, 
            decimal tva, 
            string unite, 
            bool visible, 
            string labels, 
            string fournisseur, 
            string categorie)
        {
            Reference = reference;
            Designation = designation;
            Description = description;
            PrixAchat = prixAchat;
            PrixHT = prixHT;
            TVA = tva;
            Unite = unite;
            Visible = visible;
            Labels = labels;
            Fournisseur = fournisseur;
            Categorie = categorie;
        }
    }
}
