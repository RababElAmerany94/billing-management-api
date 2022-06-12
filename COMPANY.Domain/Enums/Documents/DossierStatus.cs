namespace COMPANY.Domain.Enums
{
    using COMPANY.Domain.Attribute;

    /// <summary>
    /// marked perdu before signed
    /// </summary>
    public enum DossierStatus
    {
        [Description("en attente")]
        EnAttente = 1,

        [Description("assigné")]
        Assigne = 2,

        [Description("en retard")]
        EnRetard = 3,

        [Description("perdu")]
        Perdu = 4,

        [Description("chiffré")]
        Chiffre = 5,

        [Description("signe")]
        Signe = 6,

        [Description("à planifier")]
        Aplanifie = 7,

        [Description("planifie")]
        Planifie = 8,

        [Description("realise")]
        Realise = 9,

        [Description("facturé")]
        Facture = 10
    }
}
