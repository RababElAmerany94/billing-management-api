namespace COMPANY.Domain.Entities.OwnedEntities
{
    using COMPANY.Domain.Enums.VisteTechnique;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe technical visit
    /// </summary>
    public class VisteTechnique
    {
        /// <summary>
        /// the type of technical visit
        /// </summary>
        public VisteTechniqueType Type { get; set; }

        /// <summary>
        /// the number of pieces
        /// </summary>
        public int NombrePiece { get; set; }

        /// <summary>
        /// the total area to trait
        /// </summary>
        public double SurfaceTotaleAIsoler { get; set; }

        /// <summary>
        /// the ranking technical
        /// </summary>
        public ClassementTechnique ClassementTechnique { get; set; }

        /// <summary>
        /// the forms relations to technical visit
        /// </summary>
        public ICollection<VisteTechniqueFormulaire> Formulaires { get; set; }
    }

    /// <summary>
    /// a class describe technical visit form
    /// </summary>
    public class VisteTechniqueFormulaire
    {
        /// <summary>
        /// the type of access
        /// </summary>
        public VisteTechniqueTypeAccess? TypeAccess { get; set; }

        /// <summary>
        /// the dimensions of access
        /// </summary>
        public string Dimensions { get; set; }

        /// <summary>
        /// the type of roof
        /// </summary>
        public VisteTechniqueToit? Toit { get; set; }

        /// <summary>
        /// the more information about type access
        /// </summary>
        public string DetailTypeAccess { get; set; }

        /// <summary>
        /// the area to comble
        /// </summary>
        public double? SurfaceComble { get; set; }

        /// <summary>
        /// the area of piece
        /// </summary>
        public double? SurfacePiece { get; set; }

        /// <summary>
        /// the floor type
        /// </summary>
        public string TypePlancher { get; set; }

        /// <summary>
        /// the ridge height
        /// </summary>
        public double? HauteurSousFaitage { get; set; }

        /// <summary>
        /// the ceiling height
        /// </summary>
        public double? HauteurSousPlafond { get; set; }

        /// <summary>
        /// the number chimney flue number
        /// </summary>
        public double? NombreConduitCheminee { get; set; }

        /// <summary>
        /// the number spots to protect
        /// </summary>
        public double? NombreSpotsAProteger { get; set; }

        /// <summary>
        /// the number luminaire
        /// </summary>
        public double? NombreLuminaire { get; set; }

        /// <summary>
        /// the number VMS
        /// </summary>
        public double? NombreVMC { get; set; }

        /// <summary>
        /// the presence ot tuyauterie
        /// </summary>
        public string PresenceTuyauterie { get; set; }

        /// <summary>
        /// the type of support
        /// </summary>
        public string TypeSupport { get; set; }

        /// <summary>
        /// presence of prote garge
        /// </summary>
        public double? PresencePorteGarge { get; set; }

        /// <summary>
        /// is degagement to provude
        /// </summary>
        public bool IsDegagementAPrevoir { get; set; }

        /// <summary>
        /// is to coffrer
        /// </summary>
        public bool IsACoffrer { get; set; }

        /// <summary>
        /// is to enhance
        /// </summary>
        public bool IsARehausser { get; set; }

        /// <summary>
        /// is presence nuisible
        /// </summary>
        public bool IsPresenceNuisibles { get; set; }

        /// <summary>
        /// the type of nuisible
        /// </summary>
        public string TypeNuisible { get; set; }

        /// <summary>
        /// is presence of boites derivation
        /// </summary>
        public bool IsPresenceBoitesDerivation { get; set; }
    }
}
