namespace COMPANY.Application.Services.DataService.Documents.BonCommandeService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.Data.Enums;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Documents.BonCommande;
    using COMPANY.Application.Models.BusinessEntitiesModels.AddressModel;
    using COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Models.General;
    using COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels;
    using COMPANY.Application.Models.GeneralModels.MailModels;
    using COMPANY.Application.Models.Generals.FilterOptions;
    using COMPANY.Application.Services.DataService.NumerotationService;
    using COMPANY.Application.Services.MailService;
    using COMPANY.Application.Services.PdfGenerateService;
    using COMPANY.Common.Constants;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Domain.Enums.Documents;
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

    [Inject(typeof(IBonCommandeService), ServiceLifetime.Scoped)]
    public class BonCommandeService :
        BaseService<BonCommande, string, BonCommandeModel, BonCommandeCreateModel, BonCommandeUpdateModel>,
        IBonCommandeService
    {
        private readonly IPdfGenerateService _pdfGenerateService;
        private readonly IMailService _mailService;
        private readonly IClientService _clientService;
        private readonly INumerotationService _numerotationService;
        private readonly ILogger<BonCommandeService> _logger;
        private readonly IDocumentParametersDataAccess _documentParametersDataAccess;
        private readonly IDataAccess<Dossier, string> _dossierDataAccess;
        private readonly IConfigMessagerieDataAccess _configMessagerieDataAccess;
        private readonly IDataAccess<Client, string> _clientDataAcces;

        public BonCommandeService(
            IDataRequestBuilder<BonCommande> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser,
            IPdfGenerateService pdfGenerateService,
            IMailService mailService,
            IClientService clientService,
            INumerotationService numerotationService,
            ILogger<BonCommandeService> logger) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        {
            _pdfGenerateService = pdfGenerateService;
            _mailService = mailService;
            _clientService = clientService;
            _numerotationService = numerotationService;
            _logger = logger;
            _documentParametersDataAccess = unitOfWork.DocumentParametersDataAccess;
            _dossierDataAccess = _unitOfWork.DataAccess<Dossier, string>();
            _configMessagerieDataAccess = unitOfWork.ConfigMessagerieDataAccess;
            _clientDataAcces = unitOfWork.DataAccess<Client, string>();
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
        /// generate example bon commande
        /// </summary>
        /// <param name="documentParameters">the parameters of document</param>
        /// <returns>a pdf result</returns>
        public Result<byte[]> ExampleParametersModel(DocumentParametersModel documentParameters)
        {
            try
            {
                // devis parameter
                var devisParameter = documentParameters.BonCommande;

                var addresses = new Address[] { new Address(){
                    Adresse = "107  rue Ernest Renan",
                    ComplementAdresse = string.Empty,
                    CodePostal = "49300",
                    Departement = "Pays de la Loire",
                    Pays = "France",
                    IsDefault = true,
                    Ville = "CHOLET"
                }};

                // create instance of devis
                var devis = new BonCommande()
                {
                    Client = new Client()
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Reference = "CL0001",
                        Addresses = addresses
                    },
                    ClientId = "Client::1",
                    Reference = "DV001",
                    TotalHT = (decimal)14.25,
                    TotalReduction = 2,
                    TotalTTC = 17,
                    TotalPaid = 15,
                    CreatedOn = DateTime.Now,
                    DateVisit = DateTime.Now.AddDays(30),
                    Note = devisParameter.Note ?? "",
                    SiteIntervention = addresses.First(),
                    User = new User()
                    {
                        FirstName = "John",
                        LastName = "Doe"
                    }
                };

                // generate PDF
                var pdfResult = _pdfGenerateService.GenerateBonComandePDF(devis, devisParameter);

                return Result<byte[]>.Success(pdfResult, "the PDF created successful");
            }
            catch (Exception ex)
            {
                return Result<byte[]>.Failed(null, ex, "Failed generating the PDF, an exception has been thrown");
            }
        }

        /// <summary>
        /// generate PDF of bon commande
        /// </summary>
        /// <param name="bonCommandeId">the bon commande id</param>
        /// <returns>a result of byte</returns>
        public async Task<Result<byte[]>> GeneratePdf(string bonCommandeId)
        {
            try
            {
                var result = await GetEntityByIdAsyncWithRelatedEntity(bonCommandeId);
                var resultParameter = await _documentParametersDataAccess.GetByAgenceIdAsync(_user.AgenceId);
                var pdfResult = _pdfGenerateService.GenerateBonComandePDF(result, resultParameter.BonCommande);
                return Result<byte[]>.Success(pdfResult);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error generate PDF bon commande id:({id})", bonCommandeId);
                return Result<byte[]>.Failed(null, exception, "Error generate PDF  bon commande");
            }
        }

        /// <summary>
        /// send bon commande in email
        /// </summary>
        /// <param name="bonCommandeId">the id of bon commande</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns>a instance of result</returns>
        public async Task<Result<ICollection<MailHistoryModel>>> SendInEmail(string bonCommandeId, MailModel mailModel)
        {
            var configMail = await _configMessagerieDataAccess.GetConfigMessagerieByAgenceIdAsync(_user.AgenceId);

            if (configMail is null)
                throw new NotFoundException("there is not configuration for messagerie", MsgCode.NoConfigMessagerie);

            // get devis by id 
            var bonCommande = await GetEntityByIdAsyncWithRelatedEntity(bonCommandeId);

            // get parameter document
            var parameterDocument = await _documentParametersDataAccess.GetByAgenceIdAsync(_user.AgenceId);

            // devis parameter
            var devisParameter = parameterDocument.BonCommande;

            // generate PDF
            var pdfResult = _pdfGenerateService.GenerateBonComandePDF(bonCommande, devisParameter);

            // build mail params model
            var mailParams = new MailParamsModel()
            {
                Attachments = new List<AttachmentModel>() { new AttachmentModel() { File = pdfResult, Name = $"{bonCommande.Reference}.pdf" } },
                BCC = new List<string>(),
                CC = new List<string>(),
                Content = mailModel.Body,
                MessageTo = mailModel.EmailTo.ToList(),
                Subject = mailModel.Subject
            };

            // send email
            await _mailService.SendEmail(mailParams, _mapper.Map<ConfigMessagerieModel>(configMail));

            // update email 
            await UpdateEmailField(bonCommande, mailModel);

            return Result<ICollection<MailHistoryModel>>.Success(bonCommande.Emails);
        }

        #region private methods

        /// <summary>
        /// update email field of devis
        /// </summary>
        /// <param name="devis">the facture of</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns></returns>
        private async Task UpdateEmailField(BonCommande bonCommande, MailModel mailModel)
        {
            // the list of emails
            var emails = bonCommande.Emails;

            // check is emails is null
            if (emails is null)
                emails = new List<MailHistoryModel>();

            // build a mail history model
            var mailHistoryModel = new MailHistoryModel()
            {
                Body = mailModel.Body,
                DateCreation = DateTime.Now,
                Subject = mailModel.Subject,
                UserId = _user.Id,
                EmailTo = mailModel.EmailTo
            };

            // push a mail history model
            emails.Add(mailHistoryModel);

            // serialize object
            bonCommande.Emails = emails;

            // update facture
            _dataAccess.Update(bonCommande);
            await _unitOfWork.SaveChangesAsync();
        }

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
        private async Task MarkDossierChiffre(BonCommandeCreateModel bonCommande)
        {
            var countDevisAssociateWithBonCommande = await _dataAccess.GetCountAsync(e => e.DossierId == bonCommande.DossierId);
            if (countDevisAssociateWithBonCommande == 0)
            {
                var dossier = await _dossierDataAccess.GetAsync(bonCommande.DossierId);
                dossier.Status = DossierStatus.Chiffre;
                _dossierDataAccess.Update(dossier);
            }
        }
        private async Task MarkDossierSigne(BonCommandeCreateModel bonCommande)
        {
            var countDevisAssociateWithBonCommande = await _dataAccess.GetCountAsync(e => e.DossierId == bonCommande.DossierId);
            if (countDevisAssociateWithBonCommande == 0)
            {
                var dossier = await _dossierDataAccess.GetAsync(bonCommande.DossierId);
                dossier.Status = DossierStatus.Signe;
                _dossierDataAccess.Update(dossier);
            }
        }
        #endregion

        #region overrides

        protected override async Task BeforeAddEntity(BonCommande entity, BonCommandeCreateModel model)
        {
            var client = await _clientDataAcces.GetAsync(model.ClientId);
            entity.SiteIntervention = UpdateAddressesClient(client, model.SiteIntervention);

            if (model.Signe.IsValid() && (entity.Status != BonCommandeStatus.Signe || entity.Status != BonCommandeStatus.Commande))
            {
                model.Status = BonCommandeStatus.Signe;
                entity.Status = BonCommandeStatus.Signe;
                if(model.DossierId.IsValid())
                    await MarkDossierSigne(model);
            }
            if (model.DossierId.IsValid() && !model.Signe.IsValid())
                await MarkDossierChiffre(model);
        }

        protected override async Task AfterAddEntity(BonCommande entity, BonCommandeCreateModel model)
            => await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.BonCommande);

        protected override async Task BeforeUpdateEntity(BonCommande entity, BonCommandeUpdateModel model)
        {
            var client = await _clientDataAcces.GetAsync(model.ClientId);
            entity.SiteIntervention = UpdateAddressesClient(client, model.SiteIntervention);

            if (model.Signe.IsValid() && (entity.Status != BonCommandeStatus.Signe || entity.Status != BonCommandeStatus.Commande))
            {
                entity.Status = BonCommandeStatus.Signe;
                await MarkDossierSigne(model);
            }
        }

        protected override Task AfterGetByIdEntity(BonCommande entity, BonCommandeModel model)
        {
            if (entity.Devis != null)
                model.DocumentAssociates.Add(new DocumentAssociate
                {
                    Id = entity.Devis.Id,
                    CreateOn = entity.Devis.CreatedOn.Date,
                    Reference = entity.Devis.Reference,
                    Type = DocType.Devis,
                    Status = (int)entity.Devis.Status,
                    TotalTTC = entity.Devis.TotalTTC,
                });

            if (entity.Dossier != null)
                model.DocumentAssociates.Add(new DocumentAssociate
                {
                    Id = entity.Dossier.Id,
                    CreateOn = entity.Dossier.CreatedOn.Date,
                    Reference = entity.Dossier.Reference,
                    Type = DocType.Dossier,
                    Status = (int)entity.Dossier.Status,
                    TotalTTC = 0,
                });

            return base.AfterGetByIdEntity(entity, model);
        }

        protected override Expression<Func<BonCommande, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterModel)
        {
            var predicate = CommunListPredicate();

            if (filterModel is BonCommandeFilterOption filterOption)
            {
                if (filterOption.Status.HasValue)
                    predicate = predicate.And(c => c.Status == filterOption.Status.Value);
            }
            return predicate;
        }

        protected override Expression<Func<BonCommande, bool>> BuildGetListPredicate()
            => CommunListPredicate();

        private Expression<Func<BonCommande, bool>> CommunListPredicate()
        {
            var predicate = PredicateBuilder.True<BonCommande>();

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            switch (_user.RoleId)
            {
                case UserRole.Technicien:
                    predicate = predicate.And(c => c.UserId == _user.Id);
                    break;
                case UserRole.Commercial:
                    predicate = predicate.And(c => c.UserId == _user.Id);
                    break;
            }

            return predicate;
        }

        protected override Func<IQueryable<BonCommande>, IIncludableQueryable<BonCommande, object>> BuildIncludesList()
            => e => e.Include(d => d.Client);

        protected override Func<IQueryable<BonCommande>, IIncludableQueryable<BonCommande, object>> BuildIncludesGetById()
             => e => e.Include(d => d.Client)
                    .Include(d => d.User)
                    .Include(d => d.Devis)
                    .Include(d => d.Dossier).ThenInclude(d => d.PrimeCEE);

        #endregion

    }
}
