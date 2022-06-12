namespace COMPANY.Application.Services.DataService.Documents.PaiementService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Documents;
    using COMPANY.Application.Models.BusinessEntities.Documents.Paiement;
    using COMPANY.Application.Models.General;
    using COMPANY.Application.Models.GeneralModels;
    using COMPANY.Application.Services.DataService.CalculationService;
    using COMPANY.Application.Services.DataService.NumerotationService;
    using COMPANY.Application.Services.FileService;
    using COMPANY.Common.Constants;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;
    using COMPANY.Domain.Enums.General;
    using Company.AutoInjection.Attributes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Xterme.Application.Models.GeneralModels.PagingModels;

    /// <summary>
    /// a class describe avoir service
    /// </summary>
    [Inject(typeof(IPaiementService), ServiceLifetime.Scoped)]
    public class PaiementService :
        BaseService<Paiement, string, PaiementModel, PaiementCreateModel, PaiementUpdateModel>,
        IPaiementService
    {
        private readonly ICalculationService _calculation;
        private readonly IPaiementDataAccess _paiementDataAccess;
        private readonly IFileService _fileService;
        private readonly IDataRequestBuilder<Facture> _factureRequestBuilder;
        private readonly INumerotationService _numerotationService;
        private readonly IDataAccess<Facture, string> _factureDataAccess;
        private readonly IDataAccess<Avoir, string> _avoirDataAccess;
        private readonly ColumnsNamesPaiementGroupeOblige _columnsNames;

        public PaiementService(
            IDataRequestBuilder<Paiement> requestBuilder,
            IDataRequestBuilder<Facture> factureRequestBuilder,
            ICurrentUserService currentUserService,
            INumerotationService numerotationService,
            ICalculationService calculation,
            IFileService fileService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptions<AppSettings> options) : base(requestBuilder, unitOfWork, mapper, currentUserService)
        {
            _factureRequestBuilder = factureRequestBuilder;
            _fileService = fileService;
            _numerotationService = numerotationService;
            _paiementDataAccess = unitOfWork.PaiementDataAccess;
            _factureDataAccess = unitOfWork.DataAccess<Facture, string>();
            _avoirDataAccess = unitOfWork.DataAccess<Avoir, string>();
            _calculation = calculation;
            _columnsNames = options.Value.ColumnsNamesPaiementGroupeOblige;
        }

        /// <summary>
        /// movement amount from account to another account
        /// </summary>
        /// <param name="paimentMovementModel">the model describe movement</param>
        /// <returns>a result instant</returns>
        public async Task<Result> MovementCompteToCompte(PaiementMovementCompteToCompteModel paimentMovementModel)
        {
            // debit payment
            var debit = new Paiement
            {
                Montant = -paimentMovementModel.Montant,
                Type = PaiementType.TransferFrom,
                BankAccountId = paimentMovementModel.CompteDebitId,
                AgenceId = _user.AgenceId,
                DatePaiement = DateTime.Now,
                Comptabilise = false,
                Description = paimentMovementModel.Description,
                Historique = Extentions.RecoredAddNewItemHistory(_user.Id)
            };

            // credit payment
            var credit = new Paiement
            {
                Montant = paimentMovementModel.Montant,
                Type = PaiementType.TransferTo,
                BankAccountId = paimentMovementModel.CreditCompteId,
                AgenceId = _user.AgenceId,
                DatePaiement = DateTime.Now,
                Comptabilise = false,
                Description = paimentMovementModel.Description,
                Historique = Extentions.RecoredAddNewItemHistory(_user.Id)
            };

            var paiements = new List<Paiement>() { debit, credit };
            await _dataAccess.AddRangeAsync(paiements);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("movement successfully");
        }

        /// <summary>
        /// return total of paiments
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>return the result instance</returns>
        public async Task<Result<decimal>> GetTotalPaiementsAsync(PaiementFilterOption filterOption)
        {
            var request = BuildAsPagedDataRequest(filterOption);
            var result = await _paiementDataAccess.GetTotalPaiementsAsync(request);
            return Result<decimal>.Success(result);
        }

        /// <summary>
        /// paiement groupe of obligé
        /// </summary>
        /// <param name="model">the model paiement</param>
        /// <returns>a result status</returns>
        public async Task<Result> PaiementGroupeOblige(PaiementGroupeObligeModel model)
        {
            var excelData = _fileService.GetDataExcel(model.FichePaiement);

            if (excelData.Count() < 2)
                throw new UnAcceptableRequestException("the file of paiement is invalid");

            var indexMontant = excelData.First().IndexOf(_columnsNames.Montant);
            var indexNumeroAH = excelData.First().IndexOf(_columnsNames.NumeroAH);

            if (indexMontant < 0 || indexNumeroAH < 0)
                throw new UnAcceptableRequestException("the format of excel incorrect");

            var numerosAH = excelData.GetRange(1, excelData.Count - 1).Select(e => e[indexNumeroAH]);

            var factures = await _factureDataAccess.GetAsync(e =>
                    e.AgenceId == _user.AgenceId &&
                    e.Devis.Any(d => d.Devis.Dossier.PrimeCEEId == model.PrimeCeeId) &&
                    numerosAH.Contains(e.NumeroAH));

            var paiements = new List<Paiement>();

            for (int i = 1; i < excelData.Count; i++)
            {
                var row = excelData[i];

                var paiement = _mapper.Map<Paiement>(model);
                paiement.AgenceId = _user.AgenceId;
                paiement.Type = PaiementType.PayerGroup;
                paiement.Montant = decimal.Parse(row[indexMontant]);
                paiement.Historique = Extentions.RecoredAddNewItemHistory(_user.Id);

                var facture = factures.FirstOrDefault(e => e.NumeroAH == row[indexNumeroAH]);
                if (facture is null)
                    throw new UnAcceptableRequestException($"there is no facture with the given numero AH: {row[indexNumeroAH]}");

                paiement.FacturePaiements = new List<FacturePaiement>
                {
                    new FacturePaiement()
                    {
                        FactureId = facture.Id,
                        Montant = paiement.Montant
                    }
                };

                if (!await CheckValidatePaiementDuringCreation(_mapper.Map<ICollection<FacturePaiementModel>>(paiement.FacturePaiements)))
                    throw new UnAcceptableRequestException("the amount of payment incorrect", MsgCode.AmountPaymentInvalid);

                paiements.Add(paiement);
            }

            await _dataAccess.AddRangeAsync(paiements);
            await _unitOfWork.SaveChangesAsync();

            await CheckFacturesStatusAfterPaiement(factures.Select(e => e.Id).ToList());

            return Result.Success("created successfully");
        }

        #region overrides

        protected override Func<IQueryable<Paiement>, IIncludableQueryable<Paiement, object>> BuildIncludesList()
            => p => p.Include(e => e.BankAccount).Include(e => e.RegulationMode);

        protected override Func<IQueryable<Paiement>, IIncludableQueryable<Paiement, object>> BuildIncludesGetById()
            => p => p.Include(e => e.FacturePaiements).ThenInclude(e => e.Facture).ThenInclude(e => e.Client)
                     .Include(e => e.Avoir).ThenInclude(e => e.Client)
                     .Include(e => e.BankAccount)
                     .Include(e => e.RegulationMode);

        protected override Expression<Func<Paiement, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterModel)
        {
            var predicate = PredicateBuilder.True<Paiement>();

            if (filterModel is PaiementFilterOption filterOption)
            {
                if (_user.IsFollowAgence)
                    predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
                else
                    predicate = predicate.And(c => !c.AgenceId.IsValid());

                if (filterOption.BankAccountId.IsValid())
                    predicate = predicate.And(c => c.BankAccountId.IsValid() && c.BankAccountId == filterOption.BankAccountId);

                if (filterOption.DateFrom.HasValue)
                    predicate = predicate.And(c => filterOption.DateFrom.Value.Date <= c.DatePaiement.Date);

                if (filterOption.DateTo.HasValue)
                    predicate = predicate.And(c => filterOption.DateTo.Value.Date >= c.DatePaiement.Date);
            }

            return predicate;
        }

        protected override Task AfterGetByIdEntity(Paiement paiement, PaiementModel model)
        {
            model.DocumentAssociates = paiement.FacturePaiements
              .Select(e => new DocumentAssociate
              {
                  Id = e.Facture.Id,
                  CreateOn = e.Facture.DateCreation,
                  Reference = e.Facture.Reference,
                  Type = DocType.Facture,
                  Status = (int)e.Facture.Status,
                  TotalTTC = e.Facture.TotalTTC,
              })
              .ToList();

            if (paiement.AvoirId.IsValid())
            {
                model.DocumentAssociates.Add(new DocumentAssociate()
                {
                    Id = paiement.Avoir.Id,
                    CreateOn = paiement.Avoir.DateCreation,
                    Reference = paiement.Avoir.Reference,
                    Type = DocType.Avoir,
                    Status = (int)paiement.Avoir.Status,
                    TotalTTC = paiement.Avoir.TotalTTC
                });
            }

            return base.AfterGetByIdEntity(paiement, model);
        }

        protected override async Task BeforeAddEntity(Paiement entity, PaiementCreateModel model)
        {
            if (!await CheckValidatePaiementDuringCreation(model.FacturePaiements))
                throw new UnAcceptableRequestException("the amount of payment incorrect", MsgCode.AmountPaymentInvalid);

            // create avoir when user use
            // regulation mode : avoir and different to group payment
            if (model.CreateAvoir && model.Type != PaiementType.PayerGroup)
            {
                var firstFacture = await _factureDataAccess.GetAsync(model.FacturePaiements.First().FactureId);
                var avoir = await CreateAvoir(firstFacture, model.Montant);
                entity.AvoirId = avoir.Id;
            }

            // if this payment associate with avoir we change his status
            if (model.AvoirId.IsValid())
                await ChangeStatusAvoir(model.AvoirId, AvoirStatus.Utilise);
        }

        protected override async Task AfterSaveChangesAddEntity(Paiement entity, PaiementCreateModel model)
        {
            // check status of all factures after payment
            await CheckFacturesStatusAfterPaiement(entity.FacturePaiements.Select(x => x.FactureId).ToList());
        }

        protected override async Task BeforeUpdateEntity(Paiement entity, PaiementUpdateModel model)
        {
            if (entity.Type != PaiementType.Payer || entity.AvoirId.IsValid() || entity.Comptabilise)
                throw new UnAcceptableRequestException("you cannot change this payment", MsgCode.CantModify);

            if (!await CheckValidatePaiementDuringModification(model.FacturePaiements))
                throw new UnAcceptableRequestException("the amount of payment incorrect", MsgCode.AmountPaymentInvalid);

            // mapping facture payment
            entity.FacturePaiements = _mapper.Map<ICollection<FacturePaiement>>(model.FacturePaiements);

            // create avoir when user use
            // regulation mode : avoir and different to group payment
            if (model.CreateAvoir && model.Type != PaiementType.PayerGroup)
            {
                var firstFacture = await _factureDataAccess.GetAsync(model.FacturePaiements.First().FactureId);
                var avoir = await CreateAvoir(firstFacture, model.Montant);
                entity.AvoirId = avoir.Id;
            }
        }

        protected override async Task AfterSaveChangesUpdateEntity(Paiement entity, PaiementUpdateModel model)
        {
            // check status of all factures after payment
            await CheckFacturesStatusAfterPaiement(entity.FacturePaiements.Select(x => x.FactureId).ToList());
        }

        public override async Task<Result> DeleteAsync(string id)
        {
            var paiement = await GetEntityByIdAsyncWithRelatedEntity(id);

            if (paiement.Comptabilise)
                throw new UnAcceptableRequestException("you cannot delete this payment");

            // if paiement by avoir and avoir independent   
            if (paiement.AvoirId.IsValid() && !paiement.Avoir.FactureId.IsValid() && paiement.Avoir.Type == AvoirCreateType.Payment)
                await _avoirDataAccess.DeleteAsync(paiement.AvoirId);

            // if this avoir didn't create from a facture
            if (paiement.AvoirId.IsValid() && paiement.Avoir.Type == AvoirCreateType.Independent)
                await UpdateAvoirStatusAfterRemovePayment(paiement.AvoirId);

            _dataAccess.Delete(paiement);
            await _unitOfWork.SaveChangesAsync();
            _unitOfWork.ResetContextState();

            var facturePayments = paiement.FacturePaiements;
            await CheckFacturesStatusAfterPaiement(facturePayments.Select(x => x.FactureId).ToList());

            return Result.Success($"{_entityName} removed successfully");
        }

        #endregion

        #region private methods

        /// <summary>
        /// check validate paiement during creation
        /// </summary>
        /// <param name="facturePaiements"></param>
        /// <returns></returns>
        private async Task<bool> CheckValidatePaiementDuringCreation(ICollection<FacturePaiementModel> facturePaiements)
        {
            var distinctFacturesId = facturePaiements.Select(x => x.FactureId);

            var request = _factureRequestBuilder
                                .AddPredicate(e => distinctFacturesId.Contains(e.Id))
                                .AddInclude(f => f.Include(e => e.FacturePaiements).ThenInclude(e => e.Paiement))
                                .Buil();

            var factures = await _factureDataAccess.GetAsync(request);

            foreach (var facturePaiment in facturePaiements)
            {
                var facture = factures.Where(x => x.Id == facturePaiment.FactureId).FirstOrDefault();
                var totalInDatabase = facture.FacturePaiements.Sum(x => x.Montant);
                var total = (totalInDatabase + facturePaiment.Montant).RoundingDecimal();

                if (facture.Status == FactureStatus.Cloturee || total > facture.TotalTTC.RoundingDecimal())
                    return false;
            }

            return true;
        }

        /// <summary>
        /// create avoir associate with the payment
        /// </summary>
        /// <param name="facture">the facture entity</param>
        /// <param name="montant">the amount of payment</param>
        /// <returns></returns>
        private async Task<Avoir> CreateAvoir(Facture facture, decimal montant)
        {
            #region create articles of avoir

            var article = new Article
            {
                Qte = 1,
                PrixHT = montant,
                Designation = $"Paiement par avoir de la facture {facture.Reference}",
                TVA = 0,
                Remise = 0,
                RemiseType = RemiseType.Percent,
                TotalTTC = montant,
                TotalHT = montant,
                Description = string.Empty,
                Reference = string.Empty,
                Id = "Avoir::1",
                Type = ArticleType.Other
            };

            #endregion

            // generate numeration avoir
            var numerotationAvoir = await _numerotationService.GenerateReferenceDocumentComptable(DateTime.Now, DocumentComptableType.Avoir);

            // inti avoir
            var avoir = new Avoir
            {
                Reference = numerotationAvoir.Value.Reference,
                Articles = new Article[] { article },
                TotalHT = -_calculation.TotalHt(new List<Article>() { article }),
                TotalTTC = -_calculation.TotalHt(new List<Article>() { article }),
                Remise = 0,
                RemiseType = RemiseType.Percent,
                Historique = Extentions.RecoredAddNewItemHistory(_user.Id),
                Comptabilise = false,
                ReglementCondition = string.Empty,
                Note = string.Empty,
                Counter = numerotationAvoir.Value.Counter,
                ClientId = facture.ClientId,
                DateCreation = DateTime.Now,
                DateEcheance = DateTime.Now.AddDays(1),
                Status = AvoirStatus.Utilise,
                Objet = string.Empty,
                Type = AvoirCreateType.Payment,
            };

            await _avoirDataAccess.AddAsync(avoir);
            await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.Avoir);
            return avoir;
        }

        /// <summary>
        /// change status avoir
        /// </summary>
        /// <param name="AvoirId">the id of avoir</param>
        /// <param name="avoirStatus">the status of avoir</param>
        /// <returns></returns>
        private async Task ChangeStatusAvoir(string AvoirId, AvoirStatus avoirStatus)
        {
            var avoir = await _avoirDataAccess.GetAsync(AvoirId);
            avoir.Status = avoirStatus;
            _avoirDataAccess.Update(avoir);
        }

        /// <summary>
        /// check factures status after paiement
        /// </summary>
        /// <param name="facturePaiements">the list of factures paiements</param>
        /// <returns></returns>
        private async Task CheckFacturesStatusAfterPaiement(ICollection<string> facturesId)
        {
            var request = _factureRequestBuilder
                            .AddPredicate(e => facturesId.Contains(e.Id))
                            .AddInclude(f => f.Include(e => e.FacturePaiements))
                            .Buil();
            var factures = await _factureDataAccess.GetAsync(request);

            foreach (var facture in factures)
            {
                var factureSumPayement = facture.FacturePaiements.Sum(x => x.Montant);

                if (facture.TotalTTC.RoundingDecimal() == factureSumPayement.RoundingDecimal())
                    facture.Status = FactureStatus.Cloturee;
                else
                {
                    if (facture.DateEcheance.Date < DateTime.Now.Date)
                        facture.Status = FactureStatus.Enretard;
                    else
                        facture.Status = FactureStatus.Encours;
                }
            }

            _unitOfWork.ResetContextState();
            _factureDataAccess.UpdateRange(factures);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// check validate paiement during creation
        /// </summary>
        /// <param name="facturePaiements">the list of facture payments</param>
        /// <returns>is this payment valid</returns>
        private async Task<bool> CheckValidatePaiementDuringModification(ICollection<FacturePaiementModel> facturePaiements)
        {
            // Get id of first facture 
            var factureId = facturePaiements.Select(x => x.FactureId).FirstOrDefault();

            // build request filter
            var request = _factureRequestBuilder
                            .AddPredicate(e => e.Id == factureId)
                            .AddInclude(f => f.Include(e => e.FacturePaiements))
                            .Buil();

            // select facture in DB
            var facture = (await _factureDataAccess.GetAsync(request)).FirstOrDefault();

            // list of facture payments in db
            var facturePaymentsInDb = facture.FacturePaiements.ToList();

            // select modify facture payment
            var modifyFacturePayment = facturePaiements.FirstOrDefault();

            // update value in payment facture in DB
            foreach (var facturePayement in facturePaymentsInDb)
            {
                if (facturePayement.Id == modifyFacturePayment.Id)
                    facturePayement.Montant = modifyFacturePayment.Montant;
            }

            // total of payment
            var totalPayment = facturePaymentsInDb.Sum(x => x.Montant).RoundingDecimal();

            // total TTC facture
            var totalTTC = facture.TotalTTC.RoundingDecimal();

            return (totalPayment <= totalTTC);
        }

        /// <summary>
        /// update avoir status
        /// </summary>
        /// <param name="avoirId">the id of avoir</param>
        /// <returns></returns>
        private async Task UpdateAvoirStatusAfterRemovePayment(string avoirId)
        {
            var avoir = await _avoirDataAccess.GetAsync(avoirId);

            if (avoir.DateEcheance.Date > DateTime.Now.Date)
                avoir.Status = AvoirStatus.Encours;
            else
                avoir.Status = AvoirStatus.Expire;

            _avoirDataAccess.Update(avoir);
        }

        #endregion
    }
}
