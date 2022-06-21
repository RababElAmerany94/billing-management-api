namespace COMPANY.Application.Services.DataService
{
    using Application.Data;
    using Application.Models;
    using Application.Services.FileService;
    using AutoMapper;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Services.DataService.NumerotationService;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Enums;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// the implementation of the <see cref="IFournisseurService"/>
    /// </summary>
    [Inject(typeof(IFournisseurService), ServiceLifetime.Scoped)]
    public class FournisseurService :
        BaseService<Fournisseur, string, FournisseurModel, FournisseurCreateModel, FournisseurUpdateModel>, IFournisseurService
    {
        private readonly IFileService _fileService;
        private readonly INumerotationService _numerotationService;

        public FournisseurService(
            IDataRequestBuilder<Fournisseur> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser,
            IFileService fileService,
            INumerotationService numerotationService) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        {
            _fileService = fileService;
            _numerotationService = numerotationService;
        }

        #region supplier

        /// <summary>
        /// export the list of Supplier as an excel file
        /// </summary>
        /// <returns>the result instant</returns>
        public async Task<Result<byte[]>> ExportFournisseurListAsExcelAsync()
        {
            try
            {
                var founisseurs = await _dataAccess.GetAsync();
                var SupplierModelList = _mapper.Map<IEnumerable<FournisseurModel>>(founisseurs);
                var excelFile = _fileService.GenerateFournisseurExcelFile(SupplierModelList);
                return Result<byte[]>.Success(excelFile, "the file created successful");
            }
            catch (Exception ex)
            {
                return Result<byte[]>.Failed(null, ex, "Failed generating the excel file, an exception has been thrown");
            }
        }

        /// <summary>
        /// check if the given reference is unique
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        public async Task<Result<bool>> CheckUniqueReferenceAsync(string reference)
        {
            var result = await _dataAccess.IsExistAsync(c => c.Reference == reference && c.AgenceId == _user.AgenceId);
            return Result<bool>.Success(!result);
        }

        #endregion

        #region overrides

        protected override async Task AfterAddEntity(Fournisseur entity, FournisseurCreateModel model)
            => await _numerotationService.IncrementNumerotationAsync(NumerotationType.Fournisseur);

        protected override Expression<Func<Fournisseur, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterModel)
        {
            var predicate = PredicateBuilder.True<Fournisseur>();

            if (_user.AgenceId.IsValid())
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);

            return predicate;
        }

        #endregion

    }
}
