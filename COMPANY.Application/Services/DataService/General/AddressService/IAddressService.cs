namespace COMPANY.Application.Services.DataService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.GeneralModels.PagingModels;
    using COMPANY.Domain.Entities;
    using COMPANY.Presistence.Implementations;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAddressService
    { 
        Task<Result<IEnumerable<CountryModel>>> GetAllCountriesAsync();
        Task<Result<IEnumerable<DepartementModel>>> GetAllDepartementsAsync();
        Task<PagedResult<DepartementModel>> GetDepartementsAsPagedResultAsync(DepartmentFilterOption filterModel);
        Task<PagedResult<CountryModel>> GetCountriesAsPagedResultAsync(FilterOption filterOption);
        Task<Result<DepartementModel>> GetDepartementByIdAsync(string id);
        Task<Result<CountryModel>> GetCountryByIdAsync(string id);
    }
}
