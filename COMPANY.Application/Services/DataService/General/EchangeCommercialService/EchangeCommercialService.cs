namespace COMPANY.Application.Services.DataService.TacheService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.Data.Enums;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.General;
    using COMPANY.Application.Models.BusinessEntities.General.EchangeCommercial;
    using COMPANY.Application.Models.BusinessEntitiesModels.AddressModel;
    using COMPANY.Application.Models.General.GoogleCalendar;
    using COMPANY.Application.Models.GeneralModels.PagingModels;
    using COMPANY.Application.Services.Generals.GoogleCalendarService;
    using COMPANY.Common.Constants;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Domain.Enums.EchangeCommercial;
    using Company.AutoInjection.Attributes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// the implementation of the <see cref="IEchangeCommercialService"/>
    /// </summary>
    [Inject(typeof(IEchangeCommercialService), ServiceLifetime.Scoped)]
    public class EchangeCommercialService
        : BaseService<EchangeCommercial, string, EchangeCommercialModel, EchangeCommercialCreateModel, EchangeCommercialUpdateModel>, IEchangeCommercialService
    {
        private readonly IAccountDataAccess _accountDataAccess;
        private readonly IGoogleCalendarService _googleCalendarService;
        private readonly IDataAccess<GoogleCalendarEchangeCommercial, string> _googleCalendarDataAccess;
        private readonly IDataAccess<Client, string> _clientDataAccess;
        private readonly IClientService _clientService;
        private readonly IDataAccess<Dossier, string> _dossierDataAccess;

        public EchangeCommercialService(
            IDataRequestBuilder<EchangeCommercial> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IGoogleCalendarService googleCalendarService,
            IClientService clientService,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        {
            _accountDataAccess = unitOfWork.AccountDataAccess;
            _clientService = clientService;
            _dossierDataAccess = _unitOfWork.DataAccess<Dossier, string>();
            _googleCalendarService = googleCalendarService;
            _clientDataAccess = unitOfWork.DataAccess<Client, string>();
            _googleCalendarDataAccess = unitOfWork.DataAccess<GoogleCalendarEchangeCommercial, string>();
        }

        /// <summary>
        /// save the given memos to the commercial exchange memos list
        /// </summary>
        /// <param name="id">the id of the commercial exchange to save the memo for him</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>an operation result</returns>
        public async Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos)
        {
            var result = await GetEntityByIdAsync(id);
            result.Memos = memos;
            _dataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("updated successfully");
        }

        /// <summary>
        /// synchronization commercial exchanges with Google Calendar
        /// </summary>
        /// <returns></returns>
        public async Task<Result> SynchronizationWithGoogleCalendar()
        {
            var currentUser = await _accountDataAccess.GetUserByIdAsync(_user.Id);

            if (!currentUser.GoogleCalendarId.IsValid())
                return Result.Failed(
                    null,
                    "there is no Google calendar id in the current user",
                    MsgCode.NoCalendarIdGoogleCalendar.ToString());

            var echangesCommercial = await _dataAccess.GetAsync(GetPredicateCommercialsExchangeToSynchronize());

            var googleCalendarEvents = new List<GoogleCalendarEchangeCommercial>();

            foreach (var echangeCommercial in echangesCommercial)
            {
                // map commercial exchange to Google Calendar event model
                var googleEventModel = MapEchangeCommercialToGoogleCalendarEventModel(echangeCommercial);

                // add event to calendar
                var eventId = await _googleCalendarService.AddEvent(
                    currentUser.GoogleCalendarId,
                    googleEventModel
                );

                // if eventId ( id of event in Google Calendar ) different empty and null
                if (!string.IsNullOrEmpty(eventId))
                {
                    var googleCalendarCommercialExchange = new GoogleCalendarEchangeCommercial()
                    {
                        CalendarId = currentUser.GoogleCalendarId,
                        ExternalEventId = eventId,
                        EchangeCommercialId = echangeCommercial.Id,
                        UserId = _user.Id,
                    };

                    googleCalendarEvents.Add(googleCalendarCommercialExchange);
                }
            }

            if (googleCalendarEvents.Count() > 0)
                await _googleCalendarDataAccess.AddRangeAsync(googleCalendarEvents);

            return Result.Success("synchronize with success");
        }

        /// <summary>
        /// update date event
        /// </summary>
        /// <param name="changeDateEventModel"></param>
        /// <returns></returns>
        public async Task<Result> UpdateDateEvent(ChangeDateEventModel changeDateEventModel)
        {
            var echangeCommercial = await GetEntityByIdAsync(changeDateEventModel.Id);

            var dateEvent = changeDateEventModel.DateEvent.Date;

            if (changeDateEventModel.Time.HasValue)
                dateEvent += changeDateEventModel.Time.Value;
            else
                dateEvent += echangeCommercial.DateEvent.TimeOfDay;

            echangeCommercial.DateEvent = dateEvent;

            if (changeDateEventModel.Duree.HasValue)
                echangeCommercial.Duree = changeDateEventModel.Duree.Value;

            _dataAccess.Update(echangeCommercial);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Date event updated successfully");
        }

        /// <summary>
        /// check RDV is exist
        /// </summary>
        /// <param name="model">the model represent criteria</param>
        /// <returns>a bool result</returns>
        public async Task<Result<bool>> CheckRdvIsExist(CheckRdvIsExistModel model)
        {
            var predicate = PredicateBuilder.True<EchangeCommercial>()
                .And(e => e.ClientId == model.ClientId)
                .And(e => e.ResponsableId == model.ResponsableId);

            if (model.Time.HasValue)
                model.DateEvent += model.Time.Value;

            predicate = predicate.And(e => e.DateEvent.Date == model.DateEvent.Date);

            if (await _dataAccess.IsExistAsync(predicate))
                return Result<bool>.Success(true, "the RDV with given criteria already exist");

            return Result<bool>.Success(false, "the RDV with given criteria doesn't exist");
        }

        #region private methods

        /// <summary>
        /// create predicate commercials exchange to synchronize
        /// </summary>
        /// <returns></returns>
        private Expression<Func<EchangeCommercial, bool>> GetPredicateCommercialsExchangeToSynchronize()
        {
            var predicate = PredicateBuilder.True<EchangeCommercial>()
                .And(e => e.DateEvent.Date >= DateTime.Today.Date)
                .And(e => !e.GoogleCalendarEvents.Any(g => g.UserId == _user.Id));

            predicate = FilterBaseConnectedUser(predicate);

            return predicate;
        }

        /// <summary>
        /// filter base connected client
        /// </summary>
        private Expression<Func<EchangeCommercial, bool>> FilterBaseConnectedUser(Expression<Func<EchangeCommercial, bool>> predicate)
        {
            switch (_user.RoleId)
            {
                case UserRole.Admin:
                case UserRole.AdminAgence:
                    predicate = predicate
                        .And(e => e.AgenceId == _user.AgenceId);
                    break;
                case UserRole.Technicien:
                case UserRole.Commercial:
                case UserRole.Controleur:
                    predicate = predicate
                        .And(e => e.CreateurId == _user.Id);
                    break;
                case UserRole.Directeur:
                    predicate = predicate
                        .And(e => e.ResponsableId == _user.Id);
                    break;
            }

            return predicate;
        }

        /// <summary>
        /// Map Commercial Exchange To Google Calendar Event
        /// </summary>
        /// <param name="echangeCommercial">the commercial exchange</param>
        /// <returns></returns>
        private GoogleCalendarEvent MapEchangeCommercialToGoogleCalendarEventModel(EchangeCommercial echangeCommercial)
        {
            var address = string.Empty;

            if (echangeCommercial.Addresses != null && echangeCommercial.Addresses.Any())
                address = echangeCommercial.Addresses.FirstOrDefault().BuildAddressPhrase();

            var googleEventModel = new GoogleCalendarEvent()
            {
                Title = echangeCommercial.Titre,
                Body = echangeCommercial.Description,
                StartDate = echangeCommercial.DateEvent.Date,
                EndDate = echangeCommercial.DateEvent + echangeCommercial.Duree,
                Location = address,
            };

            return googleEventModel;
        }

        private ICollection<Address> UpdateAddressesClient(Client client, ICollection<AddressCreateModel> addresses)
        {
            if (addresses != null && addresses.Any())
            {
                var result = _clientService.AddAddressClient(client, addresses.ToList());

                if (result.Status == ResultStatus.Succeed)
                    return result.Value;
            }

            return _mapper.Map<ICollection<Address>>(addresses);
        }

        private ICollection<Contact> UpdateContactsClient(Client client, ICollection<ContactCreateModel> contacts)
        {
            if (contacts != null && contacts.Any())
            {
                var result = _clientService.AddContactsClient(client, contacts.ToList());

                if (result.Status == ResultStatus.Succeed)
                    return result.Value;
            }

            return _mapper.Map<ICollection<Contact>>(contacts);
        }

        #endregion

        #region overrides

        protected override Expression<Func<EchangeCommercial, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterModel)
        {
            var predicate = PredicateBuilder.True<EchangeCommercial>();

            if (filterModel is EchangeCommercialFilterOption filterOption)
            {
                if (filterOption.Type.HasValue)
                    predicate = predicate.And(c => c.Type == filterOption.Type.Value);

                if (filterOption.ClientId.IsValid())
                    predicate = predicate.And(c => c.ClientId == filterOption.ClientId);

                if (filterOption.DossierId.IsValid())
                    predicate = predicate.And(c => c.DossierId == filterOption.DossierId);

                if (filterOption.CategorieId.IsValid())
                    predicate = predicate.And(c => c.CategorieId == filterOption.CategorieId);

                if (filterOption.ResponsableId.IsValid())
                    predicate = predicate.And(c => c.ResponsableId == filterOption.ResponsableId);

                if (filterOption.DateFrom.HasValue)
                    predicate = predicate.And(c => filterOption.DateFrom.Value.Date <= c.DateEvent.Date);

                if (filterOption.DateTo.HasValue)
                    predicate = predicate.And(c => filterOption.DateTo.Value.Date >= c.DateEvent.Date);
            }

            predicate = FilterBaseConnectedUser(predicate);

            return predicate;
        }

        protected override Func<IQueryable<EchangeCommercial>, IIncludableQueryable<EchangeCommercial, object>> BuildIncludesList()
            => ec => ec.Include(e => e.Client)
            .Include(e => e.RdvType)
            .Include(e => e.TacheType)
            .Include(e => e.TypeAppel)
            .Include(e => e.Dossier)
            .Include(e => e.Responsable);

        protected override Func<IQueryable<EchangeCommercial>, IIncludableQueryable<EchangeCommercial, object>> BuildIncludesGetById()
            => ec => ec.Include(e => e.Client)
            .Include(e => e.Categorie)
            .Include(e => e.TacheType)
            .Include(e => e.TypeAppel)
            .Include(e => e.SourceRDV)
            .Include(e => e.Dossier)
            .Include(e => e.Responsable);

        protected override async Task BeforeAddEntity(EchangeCommercial entity, EchangeCommercialCreateModel model)
        {
            var client = await _clientDataAccess.GetAsync(model.ClientId);
            entity.Addresses = UpdateAddressesClient(client, model.Addresses);
            entity.Contacts = UpdateContactsClient(client, model.Contacts);

            entity.CreateurId = _user.Id;
        }

        protected override async Task BeforeUpdateEntity(EchangeCommercial entity, EchangeCommercialUpdateModel model)
        {
            var client = await _clientDataAccess.GetAsync(model.ClientId);
            entity.Addresses = UpdateAddressesClient(client, model.Addresses);
            entity.Contacts = UpdateContactsClient(client, model.Contacts);

        }

        protected override async Task AfterAddEntity(EchangeCommercial entity, EchangeCommercialCreateModel model)
        {
            if (model.Type == EchangeCommercialType.RDV && model.DossierId != null)
            {
                var dossier = await _dossierDataAccess.GetAsync(model.DossierId);
                if (dossier.Status == DossierStatus.EnAttente)
                {
                    dossier.Status = DossierStatus.Assigne;
                    dossier.CommercialId = model.ResponsableId;
                    dossier.DateRDV = model.DateEvent;
                    dossier.PremierRdvId = entity.Id;
                    _dossierDataAccess.Update(dossier);
                }
            }
        }
        #endregion
    }
}
