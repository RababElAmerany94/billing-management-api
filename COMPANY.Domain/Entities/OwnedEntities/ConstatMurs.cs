namespace COMPANY.Domain.Entities.OwnedEntities
{
    using COMPANY.Domain.Enums.FicheControl;

    /// <summary>
    /// a class describe constat des murs
    /// </summary>
    public class ConstatMurs
    {
        /// <summary>
        /// Surface d’isolant prévue (m²)
        /// </summary>
        public double? SurfaceIsolantPrevue { get; set; }

        /// <summary>
        /// Surface d’isolant posé (m²)
        /// </summary>
        public double? SurfaceIsolantPose { get; set; }

        /// <summary>
        /// Pose correcte de l’isolant (oui, non)
        /// </summary>
        public bool? IsPoseCorrecteIsolant { get; set; }

        /// <summary>
        /// ecart autour des points d’éclairage
        /// </summary>
        public FicheControleStatusItem? EcartAutourPointsEclairage { get; set; }

        /// <summary>
        /// ecart autour des boitiers électrique
        /// </summary>
        public FicheControleStatusItem? EcartAutourBoitiersElectrique { get; set; }

        /// <summary>
        /// ecart au feu autour de fumées : (mini 10 cm)
        /// </summary>
        public FicheControleStatusItem? EcartAuFeuAutourFumees { get; set; }

        /// <summary>
        /// présence de fils non gainés noyés dans isolant :
        /// </summary>
        public FicheControleStatusItem? PresenceFilsNonGainesNoyesDansIsolant { get; set; }

        /// <summary>
        /// conclusion isolation murs (SATISFAISANT, NON SATISFAISANT)
        /// </summary>
        public bool? ConclusionIsolationMurs { get; set; }
    }
}
