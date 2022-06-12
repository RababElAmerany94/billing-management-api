namespace COMPANY.Application.Services.DataService.DevisService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.Data.Enums;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Documents.Devis;
    using COMPANY.Application.Models.BusinessEntitiesModels.AddressModel;
    using COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.Documents.Devis;
    using COMPANY.Application.Models.General;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels;
    using COMPANY.Application.Models.GeneralModels.MailModels;
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

    /// <summary>
    /// the implementation of the <see cref="IDevisService"/>
    /// </summary>
    [Inject(typeof(IDevisService), ServiceLifetime.Scoped)]
    public class DevisService : BaseService<Devis, string, DevisModel, DevisCreateModel, DevisUpdateModel>, IDevisService
    {
        private readonly IClientService _clientService;
        private readonly IDocumentParametersDataAccess _documentParametersDataAccess;
        private readonly ILogger<DevisService> _logger;
        private readonly IPdfGenerateService _pdfGenerateService;
        private readonly IConfigMessagerieDataAccess _configMessagerieDataAccess;
        private readonly IMailService _mailService;
        private readonly INumerotationService _numerotationService;
        private readonly IDataAccess<Dossier, string> _dossierDataAccess;
        private readonly IDataAccess<Client, string> _clientDataAcces;
        private readonly IDataAccess<BonCommande, string> _bonCommandeDataAcces;

        public DevisService(
            IDataRequestBuilder<Devis> requestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUserService,
            INumerotationService numerotationService,
            IClientService clientService,
            IPdfGenerateService pdfGenerateService,
            IMailService mailService,
            ILogger<DevisService> logger) : base(requestBuilder, unitOfWork, mapper, currentUserService)
        {
            _documentParametersDataAccess = _unitOfWork.DocumentParametersDataAccess;
            _configMessagerieDataAccess = _unitOfWork.ConfigMessagerieDataAccess;
            _dossierDataAccess = _unitOfWork.DataAccess<Dossier, string>();
            _clientDataAcces = unitOfWork.DataAccess<Client, string>();
            _bonCommandeDataAcces = unitOfWork.DataAccess<BonCommande, string>();
            _numerotationService = numerotationService;
            _clientService = clientService;
            _pdfGenerateService = pdfGenerateService;
            _mailService = mailService;
            _logger = logger;
        }

        /// <summary>
        /// check unique reference
        /// </summary>
        /// <param name="reference">the given reference</param>
        /// <returns>a boolean result</returns>
        public async Task<Result<bool>> CheckUniqueReferenceAsync(string reference)
        {
            var result = await _dataAccess.IsExistAsync(c => c.Reference == reference && c.AgenceId == _user.AgenceId);
            return Result<bool>.Success(!result);
        }

        /// <summary>
        /// generate PDF of devis
        /// </summary>
        /// <param name="devisId">the devis id</param>
        /// <returns>a result of byte</returns>
        public async Task<Result<byte[]>> GeneratePDFDevis(string devisId)
        {
            try
            {
                var result = await GetEntityByIdAsyncWithRelatedEntity(devisId);
                var resultParameter = await _documentParametersDataAccess.GetByAgenceIdAsync(_user.AgenceId);
                var devisParameters = resultParameter.Devis;
                var pdfResult = _pdfGenerateService.GenerateDevisPDF(result, devisParameters);
                return Result<byte[]>.Success(pdfResult);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error generate PDF devis id:({id})", devisId);
                return Result<byte[]>.Failed(null, exception, "Error generate PDF devis");
            }
        }

        /// <summary>
        /// generate example devis
        /// </summary>
        /// <param name="documentParameters">the parameters of document</param>
        /// <returns>a pdf result</returns>
        public Result<byte[]> ExampleDevisParametersModel(DocumentParametersModel documentParameters)
        {
            try
            {
                // devis parameter
                var devisParameter = documentParameters.Devis;

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
                var devis = new Devis()
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
                var pdfResult = _pdfGenerateService.GenerateDevisPDF(devis, devisParameter);

                return Result<byte[]>.Success(pdfResult, "the PDF created successful");
            }
            catch (Exception ex)
            {
                return Result<byte[]>.Failed(null, ex, "Failed generating the PDF, an exception has been thrown");
            }
        }

        /// <summary>
        /// send devis in email
        /// </summary>
        /// <param name="devisId">the id of devis</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns>a instance of result</returns>
        public async Task<Result<ICollection<MailHistoryModel>>> SendDevisInEmail(string devisId, MailModel mailModel)
        {
            var configMail = await _configMessagerieDataAccess.GetConfigMessagerieByAgenceIdAsync(_user.AgenceId);

            if (configMail is null)
                throw new NotFoundException("there is not configuration for messagerie", MsgCode.NoConfigMessagerie);

            // get devis by id 
            var devis = await GetEntityByIdAsyncWithRelatedEntity(devisId);

            // get parameter document
            var parameterDocument = await _documentParametersDataAccess.GetByAgenceIdAsync(_user.AgenceId);

            // devis parameter
            var devisParameter = parameterDocument.Devis;

            // generate PDF
            var pdfRes = _pdfGenerateService.GenerateDevisPDF(devis, devisParameter);

            // build mail params model
            MailParamsModel mailParams = new MailParamsModel()
            {
                Attachments = new List<AttachmentModel>() { new AttachmentModel() { File = pdfRes, Name = $"{devis.Reference}.pdf" } },
                BCC = new List<string>(),
                CC = new List<string>(),
                Content = mailModel.Body,
                MessageTo = mailModel.EmailTo.ToList(),
                Subject = mailModel.Subject
            };

            // send email
            await _mailService.SendEmail(mailParams, _mapper.Map<ConfigMessagerieModel>(configMail));

            // update email 
            await UpdateDevisEmailField(devis, mailModel);

            return Result<ICollection<MailHistoryModel>>.Success(devis.Emails);
        }

        /// <summary>
        /// sign a devis
        /// </summary>
        /// <param name="devisSignature">the devis signature model</param>
        /// <returns>a devis result</returns>
        public async Task<Result<DevisModel>> SignDevis(DevisSignatureModel devisSignature)
        {
            // get devis
            var devis = await GetEntityByIdAsync(devisSignature.DevisId);

            // map devis signature into devis
            _mapper.Map(devisSignature, devis);

            // update devis
            devis.Status = DevisStatus.Signe;
            _dataAccess.Update(devis);

            if (devis.DossierId.IsValid())
                await MakeDossierSigned(devis.DossierId);

            // change genere client
            await _clientService.ChangeGenreClientFromProspectToClient(devis.ClientId);

            // save changes
            await _unitOfWork.SaveChangesAsync();

            // build a result
            var data = _mapper.Map<DevisModel>(devis);
            return Result<DevisModel>.Success(data);
        }

        #region private methods

        /// <summary>
        /// update email field of devis
        /// </summary>
        /// <param name="devis">the facture of</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns></returns>
        private async Task UpdateDevisEmailField(Devis devis, MailModel mailModel)
        {
            // the list of emails
            var emails = devis.Emails;

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
            devis.Emails = emails;

            // update facture
            _dataAccess.Update(devis);
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task MakeDossierSigned(string dossierId)
        {
            var dossier = await GetDossier(dossierId);

            if (dossier.Status == DossierStatus.Chiffre)
            {
                dossier.Status = DossierStatus.Signe;
                _dossierDataAccess.Update(dossier);
            }
        }

        private async Task<Dossier> GetDossier(string dossierId)
        {
            var dossier = await _dossierDataAccess.GetAsync(dossierId);

            if (dossier is null)
                throw new NotFoundException($"there is no dossier with the given id ${dossierId}");

            return dossier;
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

        private async Task MarkDossierChiffre(DevisCreateModel devis)
        {
            var countDevisAssociateWithDevis = await _dataAccess.GetCountAsync(e => e.DossierId == devis.DossierId);
            if (countDevisAssociateWithDevis == 0)
            {
                var dossier = await _dossierDataAccess.GetAsync(devis.DossierId);
                dossier.Status = DossierStatus.Chiffre;
                _dossierDataAccess.Update(dossier);
            }
        }

        #endregion

        #region overrides

        protected override async Task BeforeAddEntity(Devis entity, DevisCreateModel model)
        {
            var client = await _clientDataAcces.GetAsync(model.ClientId);
            entity.SiteIntervention = UpdateAddressesClient(client, model.SiteIntervention);

            if (model.DossierId.IsValid())
                await MarkDossierChiffre(model);

        }

        protected override async Task AfterAddEntity(Devis entity, DevisCreateModel model)
        {
            await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.Devis);

            if (await _bonCommandeDataAcces.IsExistAsync(e => e.Id == model.BonCommandeId && e.DevisId.IsValid()))
                throw new UnAcceptableRequestException($"the given bon commande id {model.BonCommandeId} already associated with devis");

            if (model.BonCommandeId.IsValid())
            {
                var bonCommande = await _bonCommandeDataAcces.GetAsync(model.BonCommandeId);
                bonCommande.DevisId = entity.Id;
                bonCommande.Status = BonCommandeStatus.Commande;
                _bonCommandeDataAcces.Update(bonCommande);
            }
        }

        protected override async Task BeforeUpdateEntity(Devis entity, DevisUpdateModel model)
        {
            var client = await _clientDataAcces.GetAsync(model.ClientId);
            entity.SiteIntervention = UpdateAddressesClient(client, model.SiteIntervention);
        }

        protected override Task AfterGetByIdEntity(Devis entity, DevisModel model)
        {
            model.DocumentAssociates = entity.Factures
               .Select(e => new DocumentAssociate
               {
                   Id = e.FactureId,
                   CreateOn = e.Facture.CreatedOn.Date,
                   Reference = e.Facture.Reference,
                   Type = DocType.Facture,
                   Status = (int)e.Facture.Status,
                   TotalTTC = e.Facture.TotalTTC,
               })
               .Concat(
                    entity.BonsCommandes
                    .Select(e => new DocumentAssociate()
                    {
                        Id = e.Id,
                        CreateOn = e.CreatedOn.Date,
                        Reference = e.Reference,
                        Type = DocType.BonCommande,
                        Status = (int)e.Status,
                        TotalTTC = e.TotalTTC,
                    })
                )
               .ToList();

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

        protected override Expression<Func<Devis, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterModel)
        {
            var predicate = CommunListPredicate();

            if (filterModel is DevisFilterOption filterOption)
            {
                if (filterOption.Type.HasValue)
                    predicate = predicate.And(e => e.Type == filterOption.Type.Value);

                if (filterOption.ClientId.IsValid())
                    predicate = predicate.And(e => e.ClientId == filterOption.ClientId);

                if (filterOption.Status.Count() > 0)
                    predicate = predicate.And(e => filterOption.Status.Contains(e.Status));
            }

            return predicate;
        }

        protected override Expression<Func<Devis, bool>> BuildGetListPredicate()
            => CommunListPredicate();

        private Expression<Func<Devis, bool>> CommunListPredicate()
        {
            var predicate = PredicateBuilder.True<Devis>();

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);

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

        protected override Func<IQueryable<Devis>, IIncludableQueryable<Devis, object>> BuildIncludesList()
            => e => e.Include(d => d.Client)
                    .Include(d => d.Factures).ThenInclude(d => d.Facture);

        protected override Func<IQueryable<Devis>, IIncludableQueryable<Devis, object>> BuildIncludesGetById()
             => e => e.Include(d => d.Client)
                    .Include(d => d.User)
                    .Include(d => d.Factures).ThenInclude(d => d.Facture)
                    .Include(d => d.Dossier).ThenInclude(d => d.PrimeCEE)
                    .Include(d => d.BonsCommandes);

        #endregion
    }
}
