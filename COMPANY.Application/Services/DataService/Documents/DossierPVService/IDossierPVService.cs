namespace COMPANY.Application.Services.DataService.Documents.DossierPVService
{
    using COMPANY.Application.Models.BusinessEntities.Documents.DossierPV;
    using COMPANY.Domain.Entities;

    public interface IDossierPVService
        : IBaseService<DossierPV, string, DossierPVModel, DossierPVCreateModel, DossierPVUpdateModel>
    { }
}
