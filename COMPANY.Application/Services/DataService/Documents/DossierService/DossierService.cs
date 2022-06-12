namespace COMPANY.Application.Services.DataService.DossierService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.Data.Enums;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.General;
    using COMPANY.Application.Models.BusinessEntitiesModels.AddressModel;
    using COMPANY.Application.Models.General;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Application.Models.General.PushNotification;
    using COMPANY.Application.Models.Generals.Antsroute;
    using COMPANY.Application.Services.DataService.General.NotificationService;
    using COMPANY.Application.Services.DataService.NumerotationService;
    using COMPANY.Application.Services.Generals.AntsrouteService;
    using COMPANY.Application.Services.Generals.PushNotificationService;
    using COMPANY.Application.Tools;
    using COMPANY.Common.Constants;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Generals;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Domain.Enums.EchangeCommercial;
    using COMPANY.Domain.Enums.General;
    using Company.AutoInjection.Attributes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// the implementation of the <see cref="IDossierService"/>
    /// </summary>
    [Inject(typeof(IDossierService), ServiceLifetime.Scoped)]
    public class DossierService :
        BaseService<Dossier, string, DossierModel, DossierCreateModel, DossierUpdateModel>, IDossierService
    {
        private readonly IClientService _clientService;
        private readonly IPushNotificationService _pushNotificationService;
        private readonly INotificationService _notificationService;
        private readonly IAntsrouteService _antsrouteService;
        private readonly ILogger<DossierService> _logger;
        private readonly INumerotationService _numerotationService;
        private readonly IDataAccess<Devis, string> _devisDataAccess;
        private readonly IDataAccess<Client, string> _clientDataAccess;
        private readonly IDataAccess<EchangeCommercial, string> _echangeCommercialDataAccess;
        private readonly IDataAccess<User, string> _accountDataAccess;
        private readonly IDataAccess<DossierInstallation, string> _dossierInstallationDataAccess;

        public DossierService(
          IDataRequestBuilder<Dossier> requestBuilder,
          IUnitOfWork unitOfWork,
          IMapper mapper,
          ICurrentUserService currentUserService,
          INumerotationService numerotationService,
          IClientService clientService,
          IPushNotificationService pushNotificationService,
          INotificationService notificationService,
          IAntsrouteService antsrouteService,
          ILogger<DossierService> logger
        ) : base(requestBuilder, unitOfWork, mapper, currentUserService)
        {
            _numerotationService = numerotationService;
            _clientService = clientService;
            _pushNotificationService = pushNotificationService;
            _notificationService = notificationService;
            _antsrouteService = antsrouteService;
            _logger = logger;
            _devisDataAccess = unitOfWork.DataAccess<Devis, string>();
            _clientDataAccess = unitOfWork.DataAccess<Client, string>();
            _echangeCommercialDataAccess = unitOfWork.DataAccess<EchangeCommercial, string>();
            _accountDataAccess = unitOfWork.DataAccess<User, string>();
            _dossierInstallationDataAccess = unitOfWork.DataAccess<DossierInstallation, string>();
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

        /// <summary>
        /// save the given memos to the dossier memos list
        /// </summary>
        /// <param name="id">the id of the dossier to save the memo for him</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>an operation result</returns>
        public async Task<Result> SaveMemosDossierAsync(string id, ICollection<MemoDossier> memos)
        {
            var result = await GetEntityByIdAsync(id);
            result.Memos = memos;
            _dataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("updated successfully");
        }

        /// <summary>
        /// save the given viste technique to the dossier
        /// </summary>
        /// <param name="id">the id of the dossier to save the viste technique for him</param>
        /// <param name="visteTechnique">the viste technique to be saved</param>
        /// <returns>an operation result</returns>
        public async Task<Result> SaveVisteTechnique(string id, VisteTechnique visteTechnique)
        {
            var result = await GetEntityByIdAsync(id);
            result.VisteTechnique = visteTechnique;
            _dataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("updated successfully");
        }

        /// <summary>
        /// get articles of dossier
        /// </summary>
        /// <param name="dossierId">the id of dossier</param>
        /// <returns>a list of articles</returns>
        public async Task<Result<List<Article>>> GetDossierArticles(string dossierId)
        {
            var devis = await _devisDataAccess.GetAsync(e => e.DossierId == dossierId);

            if (devis is null)
                return Result<List<Article>>.Failed(null, null, "Failed to retrieve list of dossier");

            var articles = devis
                .SelectMany(e => e.Articles)
                .Where(e => e.Type == ArticleType.Produit)
                .ToList();

            return Result<List<Article>>.Success(articles);
        }

        /// <summary>
        /// check user already assigned to another dossier in the same date and hour
        /// </summary>
        /// <returns>a boolean</returns>
        public async Task<Result<bool>> CheckUserAssignedSameDateAndHour(CheckUserAssignedSameDateAndHourFilterOption filterOption)
        {
            var predicate = PredicateBuilder.True<Dossier>()
                .And(e => e.CommercialId.IsValid() && e.CommercialId == filterOption.UserId)
                .And(e => e.DateRDV.HasValue && e.DateRDV.Value.Date == filterOption.DateRdv.Date && e.DateRDV.Value.Hour == filterOption.DateRdv.Hour);

            if (filterOption.ExcludeDossierId.IsValid())
                predicate = predicate.And(e => e.Id != filterOption.ExcludeDossierId);

            var result = (await _dataAccess.GetCountAsync(predicate)) > 0;

            return Result<bool>.Success(result);
        }

        /// <summary>
        /// mark dossier à planifier
        /// </summary>
        /// <param name="dossierId">the id of dossier</param>
        /// <returns>a result instance</returns>
        public async Task<Result> MarkDossierAplanifier(string dossierId)
        {
            var request = _dataRequestBuilder
                .AddInclude(e => e.Include(d => d.Client))
                .Buil();

            var dossier = await _dataAccess.GetAsync(dossierId, request);

            if (dossier.Status != DossierStatus.Signe)
                throw new UnAcceptableRequestException("the dossier does not have signed status", MsgCode.DossierDoesNotHaveStatusSigned);

            var order = new BasketOrderCreateModel(dossier);

            var result = await _antsrouteService.CreateOrder(order);

            if (result.IsSuccess)
            {
                dossier.AntsrouteOrderId = result.Value.Id;
                dossier.Status = DossierStatus.Aplanifie;
                _dataAccess.Update(dossier);
                await _unitOfWork.SaveChangesAsync();
                return Result.Success("");
            }
            else
            {
                return Result.Failed(
                    result.Error,
                    "Failed to create order in antsroute",
                    MsgCode.ErrorCreateOrderInAntsroute.ToString());

            }
        }

        /// <summary>
        /// synchronize order of ansroute with our dossier
        /// </summary>
        /// <returns></returns>
        public async Task<Result<DossierModel>> SynchronizeWithAntsroute(string dossierId)
        {
            var request = _dataRequestBuilder
                .AddInclude(e => e.Include(d => d.DossierInstallations))
                .Buil();

            var dossier = await _dataAccess.GetAsync(dossierId, request);

            if (dossier is null)
                throw new NotFoundException("there isn't dossier with the given id");

            if (!dossier.AntsrouteOrderId.IsValid())
                throw new UnAcceptableRequestException($"you must have status unplanned to synchronize");

            var result = await _antsrouteService.GetOrder(dossier.AntsrouteOrderId);

            if (result.IsSuccess && result.Value.ScheduledDate.HasValue && result.Value.AffectedAgent.IsValid())
            {
                var order = result.Value;
                var agent = await _accountDataAccess
                    .GetSingleAsync(e => e.Email == order.AffectedAgent);

                if (agent is null)
                {
                    _logger.LogError(LogEvent.AntsrouteEmailNotExistsInSystem, $"the email of agent {order.AffectedAgent} doesn't exist in out system");
                    throw new UnAcceptableRequestException($"the email of agent {order.AffectedAgent} doesn't exist in out system");
                }

                var dateEvent = order.ScheduledDate.Value;
                if (order.EstimatedTimeOfArrival.HasValue)
                    dateEvent = dateEvent.Date + order.EstimatedTimeOfArrival.Value;

                await AddInstallationDossier(dossier, dateEvent, agent.Id);
                dossier.Status = DossierStatus.Planifie;
                _dataAccess.Update(dossier);

                await _unitOfWork.SaveChangesAsync();
            }

            return await GetByIdAsync(dossierId);
        }

        /// <summary>
        /// synchronize orders of ansroute with our dossiers
        /// </summary>
        /// <returns></returns>
        public async Task<Result> SynchronizeWithAntsroute()
        {
            var request = _dataRequestBuilder
                .AddPredicate(e => (e.Status == DossierStatus.Aplanifie || e.Status == DossierStatus.Planifie) && e.AntsrouteOrderId.IsValid())
                .AddInclude(e => e.Include(d => d.DossierInstallations))
                .Buil();

            var dossiers = await _dataAccess.GetAsync(request);

            if (dossiers.Count() == 0)
                return Result.Success("all dossiers already synchronized");

            var agencesDossiers = dossiers.Select(e => e.AgenceId).Distinct();

            var techniciens = await _accountDataAccess
                .GetAsync(e => e.RoleId == (int)UserRole.Technicien && agencesDossiers.Contains(e.AgenceId));

            foreach (var dossier in dossiers)
            {
                var result = await _antsrouteService.GetOrder(dossier.AntsrouteOrderId);

                if (result.IsSuccess && result.Value.ScheduledDate.HasValue && result.Value.AffectedAgent.IsValid())
                {
                    var order = result.Value;
                    var agent = techniciens.FirstOrDefault(e => e.Email == order.AffectedAgent);

                    if (agent is null)
                    {
                        _logger.LogError(LogEvent.AntsrouteEmailNotExistsInSystem, $"the email of agent {order.AffectedAgent} doesn't exist in out system");
                        continue;
                    }

                    var dateEvent = order.ScheduledDate.Value;
                    if (order.EstimatedTimeOfArrival.HasValue)
                        dateEvent = dateEvent.Date + order.EstimatedTimeOfArrival.Value;

                    await AddInstallationDossier(dossier, dateEvent, agent.Id);
                    dossier.Status = DossierStatus.Planifie;
                    _dataAccess.Update(dossier);
                }
            }

            await _unitOfWork.SaveChangesAsync();
            return Result.Success("all dossiers synchronized successfully");
        }

        #region private methods

        /// <summary>
        /// mapping documents associated with dossier
        /// </summary>
        /// <param name="dossier">the given dossier</param>
        /// <returns>List of documents associates</returns>
        private IEnumerable<DocumentAssociate> MapDocumentAssociate(Dossier dossier)
        {
            var documentsAssocies = dossier.Devis.Select(e => new DocumentAssociate()
            {
                Id = e.Id,
                Reference = e.Reference,
                CreateOn = e.CreatedOn.DateTime,
                Type = DocType.Devis,
                Status = (int)e.Status,
                TotalTTC = e.TotalTTC
            }).Concat(
                dossier.Devis.SelectMany(e => e.Factures).Select(e => new DocumentAssociate()
                {
                    Id = e.Facture.Id,
                    Reference = e.Facture.Reference,
                    CreateOn = e.Facture.DateCreation,
                    Type = DocType.Facture,
                    Status = (int)e.Facture.Status,
                    TotalTTC = e.Facture.TotalTTC
                })
            ).Concat(
                dossier.BonsCommandes.Select(e => new DocumentAssociate()
                {
                    Id = e.Id,
                    Reference = e.Reference,
                    CreateOn = e.CreatedOn.DateTime,
                    Type = DocType.BonCommande,
                    Status = (int)e.Status,
                    TotalTTC = e.TotalTTC
                })
            );

            return documentsAssocies;
        }

        /// <summary>
        /// notify commercial that has a new dossier assigned
        /// </summary>
        /// <param name="dossier">the dossier</param>
        /// <param name="commercialId">the id of commercial</param>
        private async Task NotifyCommercialAssigned(Dossier dossier, string commercialId)
        {
            var notificationParameters = new SendPushNotificationParameters()
            {
                UserIds = new List<string>() {
                    commercialId.ToString()
                },
                Notification = new PushNotification()
                {
                    Heading = $"Dossiers",
                    Content = $"Un nouveau dossier {dossier.Reference} assigné",
                    Data = new
                    {
                        DemandeRdvId = dossier.Id
                    }
                }
            };

            await _pushNotificationService.SendNotificationAsync(notificationParameters);
        }

        /// <summary>
        /// add notifications of change status
        /// </summary>
        /// <param name="dossier">the dossier</param>
        /// <param name="oldStatus">the old status</param>
        /// <param name="newStatus">the new status</param>
        private async Task NotificationChangeStatus(Dossier dossier, DossierStatus oldStatus, DossierStatus newStatus)
        {
            var predicate = PredicateBuilder.True<User>();

            if (_user.IsFollowAgence)
                predicate = predicate.And(e => e.RoleId == (int)UserRole.AdminAgence);
            else
                predicate = predicate.And(e => e.RoleId == (int)UserRole.Admin);

            var notifications = (await _accountDataAccess.GetAsync(predicate))
                .Select(e => new Notification(
                    title: $"Le statut du dossier {dossier.Reference} est passé de {oldStatus.DescriptionAttribute()} " +
                    $"à {newStatus.DescriptionAttribute()}",
                    docType: DocType.Dossier,
                    identityDocument: dossier.Id,
                    userId: e.Id
                ));

            await _notificationService.AddNotifications(notifications);
        }

        /// <summary>
        /// add first appointement
        /// </summary>
        /// <param name="entity">the dossier entity</param>
        private async Task AddPremierRdv(Dossier entity)
        {
            var client = await _clientDataAccess.GetAsync(entity.ClientId);

            var premierRdv = new EchangeCommercial()
            {
                ClientId = entity.ClientId,
                Description = entity.Note,
                ResponsableId = entity.CommercialId,
                DateEvent = entity.DateRDV.Value,
                Titre = $"RDV {client.LastName} {client.FirstName}",
                Type = EchangeCommercialType.RDV,
                DossierId = entity.Id,
                Status = EchangeCommercialStatus.EnCours,
                AgenceId = entity.AgenceId,
            };

            if (entity.SiteIntervention != null)
                premierRdv.Addresses.Add(entity.SiteIntervention);

            premierRdv.PremiersRdvsDossiers.Add(entity);

            await _echangeCommercialDataAccess.AddAsync(premierRdv);
        }

        /// <summary>
        /// update first rdv
        /// </summary>
        /// <param name="echangeCommercialId">the id of exchange commercial</param>
        /// <param name="dossier">the dossier entity</param>
        private async Task UpdatePremierRdv(string echangeCommercialId, DossierUpdateModel dossier)
        {
            var echangeCommercial = await _echangeCommercialDataAccess.GetAsync(echangeCommercialId);
            if (echangeCommercial.Status == EchangeCommercialStatus.EnCours)
            {
                echangeCommercial.ResponsableId = dossier.CommercialId;
                echangeCommercial.DateEvent = dossier.DateRDV.Value;
                _echangeCommercialDataAccess.Update(echangeCommercial);
            }
        }

        /// <summary>
        /// update addresses of a client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="siteIntervention"></param>
        /// <returns></returns>
        private Address UpdateAddressesClient(Client client, AddressCreateModel siteIntervention)
        {
            if (siteIntervention != null)
            {
                var addresses = new List<AddressCreateModel>()
                {
                    siteIntervention
                };
                var result = _clientService.AddAddressClient(client, addresses);

                if (result.Status == ResultStatus.Succeed)
                    return result.Value.First();
            }

            return _mapper.Map<Address>(siteIntervention);
        }

        /// <summary>
        /// update contacts of a client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        private Contact UpdateContactsClient(Client client, ContactCreateModel contact)
        {
            if (contact != null)
            {
                var contacts = new List<ContactCreateModel>()
                {
                    contact
                };
                var result = _clientService.AddContactsClient(client, contacts);

                if (result.Status == ResultStatus.Succeed)
                    return result.Value.First();
            }

            return _mapper.Map<Contact>(contact);
        }

        public async Task AddInstallationDossier(Dossier dossier, DateTime dateDebutTravaux, string technicienId)
        {
            if (dossier.DossierInstallations.Any(e => e.TechnicienId == technicienId && e.DateDebutTravaux == dateDebutTravaux))
                return;

            var dossierInstallation = dossier.DossierInstallations.FirstOrDefault(e => e.TechnicienId == technicienId);

            if (dossierInstallation is null)
                await _dossierInstallationDataAccess.AddAsync(new DossierInstallation()
                {
                    DateDebutTravaux = dateDebutTravaux,
                    TechnicienId = technicienId,
                    DossierId = dossier.Id
                });
            else
            {
                dossierInstallation.TechnicienId = technicienId;
                dossierInstallation.DateDebutTravaux = dateDebutTravaux;
                _dossierInstallationDataAccess.Update(dossierInstallation);
            }
        }

        #endregion

        #region overrides

        protected override async Task BeforeAddEntity(Dossier entity, DossierCreateModel model)
        {
            var client = await _clientDataAccess.GetAsync(model.ClientId);
            entity.SiteIntervention = UpdateAddressesClient(client, model.SiteIntervention);
            entity.Contact = UpdateContactsClient(client, model.Contact);

            _clientService.EditClientChampsAsDossier(client, model);
        }

        protected override async Task AfterAddEntity(Dossier entity, DossierCreateModel model)
        {
            var client = _clientService.GetByIdAsync(model.ClientId);
            if (client.Result.Value.IsSousTraitant)
                await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.SousTraitant);
            else
                await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.Dossier);

            if (model.PremierRdvId.IsValid())
            {
                var premierRDV = await _echangeCommercialDataAccess.GetAsync(model.PremierRdvId);
                premierRDV.DossierId = entity.Id;
                _echangeCommercialDataAccess.Update(premierRDV);
            }
        }

        protected override async Task AfterSaveChangesAddEntity(Dossier entity, DossierCreateModel model)
        {
            if (model.Status == DossierStatus.Assigne && !model.PremierRdvId.IsValid())
                await AddPremierRdv(entity);

            await _unitOfWork.SaveChangesAsync();
        }

        protected override Expression<Func<Dossier, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterModel)
        {
            var predicate = CommunListPredicate();

            if (filterModel is DossierFilterOption filterOption)
            {
                if (filterOption.ClientId.IsValid())
                    predicate = predicate.And(e => e.ClientId == filterOption.ClientId);

                if (filterOption.DateRdvFrom.HasValue)
                    predicate = predicate.And(e => e.DateRDV.HasValue && e.DateRDV.Value.Date >= filterOption.DateRdvFrom.Value.Date);

                if (filterOption.DateRdvTo.HasValue)
                    predicate = predicate.And(e => e.DateRDV.HasValue && e.DateRDV.Value.Date <= filterOption.DateRdvTo.Value.Date);

                if (filterOption.Status.HasValue)
                    predicate = predicate.And(e => e.Status == filterOption.Status.Value);
            }

            return predicate;
        }

        protected override Expression<Func<Dossier, bool>> BuildGetListPredicate()
            => CommunListPredicate();

        private Expression<Func<Dossier, bool>> CommunListPredicate()
        {
            var predicate = PredicateBuilder.True<Dossier>();

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            switch (_user.RoleId)
            {
                case UserRole.Technicien:
                    predicate = predicate.And(c => c.CommercialId == _user.Id);
                    break;

                case UserRole.Commercial:
                    predicate = predicate.And(c => c.CommercialId == _user.Id);
                    break;
            }

            return predicate;
        }

        protected override Func<IQueryable<Dossier>, IIncludableQueryable<Dossier, object>> BuildIncludesList()
            => e => e.Include(d => d.Client).Include(d => d.Commercial).Include(d => d.DossierInstallations).ThenInclude(d => d.Technicien);

        protected override Func<IQueryable<Dossier>, IIncludableQueryable<Dossier, object>> BuildIncludesGetById()
            => d => d.Include(e => e.Client)
            .Include(e => e.PVs).ThenInclude(e => e.FicheControle).ThenInclude(e => e.Controller)
            .Include(e => e.DossierInstallations).ThenInclude(e => e.Technicien)
            .Include(e => e.Devis).ThenInclude(e => e.Factures).ThenInclude(e => e.Facture)
            .Include(e => e.Commercial)
            .Include(e => e.PrimeCEE)
            .Include(e => e.PremierRdv)
            .Include(e => e.BonsCommandes);

        protected override Task AfterGetByIdEntity(Dossier entity, DossierModel model)
        {
            model.DocumentAssociates = MapDocumentAssociate(entity);
            return base.AfterGetByIdEntity(entity, model);
        }

        protected override async Task BeforeUpdateEntity(Dossier entity, DossierUpdateModel model)
        {
            var client = await _clientDataAccess.GetAsync(model.ClientId);
            entity.SiteIntervention = UpdateAddressesClient(client, model.SiteIntervention);
            entity.Contact = UpdateContactsClient(client, model.Contact);

            if (entity.Status != DossierStatus.Assigne && model.Status == DossierStatus.Assigne)
                await NotifyCommercialAssigned(entity, model.CommercialId);

            if (entity.Status != model.Status)
                await NotificationChangeStatus(entity, entity.Status, model.Status);

            _clientService.EditClientChampsAsDossier(client, model);

            if (entity.PremierRdvId.IsValid() && entity.Status == DossierStatus.Assigne)
                await UpdatePremierRdv(entity.PremierRdvId, model);
        }

        protected override async Task AfterUpdateEntity(Dossier entity, DossierUpdateModel model)
        {
            if (!entity.PremierRdvId.IsValid() && entity.CommercialId.IsValid())
                await AddPremierRdv(entity);


        }

        protected override async Task AfterDeleteEntity(Dossier entity)
        {
            if (entity.AntsrouteOrderId.IsValid())
                await _antsrouteService.DeleteOrder(entity.AntsrouteOrderId);
        }

        #endregion
    }
}
