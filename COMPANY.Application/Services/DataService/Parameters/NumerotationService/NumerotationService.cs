namespace COMPANY.Application.Services.DataService.NumerotationService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
    using COMPANY.Application.Models.BusinessEntitiesModels.NumerotationModels;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// the implementation of the <see cref="INumerotationService"/>
    /// </summary>
    [Inject(typeof(INumerotationService), ServiceLifetime.Scoped)]
    public class NumerotationService :
        BaseService<Numerotation, string, NumerotationModel, NumerotationCreateModel, NumerotationUpdateModel>,
        INumerotationService
    {
        private readonly IDataRequestBuilder<PeriodeComptable> _periodeComptableRequestBuilder;
        private readonly IDataRequestBuilder<Facture> _factureRequestBuilder;
        private readonly IDataRequestBuilder<Avoir> _avoirRequestBuilder;
        private readonly IDataAccess<PeriodeComptable, string> _periodeComptableDataAccess;
        private readonly IDataAccess<Facture, string> _factureDataAccess;
        private readonly IDataAccess<Avoir, string> _avoirDataAccess;

        public NumerotationService(
            IDataRequestBuilder<Numerotation> dataRequestBuilder,
            IDataRequestBuilder<PeriodeComptable> periodeComptableRequestBuilder,
            IDataRequestBuilder<Facture> factureRequestBuilder,
            IDataRequestBuilder<Avoir> avoirRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        {
            _periodeComptableRequestBuilder = periodeComptableRequestBuilder;
            _factureRequestBuilder = factureRequestBuilder;
            _avoirRequestBuilder = avoirRequestBuilder;
            _periodeComptableDataAccess = unitOfWork.DataAccess<PeriodeComptable, string>();
            _factureDataAccess = unitOfWork.DataAccess<Facture, string>();
            _avoirDataAccess = unitOfWork.DataAccess<Avoir, string>();
        }

        /// <summary>
        /// create the numerotation with the given values
        /// </summary>
        /// <param name="createModel">the create model for the numerotation entity</param>
        /// <returns>the newly created numerotation result</returns>
        public async Task<Result<NumerotationModel>> CreateNumerotationAsync(NumerotationCreateModel createModel)
            => await CreateAsync(createModel);

        /// <summary>
        /// generate numerotation
        /// </summary>
        /// <param name="type">the type of numerotation</param>
        /// <returns>the numerotation generated</returns>
        public async Task<Result<string>> GenerateNumerotationAsync(NumerotationType type)
        {
            var numerotation = await GetNumerotationByTypeBaseCurrentUser(type);
            var numerotationGenerated = GenerateNumerotation(numerotation);
            return Result<string>.Success(numerotationGenerated, "generated with success");
        }

        /// <summary>
        /// get the list of all numerotations
        /// </summary>
        /// <returns>Client List</returns>
        public async Task<Result<IEnumerable<NumerotationModel>>> GetAllNumerotationAsync()
        {
            IEnumerable<Numerotation> result;

            if (_user.IsFollowAgence)
            {
                // the current logged in user could be an agence or any other user
                // the key here is to use the agence id on the user entity

                var request = _dataRequestBuilder
                        .AddPredicate(c => c.AgenceId == _user.AgenceId)
                    .Buil();

                result = await _dataAccess.GetAsync(request);
            }
            else
            {
                // the current logged in user could be an admin
                var request = _dataRequestBuilder
                    .AddPredicate(c => string.IsNullOrEmpty(c.AgenceId))
                    .Buil();

                // the current logged in user is an admin
                result = await _dataAccess.GetAsync(request);
            }
            if (result is null)
                return Result<IEnumerable<NumerotationModel>>.Failed(null, null, "Failed to retrieve list of Numerotation");

            var data = _mapper.Map<IEnumerable<NumerotationModel>>(result);
            return Result<IEnumerable<NumerotationModel>>.Success(data);

        }

        /// <summary>
        /// get the numerotation with the  given id
        /// </summary>
        /// <param name="id">the id of the numerotation to retrieve</param>
        /// <returns>the numerotation result</returns>
        public async Task<Result<NumerotationModel>> GetNumerotationByIdAsync(string id)
            => await GetByIdAsync(id);

        /// <summary>
        /// increment numerotation
        /// </summary>
        /// <param name="type">the type of numerotation</param>
        /// <returns>the result</returns>
        public async Task<Result> IncrementNumerotationAsync(NumerotationType type)
        {
            var numerotation = await GetNumerotationByTypeBaseCurrentUser(type);
            numerotation.Counter++;
            _dataAccess.Update(numerotation);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("numerotation incremented with success");
        }

        /// <summary>
        /// update the Numerotation from the given model
        /// </summary>
        /// <param name="numerotationId">the id of the Numerotation to be updated</param>
        /// <param name="numerotationModel">the update model</param>
        /// <returns>the update version of the Numerotation</returns>
        public async Task<Result<NumerotationModel>> UpdateNumerotationAsync(string numerotationId, NumerotationUpdateModel numerotationModel)
            => await UpdateAsync(numerotationId, numerotationModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numerotationCreateModel"></param>
        /// <returns></returns>
        public async Task<Result> CreateListNumerotationAsync(List<NumerotationCreateModel> numerotationCreateModel)
        {
            var numerotation = _mapper.Map<List<Numerotation>>(numerotationCreateModel);
            await _dataAccess.AddRangeAsync(numerotation);
            return Result.Success("added successfully");
        }

        /// <summary>
        /// increment numerotation without save changes
        /// </summary>
        /// <param name="type">the type of numerotation</param>
        /// <returns>the result</returns>
        public async Task IncrementNumerotationWithoutSaveChangesAsync(NumerotationType type)
        {
            var numerotation = await GetNumerotationByTypeBaseCurrentUser(type);
            numerotation.Counter++;
            _dataAccess.Update(numerotation);
        }

        /// <summary>
        /// generate reference for accounting document 
        /// </summary>
        /// <param name="creationDate">the creation date</param>
        /// <param name="type">the type of document comptable</param>
        /// <returns>a <see cref="ReferenceDocumentComptable"/> instance</returns>
        public async Task<Result<ReferenceDocumentComptable>> GenerateReferenceDocumentComptable(DateTime creationDate, DocumentComptableType type)
        {
            var numerotation = await GetNumerotationByTypeBaseCurrentUser((NumerotationType)type);

            // the accounting period of date creation
            var accountingPeriod = await GetPeriodeComptableBaseGivenDate(creationDate);

            // the current open accounting period
            var currentAccountingPeriod = await GetCurrentPeriodeComptable();

            // if current accounting period is null
            if (currentAccountingPeriod is null)
            {
                var referenceAccountingDocument = new ReferenceDocumentComptable
                {
                    Reference = "",
                    Status = DocumentComptableReferenceStatus.ConfigureAccountingPeriod,
                    IsOld = false
                };

                return Result<ReferenceDocumentComptable>.Failed(referenceAccountingDocument, null, "reference doesn't generate");
            }

            // if accounting period not exist or closure
            if (accountingPeriod is null)
            {
                var referenceAccountingDocument = new ReferenceDocumentComptable
                {
                    Reference = "",
                    Status = DocumentComptableReferenceStatus.PeriodNotExistOrClosure,
                    IsOld = false
                };

                return Result<ReferenceDocumentComptable>.Failed(referenceAccountingDocument, null, "reference doesn't generate");
            }

            // If dates in the same period (the current and that contains creation date)
            if (accountingPeriod.DateDebut == currentAccountingPeriod.DateDebut)
            {
                var referenceAccountingDocument = new ReferenceDocumentComptable
                {
                    Reference = GenerateNumerotation(numerotation),
                    Status = DocumentComptableReferenceStatus.Ok,
                    Counter = numerotation.Counter,
                    IsOld = false
                };

                return Result<ReferenceDocumentComptable>.Success(referenceAccountingDocument, "reference generated successfully");
            }
            // else includes in old accounting period 
            else
            {
                var counter = 1;

                switch (type)
                {
                    case DocumentComptableType.Facture:
                        var facture = await GetLastFactureInPeriodeComptable(accountingPeriod);
                        counter = facture is null ? 1 : (facture.Counter.Value + 1);
                        break;

                    case DocumentComptableType.Avoir:
                        var avoir = await GetLastAvoirInPeriodeComptable(accountingPeriod);
                        counter = avoir is null ? 1 : (avoir.Counter.Value + 1);
                        break;
                }

                numerotation.Counter = counter;

                var referenceAccountingDocument = new ReferenceDocumentComptable
                {
                    Reference = GenerateNumerotation(numerotation),
                    Status = DocumentComptableReferenceStatus.Ok,
                    Counter = numerotation.Counter,
                    IsOld = true
                };

                return Result<ReferenceDocumentComptable>.Success(referenceAccountingDocument, "reference generated successfully");
            }
        }

        #region private methods

        /// <summary>
        /// generate numerotation
        /// </summary>
        /// <param name="numerotation">the numerotation object</param>
        /// <returns></returns>
        private string GenerateNumerotation(Numerotation numerotation)
        {
            var generatedNumerotation = numerotation.Root;

            // date today
            var dateToday = DateTime.Today;

            // add date to numerotation if we have it
            switch (numerotation.DateFormat)
            {
                case DateFormat.Year:
                    generatedNumerotation += $"{dateToday.Year}";
                    break;

                case DateFormat.YearMonth:
                    generatedNumerotation += $"{dateToday.Year}{dateToday.Month}";
                    break;

                default:
                    break;
            }

            // generate counter part
            generatedNumerotation += GenerateCounterPart(numerotation.Counter, numerotation.CounterLength);

            return generatedNumerotation;
        }

        /// <summary>
        /// Generate counter part
        /// </summary>
        /// <param name="counter">the counter</param>
        /// <param name="counterLenght">the counter lenght</param>
        /// <returns>return counter part</returns>
        private string GenerateCounterPart(int counter, int? counterLenght)
        {
            if (counterLenght.HasValue)
                return counter.ToString().PadLeft(counterLenght.Value, '0');
            else
                return counter.ToString();
        }

        private async Task<Numerotation> GetNumerotationByTypeBaseCurrentUser(NumerotationType type)
        {
            var predicate = PredicateBuilder.True<Numerotation>();

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId && c.Type == type);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid() && c.Type == type);

            var request = _dataRequestBuilder.AddPredicate(predicate).Buil();
            return await _dataAccess.GetSingleAsync(request);
        }

        /// <summary>
        /// get periode comptable base given date
        /// </summary>
        /// <param name="date">the date creation of the document</param>
        /// <returns>a periode comptable</returns>
        private async Task<PeriodeComptable> GetPeriodeComptableBaseGivenDate(DateTime date)
        {
            var predicate = PredicateBuilder.True<PeriodeComptable>()
                .And(c => c.DateDebut <= date.Date)
                .And(c => c.DateDebut.AddMonths(c.Period).AddDays(-1) >= date.Date)
                .And(c => !c.DateCloture.HasValue);

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            return await _periodeComptableDataAccess.GetSingleAsync(predicate);
        }

        /// <summary>
        /// get current periode comptable
        /// </summary>
        /// <returns>period comptable</returns>
        private async Task<PeriodeComptable> GetCurrentPeriodeComptable()
        {
            var predicate = PredicateBuilder.True<PeriodeComptable>();

            predicate = predicate.And(c => !c.DateCloture.HasValue);

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            var request = _periodeComptableRequestBuilder
                    .AddPredicate(predicate)
                    .AddOrderBy(SortDirection.Desc, c => c.DateDebut)
                    .Buil();

            return await _periodeComptableDataAccess.GetSingleAsync(request);
        }

        /// <summary>
        /// get last facture in periode comptable
        /// </summary>
        /// <returns> a facture</returns>
        private async Task<Facture> GetLastFactureInPeriodeComptable(PeriodeComptable accountingPeriod)
        {
            var predicate = PredicateBuilder.True<Facture>()
                        .And(c => accountingPeriod.DateDebut <= c.DateCreation)
                        .And(c => accountingPeriod.DateDebut.AddMonths(accountingPeriod.Period).AddDays(-1) >= c.DateCreation.Date)
                        .And(c => c.Status != FactureStatus.Brouillon);

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            var request = _factureRequestBuilder
                         .AddPredicate(predicate)
                         .AddOrderBy(SortDirection.Desc, c => c.Counter)
                         .Buil();

            return await _factureDataAccess.GetSingleAsync(request);
        }

        /// <summary>
        /// get last avoir in periode comptable
        /// </summary>
        /// <returns> a avoir</returns>
        private async Task<Avoir> GetLastAvoirInPeriodeComptable(PeriodeComptable accountingPeriod)
        {
            var predicate = PredicateBuilder.True<Avoir>()
                        .And(c => accountingPeriod.DateDebut <= c.DateCreation)
                        .And(c => accountingPeriod.DateDebut.AddMonths(accountingPeriod.Period).AddDays(-1) >= c.DateCreation.Date)
                        .And(c => c.Status != AvoirStatus.Brouillon);

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            var request = _avoirRequestBuilder
                         .AddPredicate(predicate)
                         .AddOrderBy(SortDirection.Desc, c => c.Counter)
                         .Buil();

            return await _avoirDataAccess.GetSingleAsync(request);
        }

        #endregion

        #region overrides

        protected override Expression<Func<Numerotation, bool>> BuildGetListPredicate()
        {
            var predicate = PredicateBuilder.True<Numerotation>();

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            return predicate;
        }

        #endregion
    }
}
