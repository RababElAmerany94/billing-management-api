namespace COMPANY.Application.Services.DataService.Documents.FactureService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
    using COMPANY.Application.Models.BusinessEntities.Documents.Facture;
    using COMPANY.Application.Models.BusinessEntities.Relations.FactureDevis;
    using COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
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
    using COMPANY.Domain.Enums.Documents;
    using Inova.AutoInjection.Attributes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// a class describe facture service
    /// </summary>
    [Inject(typeof(IFactureService), ServiceLifetime.Scoped)]
    public class FactureService :
        BaseService<Facture, string, FactureModel, FactureCreateModel, FactureUpdateModel>, IFactureService
    {
        private readonly IDocumentParametersDataAccess _documentParametersDataAccess;
        private readonly IPdfGenerateService _pdfGenerateService;
        private readonly IConfigMessagerieDataAccess _configMessagerieDataAccess;
        private readonly IMailService _mailService;
        private readonly IClientService _clientService;
        private readonly IDataRequestBuilder<Devis> _devisRequestBuilder;
        private readonly INumerotationService _numerotationService;
        private readonly IDataAccess<Avoir, string> _avoirDataAccess;
        private readonly IDataAccess<Devis, string> _devisDataAccess;
        private readonly IDataAccess<Client, string> _clientDataAccess;

        public FactureService(
            IDataRequestBuilder<Facture> requestBuilder,
            IDataRequestBuilder<Devis> devisRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUserService,
            INumerotationService numerotationService,
            IPdfGenerateService pdfGenerateService,
            IMailService mailService,
            IClientService clientService) : base(requestBuilder, unitOfWork, mapper, currentUserService)
        {
            _documentParametersDataAccess = _unitOfWork.DocumentParametersDataAccess;
            _configMessagerieDataAccess = _unitOfWork.ConfigMessagerieDataAccess;
            _avoirDataAccess = _unitOfWork.DataAccess<Avoir, string>();
            _devisDataAccess = _unitOfWork.DataAccess<Devis, string>();
            _clientDataAccess = _unitOfWork.DataAccess<Client, string>();
            _devisRequestBuilder = devisRequestBuilder;
            _numerotationService = numerotationService;
            _pdfGenerateService = pdfGenerateService;
            _mailService = mailService;
            _clientService = clientService;
        }

        /// <summary>
        /// generate PDF of facture
        /// </summary>
        /// <param name="factureId">the facture id</param>
        /// <returns>a result of byte</returns>
        public async Task<Result<byte[]>> GeneratePdfFactureAsync(string factureId)
        {
            try
            {
                var facture = await GetEntityByIdAsyncWithRelatedEntity(factureId);
                var parameterDocument = await _documentParametersDataAccess.GetByAgenceIdAsync(_user.AgenceId);
                var pdfResult = _pdfGenerateService.GenerateFacturePDF(facture, parameterDocument.Facture);
                return Result<byte[]>.Success(pdfResult, "the PDF created successful");
            }
            catch (Exception ex)
            {
                return Result<byte[]>.Failed(null, ex, "Failed generating the PDF, an exception has been thrown");
            }
        }

        /// <summary>
        /// generate example facture
        /// </summary>
        /// <param name="documentParameters">the parameters of document</param>
        /// <returns>a pdf result</returns>
        public Result<byte[]> ExampleFacturePdfAsync(DocumentParametersModel documentParameters)
        {
            try
            {
                var factureParameter = documentParameters.Facture;
                var facture = new Facture()
                {
                    Client = new Client()
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Reference = "CL0001"
                    },
                    ClientId = "Client::1",
                    Reference = "FC001",
                    TotalTTC = 16.75M,
                    TotalHT = 14.25M,
                    Remise = 2,
                    RemiseType = RemiseType.Percent,
                    DateCreation = DateTime.Now,
                    DateEcheance = DateTime.Now.AddDays(30),
                    ReglementCondition = factureParameter.RegulationCondition ?? "",
                    Note = factureParameter.Note ?? ""
                };
                var pdfResult = _pdfGenerateService.GenerateFacturePDF(facture, factureParameter);
                return Result<byte[]>.Success(pdfResult, "the PDF created successful");
            }
            catch (Exception ex)
            {
                return Result<byte[]>.Failed(null, ex, "Failed generating the PDF, an exception has been thrown");
            }
        }

        /// <summary>
        /// send facture in email
        /// </summary>
        /// <param name="factureId">the id of facture</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns>a instance of result</returns>
        public async Task<Result<ICollection<MailHistoryModel>>> SendFactureInEmail(string factureId, MailModel mailModel)
        {
            var configurationMail = await _configMessagerieDataAccess.GetConfigMessagerieByAgenceIdAsync(_user.AgenceId);

            // get facture by id 
            var facture = await GetEntityByIdAsyncWithRelatedEntity(factureId);

            // get parameter document
            var parameterDocument = await _documentParametersDataAccess.GetByAgenceIdAsync(_user.AgenceId);

            // facture parameter
            var factureParameter = parameterDocument.Facture;

            // generate PDF
            var pdfResult = _pdfGenerateService.GenerateFacturePDF(facture, factureParameter);

            // build mail params model
            MailParamsModel mailParams = new MailParamsModel()
            {
                Attachments = new List<AttachmentModel>() { new AttachmentModel() { File = pdfResult, Name = $"{facture.Reference}.pdf" } },
                BCC = new List<string>(),
                CC = new List<string>(),
                Content = mailModel.Body,
                MessageTo = mailModel.EmailTo.ToList(),
                Subject = mailModel.Subject
            };

            // send email
            await _mailService.SendEmail(mailParams, _mapper.Map<ConfigMessagerieModel>(configurationMail));

            // update email 
            facture.Emails = facture.UpdateFactureEmailField(mailModel, _user.Id);
            _dataAccess.Update(facture);
            await _unitOfWork.SaveChangesAsync();

            return Result<ICollection<MailHistoryModel>>.Success(facture.Emails);
        }

        /// <summary>
        /// cancel facture
        /// </summary>
        /// <param name="id">the id of facture</param>
        /// <returns>a result object</returns>
        public async Task<Result<FactureModel>> CancelFacture(string id)
        {
            var facture = await GetEntityByIdAsyncWithRelatedEntity(id);

            // check if this facture has payments
            if (facture.FacturePaiements.Count() > 0)
                throw new UnAcceptableRequestException("remove payments before delete facture", MsgCode.RemovePayment);

            // create avoir
            await CreateAvoir(facture);

            // update facture status to cancel
            facture.Status = FactureStatus.Annulee;

            // update result
            _dataAccess.Update(facture);

            // save changes
            await _unitOfWork.SaveChangesAsync();

            var updateFacture = _mapper.Map<FactureModel>(facture);
            return Result<FactureModel>.Success(updateFacture);
        }

        /// <summary>
        /// save the given memos to the user memos list
        /// </summary>
        /// <param name="id">the id of the user to save the memo for him</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>an operation result</returns>
        public async Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos)
        {
            var result = await GetEntityByIdAsync(id);
            result.Memos = memos;
            _dataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("memo updated successfully");
        }

        /// <summary>
        /// export releve facture pdf
        /// </summary>
        /// <param name="filterOption">The filter option</param>
        /// <returns>a result instant</returns>
        public async Task<Result<ExportReleveFacturesModel>> ExportReleveFacturesPDFAsync(ReleveFacturesFilterOption filterOption)
        {
            var factures = await GetFacturesOfReleve(filterOption);
            var client = await _clientDataAccess.GetAsync(filterOption.ClientId);
            var parameterDocument = await _documentParametersDataAccess.GetByAgenceIdAsync(_user.AgenceId);
            var factureParameter = parameterDocument.Facture;

            #region releve facture 

            var releveFacturesItems = new List<ReleveFactureItemExport>();
            foreach (var facture in factures)
            {
                var item = new ReleveFactureItemExport()
                {
                    DateCreation = facture.DateCreation,
                    Reference = facture.Reference,
                    TotalTTC = facture.TotalTTC,
                    RestToPay = (facture.TotalTTC - facture.FacturePaiements.Sum(e => e.Montant)).RoundingDecimal()
                };
                releveFacturesItems.Add(item);
            }

            var releveFacturePdf = _pdfGenerateService.GenerateReleveFacturesPDF(
                client,
                releveFacturesItems,
                factureParameter,
                filterOption.DateFrom,
                filterOption.DateTo
            );

            #endregion

            #region pdf of facture 

            var facturesPdf = new List<byte[]>();

            if (filterOption.IncludeFactures)
            {
                foreach (var facture in factures)
                {
                    var pdf = _pdfGenerateService.GenerateFacturePDF(facture, factureParameter);
                    facturesPdf.Add(pdf);
                }
            }

            #endregion

            var result = new ExportReleveFacturesModel()
            {
                ReleveFacture = releveFacturePdf,
                Factures = facturesPdf
            };

            return Result<ExportReleveFacturesModel>.Success(result, "releve facture genereted with success");
        }


        #region overrides

        protected override async Task BeforeAddEntity(Facture entity, FactureCreateModel model)
        {
            if (CheckDevisAssociateExist(model))
            {
                if (model.Status != FactureStatus.Encours)
                    throw new UnAcceptableRequestException("Incorrect status", MsgCode.StatusIncorrect);

                if (!await CheckValidateDevisToAssociatedWithFacture(model.Devis))
                    throw new UnAcceptableRequestException("there are an devis already invoiced", MsgCode.DevisAlrealdyAssociated);

                if (model.Devis.Count() > 1)
                    if (!await CheckValidateFacturationGroupe(model.Devis))
                        throw new UnAcceptableRequestException("incorrect facturation groupe", MsgCode.UnacceptableDevisForFacturationGroupe);
            }

            // If the status of facture different brouillon
            // I don't check unique reference and don't increment reference
            if (model.Status != FactureStatus.Brouillon)
                await IncrementNumerotationFacture(entity);
        }

        protected override async Task AfterAddEntity(Facture entity, FactureCreateModel model)
        {
            if (CheckDevisAssociateExist(model))
                await MakeDevisFacture(model.Devis);

            await _clientService.ChangeGenreClientFromProspectToClient(model.ClientId);
        }

        private bool CheckDevisAssociateExist(FactureCreateModel model)
            => model.Devis != null && model.Devis.Count() > 0;

        protected override async Task BeforeUpdateEntity(Facture entity, FactureUpdateModel model)
        {
            // if facture in db brouillon and user update to enCours we check reference validation and increment
            if (entity.Status == FactureStatus.Brouillon && model.Status == FactureStatus.Encours)
            {
                var facture = _mapper.Map<Facture>(model);
                await IncrementNumerotationFacture(facture);
            }
        }

        protected override Expression<Func<Facture, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterModel)
        {
            if (filterModel is FactureFilterOption filterOption)
            {
                var predicate = PredicateBuilder.True<Facture>();

                if (_user.IsFollowAgence)
                    predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
                else
                    predicate = predicate.And(c => !c.AgenceId.IsValid());

                // by client
                if (filterOption.ClientId.IsValid())
                    predicate = predicate.And(c => c.ClientId == filterOption.ClientId);

                // by the min date
                if (filterOption.DateFrom.HasValue)
                    predicate = predicate.And(c => filterOption.DateFrom.Value.Date <= c.DateCreation.Date);

                // by date max
                if (filterOption.DateTo.HasValue)
                    predicate = predicate.And(c => filterOption.DateTo.Value.Date >= c.DateCreation.Date);

                // by obligee
                if (filterOption.PrimeCeeId.IsValid())
                    predicate = predicate.And(c => c.Type == FactureType.Classic && c.Devis.Any(d => d.Devis.Dossier.PrimeCEEId == filterOption.PrimeCeeId));

                // by status
                if (filterOption.Status != null && filterOption.Status.Count() > 0)
                    predicate = predicate.And(c => filterOption.Status.Contains(c.Status));

                return predicate;
            }

            return base.BuildGetAsPagedPredicate(filterModel);
        }

        protected override Func<IQueryable<Facture>, IIncludableQueryable<Facture, object>> BuildIncludesList()
            => f => f.Include(e => e.Client).Include(e => e.FacturePaiements).Include(e => e.Devis);

        protected override Func<IQueryable<Facture>, IIncludableQueryable<Facture, object>> BuildIncludesGetById()
            => f => f.Include(e => e.Client).ThenInclude(e => e.RegulationMode)
                    .Include(e => e.FacturePaiements).ThenInclude(e => e.Paiement).ThenInclude(e => e.RegulationMode)
                    .Include(e => e.FacturePaiements).ThenInclude(e => e.Paiement).ThenInclude(e => e.BankAccount)
                    .Include(e => e.Avoirs)
                    .Include(e => e.Devis).ThenInclude(e => e.Devis).ThenInclude(e => e.Factures).ThenInclude(e => e.Facture)
                    .Include(e => e.Devis).ThenInclude(e => e.Devis).ThenInclude(e => e.Dossier).ThenInclude(e => e.PrimeCEE);

        protected override Task AfterGetByIdEntity(Facture entity, FactureModel model)
        {
            model.DocumentAssociates = entity.Devis
               .Select(e => new DocumentAssociate
               {
                   Id = e.DevisId,
                   CreateOn = e.Devis.CreatedOn.Date,
                   Reference = e.Devis.Reference,
                   Type = DocType.Devis,
                   Status = (int)e.Devis.Status,
                   TotalTTC = e.Devis.TotalTTC,
               })
               .Concat(entity.Avoirs.Select(e => new DocumentAssociate
               {
                   Id = e.Id,
                   CreateOn = e.DateCreation,
                   Reference = e.Reference,
                   Type = DocType.Avoir,
                   Status = (int)e.Status,
                   TotalTTC = e.TotalTTC
               }))
               .ToList();

            return base.AfterGetByIdEntity(entity, model);
        }

        #endregion

        #region private methods

        private async Task IncrementNumerotationFacture(Facture facture)
        {
            var referenceModel = await CheckUniqueReference(facture);

            if (referenceModel is null)
                throw new UnAcceptableRequestException("reference is not unique", MsgCode.ReferenceNotUnique);
            else
                if (!referenceModel.IsOld)
                await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.Facture);
        }

        /// <summary>
        /// check unique reference
        /// </summary>
        /// <param name="facture">the given facture</param>
        /// <returns>a boolean result</returns>
        private async Task<ReferenceDocumentComptable> CheckUniqueReference(Facture facture)
        {
            var currentReference = await _numerotationService.GenerateReferenceDocumentComptable(facture.DateCreation, DocumentComptableType.Facture);

            if (facture.Reference == currentReference.Value.Reference)
                return currentReference.Value;
            else
                return null;
        }

        /// <summary>
        /// create avoir associate with the facture
        /// </summary>
        /// <param name="facture">the facture entity</param>
        /// <returns></returns>
        private async Task CreateAvoir(Facture facture)
        {
            // generate numeration avoir
            var numerotationAvoir = await _numerotationService
                .GenerateReferenceDocumentComptable(DateTime.Now, DocumentComptableType.Avoir);

            // inti avoir
            var avoir = new Avoir
            {
                Reference = numerotationAvoir.Value.Reference,
                Articles = facture.Articles,
                TotalHT = -facture.TotalHT,
                TotalTTC = -facture.TotalTTC,
                Remise = facture.Remise,
                RemiseType = facture.RemiseType,
                Historique = Extentions.RecoredAddNewItemHistory(_user.Id),
                Comptabilise = false,
                ReglementCondition = string.Empty,
                Note = string.Empty,
                Counter = numerotationAvoir.Value.Counter,
                ClientId = facture.ClientId,
                DateCreation = DateTime.Now,
                DateEcheance = DateTime.Now,
                Status = AvoirStatus.Utilise,
                Objet = string.Empty,
                FactureId = facture.Id
            };

            // add avoir
            await _avoirDataAccess.AddAsync(avoir);

            // increment numeration
            await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.Avoir);
        }

        private async Task<bool> CheckValidateDevisToAssociatedWithFacture(ICollection<FactureDevisCreateModel> factureDevis)
        {
            var predicate = PredicateBuilder.True<Devis>()
                .And(e => factureDevis.Any(d => d.DevisId == e.Id))
                .And(e => !e.Factures.Any(d => d.DevisId == e.Id))
                .Or(e => e.Factures.Sum(f => f.Montant) < e.TotalTTC);

            return await _devisDataAccess.IsExistAsync(predicate);
        }

        private async Task<bool> CheckValidateFacturationGroupe(ICollection<FactureDevisCreateModel> factureDevis)
            => await _devisDataAccess.IsExistAsync(e => factureDevis.Any(d => d.DevisId == e.Id) && e.Type == DevisType.Normal);

        /// <summary>
        /// make devis facture
        /// </summary>
        /// <param name="factureDevis">the list relation devis and facture</param>
        /// <returns></returns>
        private async Task MakeDevisFacture(ICollection<FactureDevisCreateModel> factureDevis)
        {
            var request = _devisRequestBuilder
                .AddPredicate(e => factureDevis.Any(d => d.DevisId == e.Id))
                .AddInclude(e => e.Include(d => d.Dossier))
                .Buil();

            var devis = await _devisDataAccess.GetAsync(request);

            foreach (var item in devis)
            {
                item.Status = DevisStatus.Facture;

                if (item.Dossier != null)
                    item.Dossier.Status = DossierStatus.Facture;
            }

            _devisDataAccess.UpdateRange(devis);
        }

        /// <summary>
        /// get factures of releve from the given filter option 
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns></returns>
        private async Task<List<Facture>> GetFacturesOfReleve(ReleveFacturesFilterOption filterOption)
        {
            var predicate = PredicateBuilder.True<Facture>()
                .And(c => c.ClientId == filterOption.ClientId)
                .And(c => filterOption.DateFrom.Date <= c.DateEcheance.Date)
                .And(c => filterOption.DateTo.Date >= c.DateEcheance.Date);

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            if (filterOption.IsUnpaid)
                predicate = predicate.And(c => c.Status == FactureStatus.Encours || c.Status == FactureStatus.Enretard);
            else
                predicate = predicate.And(c => c.Status == FactureStatus.Cloturee);

            var request = _dataRequestBuilder
                    .AddPredicate(predicate)
                    .AddInclude(filterOption.IncludeFactures ? BuildIncludesGetById() : (f => f.Include(e => e.Client).Include(e => e.FacturePaiements)))
                    .Buil();

            return (await _dataAccess.GetAsync(request)).ToList();
        }

        #endregion
    }
}
