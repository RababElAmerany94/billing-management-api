namespace COMPANY.Application.Models.BusinessEntities.Documents.FicheControle
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using COMPANY.Domain;
    using COMPANY.Domain.Entities.OwnedEntities;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe fiche controle model
    /// </summary>
    public class FicheControleModel : EntityModel<string>
    {
        /// <summary>
        /// the number of operation
        /// </summary>
        public string NumberOperation { get; set; }

        /// <summary>
        /// the date of controle
        /// </summary>
        public DateTime DateControle { get; set; }

        /// <summary>
        /// the type of prestation
        /// </summary>
        public PrestationType PrestationType { get; set; }

        /// <summary>
        /// the list of photo
        /// </summary>
        public ICollection<PhotoDocument> Photos { get; set; }

        /// <summary>
        /// the constat combles.
        /// </summary>
        public ConstatCombles ConstatCombles { get; set; }

        /// <summary>
        /// the constat planchers.
        /// </summary>
        public ConstatPlanchers ConstatPlanchers { get; set; }

        /// <summary>
        /// the constat murs.
        /// </summary>
        public ConstatMurs ConstatMurs { get; set; }

        /// <summary>
        /// the remarques of fiche controle
        /// </summary>
        public string Remarques { get; set; }

        /// <summary>
        /// evaluation of accomagnement by 10
        /// </summary>
        public int EvaluationAccompagnement { get; set; }

        /// <summary>
        /// les travaux réalisés by 10
        /// </summary>
        public int EvaluationTravauxRealises { get; set; }

        /// <summary>
        /// La propreté du chantier by 10
        /// </summary>
        public int EvaluationPropreteChantier { get; set; }

        /// <summary>
        /// A quel niveau évalueriez-vous le contact avec 
        /// nos techniciens applicateurs ? by 10
        /// </summary>
        public int EvaluationContactAvecTechniciensApplicateurs { get; set; }

        #region signature

        /// <summary>
        /// the signature of controller
        /// </summary>
        public string SignatureController { get; set; }

        /// <summary>
        /// the signature of client
        /// </summary>
        public string SignatureClient { get; set; }

        /// <summary>
        /// the name of client signer
        /// </summary>
        public string NameClientSignature { get; set; }

        #endregion

        #region relationships

        /// <summary>
        /// the controller id associate with fiche controle
        /// </summary>
        public string ControllerId { get; set; }

        /// <summary>
        /// the controller id associate with fiche controle
        /// </summary>
        public UserLiteModel Controller { get; set; }

        #endregion
    }
}
