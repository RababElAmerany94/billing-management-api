namespace COMPANY.Application.Services.DataService.Documents
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Documents.Avoir;
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
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
    /// a class describe avoir service
    /// </summary>
    [Inject(typeof(IAvoirService), ServiceLifetime.Scoped)]
    public class AvoirService : BaseService<Avoir, string, AvoirModel, AvoirCreateModel, AvoirUpdateModel>, IAvoirService
    {
        private readonly IDocumentParametersDataAccess _documentParametersDataAccess;
        private readonly IPdfGenerateService _pdfGenerateService;
        private readonly IConfigMessagerieDataAccess _configMessagerieDataAccess;
        private readonly IMailService _mailService;
        private readonly INumerotationService _numerotationService;

        public AvoirService(
            IDataRequestBuilder<Avoir> requestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUserService,
            INumerotationService numerotationService,
            IPdfGenerateService pdfGenerateService,
            IMailService mailService) : base(requestBuilder, unitOfWork, mapper, currentUserService)
        {
            _documentParametersDataAccess = _unitOfWork.DocumentParametersDataAccess;
            _configMessagerieDataAccess = _unitOfWork.ConfigMessagerieDataAccess;
            _numerotationService = numerotationService;
            _pdfGenerateService = pdfGenerateService;
            _mailService = mailService;
        }

        /// <summary>
        /// generate PDF of avoir
        /// </summary>
        /// <param name="avoirId">the avoir id</param>
        /// <returns>a result of byte</returns>
        public async Task<Result<byte[]>> GeneratePdfAvoirAsync(string avoirId)
        {
            try
            {
                var avoir = await GetEntityByIdAsyncWithRelatedEntity(avoirId);
                var parameterDocument = await _documentParametersDataAccess.GetByAgenceIdAsync(_user.AgenceId);
                var avoirParameter = parameterDocument.Avoir;
                var pdfResult = _pdfGenerateService.GenerateAvoirPDF(avoir, avoirParameter);
                return Result<byte[]>.Success(pdfResult, "the PDF created successful");
            }
            catch (Exception ex)
            {
                return Result<byte[]>.Failed(null, ex, "Failed generating the PDF, an exception has been thrown");
            }
        }

        /// <summary>
        /// generate example avoir
        /// </summary>
        /// <param name="documentParameters">the parameters of document</param>
        /// <returns>a pdf result</returns>
        public Result<byte[]> ExampleAvoirPdfAsync(DocumentParametersModel documentParameters)
        {
            try
            {
                // avoir parameter
                var avoirParameter = documentParameters.Avoir;

                // create instance of avoir
                var avoir = new Avoir()
                {
                    Client = new Client()
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Reference = "CL0001",
                    },
                    ClientId = "Client::1",
                    Reference = "AV001",
                    TotalTTC = 16.75M,
                    TotalHT = 14.25M,
                    Remise = 2,
                    RemiseType = RemiseType.Percent,
                    DateCreation = DateTime.Now,
                    DateEcheance = DateTime.Now.AddDays(30),
                    ReglementCondition = avoirParameter.RegulationCondition ?? "",
                    Note = avoirParameter.Note ?? ""
                };

                // generate PDF
                var pdfResult = _pdfGenerateService.GenerateAvoirPDF(avoir, avoirParameter);
                return Result<byte[]>.Success(pdfResult, "the PDF created successful");
            }
            catch (Exception ex)
            {
                return Result<byte[]>.Failed(null, ex, "Failed generating the PDF, an exception has been thrown");
            }
        }

        /// <summary>
        /// send avoir in email
        /// </summary>
        /// <param name="avoirId">the id of avoir</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns>a instance of result</returns>
        public async Task<Result<ICollection<MailHistoryModel>>> SendAvoirInEmail(string avoirId, MailModel mailModel)
        {
            var configurationMail = await _configMessagerieDataAccess.GetConfigMessagerieByAgenceIdAsync(_user.AgenceId);

            // get avoir by id 
            var avoir = await GetEntityByIdAsyncWithRelatedEntity(avoirId);

            // get parameter document
            var parameterDocument = await _documentParametersDataAccess.GetByAgenceIdAsync(_user.AgenceId);

            // avoir parameter
            var avoirParameter = parameterDocument.Avoir;

            // generate PDF
            var pdfResult = _pdfGenerateService.GenerateAvoirPDF(avoir, avoirParameter);

            // build mail params model
            var mailParams = new MailParamsModel()
            {
                Attachments = new List<AttachmentModel>() { new AttachmentModel() { File = pdfResult, Name = $"{avoir.Reference}.pdf" } },
                BCC = new List<string>(),
                CC = new List<string>(),
                Content = mailModel.Body,
                MessageTo = mailModel.EmailTo.ToList(),
                Subject = mailModel.Subject
            };

            // send email
            await _mailService.SendEmail(mailParams, _mapper.Map<ConfigMessagerieModel>(configurationMail));

            // update email 
            avoir.Emails = avoir.UpdateFactureEmailField(mailModel, _user.Id);
            _dataAccess.Update(avoir);
            await _unitOfWork.SaveChangesAsync();

            return Result<ICollection<MailHistoryModel>>.Success(avoir.Emails);
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

        #region overrides

        protected override async Task BeforeAddEntity(Avoir entity, AvoirCreateModel model)
        {
            // if the status of avoir different brouillon
            // I don't check unique reference and don't increment reference
            if (model.Status != AvoirStatus.Brouillon)
                await IncrementNumerotationAvoir(entity);
        }

        protected override async Task BeforeUpdateEntity(Avoir entity, AvoirUpdateModel model)
        {
            // if avoir in db brouillon and user update to enCours we check reference validation and increment
            if (entity.Status == AvoirStatus.Brouillon && model.Status == AvoirStatus.Encours)
            {
                var avoir = _mapper.Map<Avoir>(model);
                await IncrementNumerotationAvoir(avoir);
            }
        }

        protected override Expression<Func<Avoir, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterModel)
        {
            if (filterModel is AvoirFilterOption filterOption)
            {
                var predicate = PredicateBuilder.True<Avoir>();

                if (_user.IsFollowAgence)
                    predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
                else
                    predicate = predicate.And(c => !c.AgenceId.IsValid());

                // by client
                if (filterOption.ClientId.IsValid())
                    predicate = predicate.And(c => c.ClientId == filterOption.ClientId);

                // by the min date
                if (filterOption.DateFrom.HasValue)
                    predicate = predicate.And(c => filterOption.DateFrom.Value.Date <= c.DateEcheance.Date);

                // by date max
                if (filterOption.DateTo.HasValue)
                    predicate = predicate.And(c => filterOption.DateTo.Value.Date >= c.DateEcheance.Date);

                // by status
                if (filterOption.Status != null && filterOption.Status.Count() > 0)
                    predicate = predicate.And(c => filterOption.Status.Contains(c.Status));

                return predicate;
            }

            return base.BuildGetAsPagedPredicate(filterModel);
        }

        protected override Func<IQueryable<Avoir>, IIncludableQueryable<Avoir, object>> BuildIncludesList()
            => f => f.Include(e => e.Client);

        protected override Func<IQueryable<Avoir>, IIncludableQueryable<Avoir, object>> BuildIncludesGetById()
            => f => f.Include(e => e.Client).Include(e => e.Facture).Include(e => e.Paiements);

        protected override Task AfterGetByIdEntity(Avoir avoir, AvoirModel model)
        {
            model.DocumentAssociates = avoir.Paiements
                .Select(e => new DocumentAssociate()
                {
                    Id = e.Id,
                    CreateOn = e.DatePaiement,
                    Reference = string.Empty,
                    Type = DocType.Paiement,
                    TotalTTC = e.Montant
                }).ToList();

            if (avoir.FactureId.IsValid())
                model.DocumentAssociates.Add(new DocumentAssociate()
                {
                    Id = avoir.Facture.Id,
                    CreateOn = avoir.Facture.DateCreation,
                    Reference = avoir.Facture.Reference,
                    Type = DocType.Facture,
                    Status = (int)avoir.Facture.Status,
                    TotalTTC = avoir.Facture.TotalTTC
                });

            return base.AfterGetByIdEntity(avoir, model);
        }

        #endregion

        #region private methods

        private async Task IncrementNumerotationAvoir(Avoir avoir)
        {
            var referenceModel = await CheckUniqueReference(avoir);

            if (referenceModel is null)
                throw new UnAcceptableRequestException("reference is not unique", MsgCode.ReferenceNotUnique);
            else
                if (!referenceModel.IsOld)
                await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.Avoir);
        }

        /// <summary>
        /// check unique reference
        /// </summary>
        /// <param name="avoir">the given avoir</param>
        /// <returns>a boolean result</returns>
        private async Task<ReferenceDocumentComptable> CheckUniqueReference(Avoir avoir)
        {
            var currentReference = await _numerotationService.GenerateReferenceDocumentComptable(avoir.DateCreation, DocumentComptableType.Avoir);

            if (avoir.Reference == currentReference.Value.Reference)
                return currentReference.Value;
            else
                return null;
        }

        #endregion
    }
}
