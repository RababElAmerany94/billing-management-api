namespace COMPANY.Application.Services.DataService.General.SmsService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.General.Sms;
    using COMPANY.Application.Models.Generals.FilterOptions;
    using COMPANY.Application.Tools;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities.Generals;
    using COMPANY.Helpers;
    using COMPANY.Presistence.Implementations;
    using Inova.AutoInjection.Attributes;
    using Inova.SpotHit.Interface;
    using Inova.SpotHit.Models;
    using Inova.SpotHit.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Inject(typeof(ISmsService), ServiceLifetime.Scoped)]
    public class SmsService : ISmsService
    {
        private readonly ISpotHitService _spotHitService;
        private readonly ILogger<SmsService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataRequestBuilder<Sms> _requestBuilder;
        private readonly IMapper _mapper;
        private readonly IDataAccess<Sms, string> _dataAccess;

        public SmsService(
            ISpotHitService spotHitService,
            ILogger<SmsService> logger,
            IUnitOfWork unitOfWork,
            IDataRequestBuilder<Sms> requestBuilder,
            IMapper mapper)
        {
            _spotHitService = spotHitService;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _requestBuilder = requestBuilder;
            _mapper = mapper;
            _dataAccess = unitOfWork.DataAccess<Sms, string>();
        }

        /// <summary>
        /// get list sms as paged
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a paged result</returns>
        public async Task<PagedResult<SmsModel>> GeAsPagedResultAsync(SmsFilterOption filterOption)
        {
            var request = BuildAsPagedDataRequest(filterOption);
            var result = await _dataAccess.GetPagedResultAsync(filterOption, request);

            if (!result.HasValue)
                return PagedResult<SmsModel>.Failed(result.Error, $"Failed to retrieve list of sms");

            var data = _mapper.Map<IEnumerable<SmsModel>>(result.Value);
            return PagedResult<SmsModel>.Success(
                data, result.CurrentPage, result.PageCount, result.PageSize, result.RowCount,
                $"list of sms retrieved successfully");
        }

        /// <summary>
        /// send sms
        /// </summary>
        /// <param name="model">the model</param>
        /// <returns>a result of send sms</returns>
        public async Task<Result<SmsModel>> EnvoyerSms(EnvoyerSmsModel model)
        {
            try
            {
                var message = new SendSMS()
                {
                    Message = model.Message,
                    Destinataires = model.NumeroTelephone.FormatPhoneNumberForFrance(),
                    Expediteur = "COMPANY",
                };

                var result = await _spotHitService.SendSms(message);

                if (!result.IsSuccess)
                {
                    _logger.LogError(
                        LogEvent.SpothitFailedSend,
                        null,
                        "an error occurred during send SMS with the given data [{data}] because [{errors}]",
                        model.ToJson(),
                        result.GetErrors().ToJson());

                    return Result<SmsModel>.Failed(null, null, "an error occurred during send SMS");
                }

                var sms = new Sms()
                {
                    ClientId = model.ClientId,
                    DossierId = model.DossierId,
                    Date = DateTime.Now,
                    ExternalId = result.Id,
                    IsBloquer = false,
                    NumeroTelephone = message.Destinataires,
                    Message = message.Message,
                    Type = Domain.Enums.General.SmsType.Envoyer,
                };

                await _dataAccess.AddAsync(sms);
                await _unitOfWork.SaveChangesAsync();

                return Result<SmsModel>.Success(_mapper.Map<SmsModel>(sms));
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    LogEvent.SpothitFailedSend,
                    ex,
                    "an error occurred during send SMS with the given data [{data}]",
                    model.ToJson());

                return Result<SmsModel>.Failed(null, ex, "an error occurred during send SMS");
            }
        }

        #region private methods

        private IDataRequest<Sms> BuildAsPagedDataRequest(SmsFilterOption filterOption)
        {
            var predicate = PredicateBuilder.True<Sms>()
                .And(e => e.Type == Domain.Enums.General.SmsType.Envoyer);

            if (filterOption.ClientId.IsValid())
                predicate = predicate.And(e => e.ClientId == filterOption.ClientId);

            if (filterOption.DossierId.IsValid())
                predicate = predicate.And(e => e.DossierId == filterOption.DossierId);

            return _requestBuilder
                .AddPredicate(predicate)
                .AddInclude(e => e.Include(d => d.Reponses))
                .AddOrderBy(SortDirection.Desc, e => e.Date)
                .Buil();
        }

        #endregion
    }
}
