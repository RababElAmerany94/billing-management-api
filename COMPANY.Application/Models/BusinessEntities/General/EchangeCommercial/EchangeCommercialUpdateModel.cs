namespace COMPANY.Application.Models.BusinessEntities.General.EchangeCommercial
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    public class EchangeCommercialUpdateModel : EchangeCommercialCreateModel, IEntityUpdateModel<EchangeCommercial>
    {
        /// <summary>
        /// update the commercial exchange from the current commercial exchange Model
        /// </summary>
        /// <param name="entity">the commercial exchange instant to be updated</param>
        public void Update(EchangeCommercial entity)
        {
            entity.Titre = Titre;
            entity.Description = Description;
            entity.Type = Type;
            entity.DateEvent = DateEvent;
            entity.Status = Status;
            entity.Priorite = Priorite;
            entity.Duree = Duree;
            entity.PhoneNumber = PhoneNumber;
            entity.TypeAppelId = TypeAppelId;
            entity.TacheTypeId = TacheTypeId;
            entity.RdvTypeId = RdvTypeId;
            entity.CategorieId = CategorieId;
            entity.SourceRDVId = SourceRDVId;
            entity.DossierId = DossierId;
            entity.ClientId = ClientId;
            entity.ResponsableId = ResponsableId;

            if (Time.HasValue)
                entity.DateEvent = entity.DateEvent.Date + Time.Value;
        }
    }
}
