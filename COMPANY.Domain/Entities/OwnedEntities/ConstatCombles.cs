namespace COMPANY.Domain.Entities.OwnedEntities
{
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.FicheControl;

    /// <summary>
    /// a class describe constat combles
    /// </summary>
    public class ConstatCombles
    {
        /// <summary>
        /// Type de pose
        /// </summary>
        public PosteType? PosteType { get; set; }

        /// <summary>
        /// Surface d’isolant prévue (m²)
        /// </summary>
        public double? SurfaceIsolantPrevue { get; set; }

        /// <summary>
        /// Surface d’isolant posé (m²)
        /// </summary>
        public double? SurfaceIsolantPose { get; set; }

        /// <summary>
        /// Ecart entre S prévue et S posé >15%
        /// </summary>
        public bool? IsEcartSurfacePrevueAndPoseOk { get; set; }

        /// <summary>
        /// Si impossibilité de mesure depuis les combles, la surface isolée a été estimée :
        /// - Depuis l’intérieur
        /// - Depuis l’extérieur
        /// - Sur plans 
        /// - Par autre moyen
        /// </summary>
        public string SurfaceEstimeDepuis { get; set; }

        /// <summary>
        /// Surface isolant retenue (m²).
        /// </summary>
        public double? SurfaceIsolantRetenue { get; set; }

        /// <summary>
        /// Rehausse ou protection des installations électriques : 
        /// (VMC, répartiteur de chaleur, ampli antenne…)
        /// </summary>
        public FicheControleStatusItem? RehausseOuProtectionInstallationsElectriques { get; set; }

        /// <summary>
        /// Repérage des boites électriques
        /// </summary>
        public FicheControleStatusItem? ReperageBoitesElectriques { get; set; }

        /// <summary>
        /// Présence d’un écart au feu sur le ou les conduit(s) d’évacuation 
        /// de fumées : (Hauteur +20% que la hauteur d’isolant)
        /// </summary>
        public FicheControleStatusItem? PresenceEcartAuFeuOuConduitsEvacuationFumees { get; set; }

        /// <summary>
        /// présence d’un coffrage de trappe de visite : (hauteur +20% que la hauteur d’isolant)
        /// </summary>
        public FicheControleStatusItem? PresenceCoffrageTrappeVisite { get; set; }

        /// <summary>
        /// trappe de visite isolée
        /// </summary>
        public FicheControleStatusItem? TrappeVisiteIsolee { get; set; }


        /// <summary>
        /// présence de protection des points lumineux type spots
        /// </summary>
        public FicheControleStatusItem? PresenceProtectionPointsLumineuxTypeSpots { get; set; }

        /// <summary>
        /// Présence de pige de repérage hauteur d’isolant
        /// </summary>
        public FicheControleStatusItem? PresencePigeReperageHauteurIsolant { get; set; }

        /// <summary>
        /// Epaisseur mesurée (5 points de contrôle) :
        /// </summary>
        public int? EpaisseurMesuree { get; set; }

        /// <summary>
        /// Conclusion épaisseur (SATISFAISANT, NON SATISFAISANT)
        /// </summary>
        public bool? ConclusionEpaisseur { get; set; }

        /// <summary>
        /// Homogénéité de la couche d’isolant
        /// </summary>
        public bool? HomogeneiteCoucheIsolant { get; set; }
    }
}
