namespace COMPANY.Application.Services.DataService.Documents.FicheControleService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Documents.FicheControle;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    [Inject(typeof(IFicheControleService), ServiceLifetime.Scoped)]
    public class FicheControleService :
        BaseService<FicheControle, string, FicheControleModel, FicheControleCreateModel, FicheControleUpdateModel>,
        IFicheControleService
    {
        private readonly IDataAccess<DossierPV, string> _dossierPVDataAccess;

        public FicheControleService(
            IDataRequestBuilder<FicheControle> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        {
            _dossierPVDataAccess = unitOfWork.DataAccess<DossierPV, string>();
        }

        #region overrides

        protected override async Task AfterAddEntity(FicheControle entity, FicheControleCreateModel model)
        {
            await AssignDossierPVToFicheControle(entity, model);
        }

        protected override async Task AfterUpdateEntity(FicheControle entity, FicheControleUpdateModel model)
            => await UpdateDossierPVInFicheControle(entity, model);

        #endregion

        #region private methods

        private async Task<DossierPV> GetDossierPV(string dossierPVId)
        {
            var dossierPV = await _dossierPVDataAccess.GetAsync(dossierPVId);

            if (dossierPV is null)
                throw new NotFoundException($"there is not dossier with the given id {dossierPVId}");

            return dossierPV;
        }

        private async Task UpdateDossierPVInFicheControle(FicheControle entity, FicheControleUpdateModel model)
        {
            DossierPV dossierPV = await GetDossierPV(model.DossierPVId);

            dossierPV.FicheControleId = entity.Id;
            _dossierPVDataAccess.Update(dossierPV);
        }

        private async Task AssignDossierPVToFicheControle(FicheControle entity, FicheControleCreateModel model)
        {
            var dossierPV = await GetDossierPV(model.DossierPVId);

            if (dossierPV.FicheControleId.IsValid())
                throw new UnAcceptableRequestException("the chosen dossier PV had already a fiche controle");

            dossierPV.FicheControleId = entity.Id;
            _dossierPVDataAccess.Update(dossierPV);
        }

        #endregion
    }
}
