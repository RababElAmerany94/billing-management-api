namespace COMPANY.Application.Services.DataService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.GeneralModels.PagingModels;
    using COMPANY.Domain.Entities;
    using COMPANY.Presistence.Implementations;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Inject(typeof(IAddressService), ServiceLifetime.Scoped)]
    public class AddressService : IAddressService
    {
        private readonly IDataAccess<Country, string> _countryDataAccess;
        private readonly IDataAccess<Departement, string> _departementDataAccess;
        private readonly IMapper _mapper;
        private readonly IDataRequestBuilder<Departement> _departementDataRequestBuilder;

        public AddressService(
            IMapper mapper,
            IDataRequestBuilder<Departement> departementDataRequestBuilder,
            IUnitOfWork unitOfWork)
        {
            _countryDataAccess = unitOfWork.DataAccess<Country, string>();
            _departementDataAccess = unitOfWork.DataAccess<Departement, string>();
            _mapper = mapper;
            _departementDataRequestBuilder = departementDataRequestBuilder;
        }

        public async Task<Result<IEnumerable<CountryModel>>> GetAllCountriesAsync()
        {
            var result = await _countryDataAccess.GetAsync();

            if (result is null)
                return Result<IEnumerable<CountryModel>>.Failed(null, null, "Failed to retrieve list of countries");

            var data = _mapper.Map<IEnumerable<CountryModel>>(result);
            return Result<IEnumerable<CountryModel>>.Success(data);
        }

        public async Task<Result<IEnumerable<DepartementModel>>> GetAllDepartementsAsync()
        {
            var result = await _departementDataAccess.GetAsync();

            if (result is null)
                return Result<IEnumerable<DepartementModel>>.Failed(null, null, "Failed to retrieve list of departement");

            var data = _mapper.Map<IEnumerable<DepartementModel>>(result);
            return Result<IEnumerable<DepartementModel>>.Success(data);
        }

        public async Task<Result<CountryModel>> GetCountryByIdAsync(string id)
        {
            var result = await _countryDataAccess.GetAsync(id);
            var data = _mapper.Map<CountryModel>(result);
            return Result<CountryModel>.Success(data);
        }

        public async Task<Result<DepartementModel>> GetDepartementByIdAsync(string id)
        {
            var result = await _departementDataAccess.GetAsync(id);
            var data = _mapper.Map<DepartementModel>(result);
            return Result<DepartementModel>.Success(data);
        }

        public async Task<PagedResult<CountryModel>> GetCountriesAsPagedResultAsync(FilterOption filterOption)
        {
            var result = await _countryDataAccess.GetPagedResultAsync(filterOption);

            if (!result.HasValue)
                return PagedResult<CountryModel>.Failed(null, "Failed to retrieve list of countries");

            var data = _mapper.Map<IEnumerable<CountryModel>>(result.Value);
            return PagedResult<CountryModel>.Success(data, result.CurrentPage, result.PageCount, result.PageSize, result.RowCount);
        }

        public async Task<PagedResult<DepartementModel>> GetDepartementsAsPagedResultAsync(DepartmentFilterOption filterModel)
        {
            var predicate = PredicateBuilder.True<Departement>();

            if (filterModel.CountryId != null)
                predicate = predicate.And(x => x.CountryId == filterModel.CountryId);

            var request = _departementDataRequestBuilder.AddPredicate(predicate).Buil();

            var result = await _departementDataAccess.GetPagedResultAsync(filterModel, request);

            if (!result.HasValue)
                return PagedResult<DepartementModel>.Failed(null, "Failed to retrieve list of departments");

            var data = _mapper.Map<IEnumerable<DepartementModel>>(result.Value);
            return PagedResult<DepartementModel>.Success(data, result.CurrentPage, result.PageCount, result.PageSize, result.RowCount);
        }
    }
}
