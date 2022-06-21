namespace COMPANY.Application.Services.Generals.SpotHitHooksService
{
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Tools;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities.Generals;
    using COMPANY.Helpers;
    using Inova.AutoInjection.Attributes;
    using Inova.SpotHit.Models;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    [Inject(typeof(ISpotHitHooksService), ServiceLifetime.Scoped)]
    public class SpotHitHooksService : ISpotHitHooksService
    {
        private readonly ILogger<SpotHitHooksService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataAccess<Sms, string> _dataAccess;

        public SpotHitHooksService(
            ILogger<SpotHitHooksService> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _dataAccess = unitOfWork.DataAccess<Sms, string>();
        }

        /// <summary>
        /// reveived response of sms in spothit
        /// </summary>
        /// <param name="response">the response detail</param>
        public async Task ReceptionResponse(PushResponse response)
        {
            try
            {
                if (response.Numero.IsValid())
                    return;

                var smsSource = await _dataAccess
                    .GetSingleAsync(e => e.ExternalId == response.Source && e.Type == Domain.Enums.General.SmsType.Envoyer);

                if (smsSource is null)
                    return;

                smsSource.AddResponse(
                    response.Date.UnixTimeStampToDateTime(),
                    response.Message,
                    response.Numero,
                    response.Id
                );

                _dataAccess.Update(smsSource);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    LogEvent.SpothitFailedSaveResponse,
                    ex,
                    "an error occurred during save response with the given response [{data}]",
                    response.ToJson());
            }
        }

        /// <summary>
        /// reveived stop of sms in spothit
        /// </summary>
        /// <param name="stop">the stop detail</param>
        public async Task ReceptionStop(PushStop stop)
        {
            try
            {
                if (stop.Numero.IsValid())
                    return;

                var smsSource = await _dataAccess
                    .GetSingleAsync(e => e.ExternalId == stop.SourceId && e.Type == Domain.Enums.General.SmsType.Envoyer);

                if (smsSource is null)
                    return;

                smsSource.IsBloquer = true;

                _dataAccess.Update(smsSource);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    LogEvent.SpothitFailedStopSms,
                    ex,
                    "an error occurred during block sms with the given information [{data}]",
                    stop.ToJson());
            }
        }
    }
}
