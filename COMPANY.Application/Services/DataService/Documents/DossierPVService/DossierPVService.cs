namespace COMPANY.Application.Services.DataService.Documents.DossierPVService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Documents.DossierPV;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Enums;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    [Inject(typeof(IDossierPVService), ServiceLifetime.Scoped)]
    public class DossierPVService
        : BaseService<DossierPV, string, DossierPVModel, DossierPVCreateModel, DossierPVUpdateModel>, IDossierPVService
    {
        private readonly IDataAccess<Dossier, string> _dossierDataAccess;
        private readonly IDataAccess<FicheControle, string> _ficheControleDataAccess;

        public DossierPVService(
            IDataRequestBuilder<DossierPV> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        {
            _dossierDataAccess = unitOfWork.DataAccess<Dossier, string>();
            _ficheControleDataAccess = unitOfWork.DataAccess<FicheControle, string>();
        }

        #region overrides

        protected override async Task AfterAddEntity(DossierPV entity, DossierPVCreateModel model)
            => await UpdateStatusDossier(model);

        protected override async Task AfterDeleteEntity(DossierPV entity)
        {
            if (entity.FicheControleId.IsValid())
                await _ficheControleDataAccess.DeleteAsync(entity.FicheControleId);
        }


        #endregion

        #region private methods

        private async Task UpdateStatusDossier(DossierPVCreateModel model)
        {
            var dossier = await _dossierDataAccess.GetAsync(model.DossierId);

            if (dossier is null)
                throw new NotFoundException($"there is no dossier with the given id {model.DossierId}");

            dossier.Status = DossierStatus.Realise;
            _dossierDataAccess.Update(dossier);
        }

        #endregion
    }
}
