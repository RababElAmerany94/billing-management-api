namespace COMPANY.Application
{
    using AutoMapper;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.AccountManagement.Permission;
    using COMPANY.Application.Models.AccountManagement.Role;
    using COMPANY.Application.Models.BusinessEntities.Documents;
    using COMPANY.Application.Models.BusinessEntities.Documents.Avoir;
    using COMPANY.Application.Models.BusinessEntities.Documents.BonCommande;
    using COMPANY.Application.Models.BusinessEntities.Documents.Devis;
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
    using COMPANY.Application.Models.BusinessEntities.Documents.Dossier;
    using COMPANY.Application.Models.BusinessEntities.Documents.DossierPV;
    using COMPANY.Application.Models.BusinessEntities.Documents.Facture;
    using COMPANY.Application.Models.BusinessEntities.Documents.FicheControle;
    using COMPANY.Application.Models.BusinessEntities.Documents.Paiement;
    using COMPANY.Application.Models.BusinessEntities.General;
    using COMPANY.Application.Models.BusinessEntities.General.EchangeCommercial;
    using COMPANY.Application.Models.BusinessEntities.General.Notification;
    using COMPANY.Application.Models.BusinessEntities.General.Sms;
    using COMPANY.Application.Models.BusinessEntities.Parameters.AgendaEvenementType;
    using COMPANY.Application.Models.BusinessEntities.Parameters.ChampsSiteInstallation;
    using COMPANY.Application.Models.BusinessEntities.Parameters.LogementType;
    using COMPANY.Application.Models.BusinessEntities.Parameters.ModeleSms;
    using COMPANY.Application.Models.BusinessEntities.Parameters.SourceDuLead;
    using COMPANY.Application.Models.BusinessEntities.Parameters.TypeChauffage;
    using COMPANY.Application.Models.BusinessEntities.Relations.ClientCommercial;
    using COMPANY.Application.Models.BusinessEntities.Relations.ClientRelation;
    using COMPANY.Application.Models.BusinessEntities.Relations.FactureDevis;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountingPeriodModals;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.AddressModel;
    using COMPANY.Application.Models.BusinessEntitiesModels.BankAccountModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.CategoryDocumentsModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.CategoryProductModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.ClientModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.DateInstallationSuiviDossierModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.Documents.Devis;
    using COMPANY.Application.Models.BusinessEntitiesModels.NumerotationModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.PrixProduitParAgenceModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.ProduitModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.RegulationModeModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.SpecialArticleModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.UniteModels;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.Generals;
    using COMPANY.Domain.Entities.Parameters;
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Enums.Documents;
    using Domain.Entities;
    using System;

    public class GlobalsMappingProfile : Profile
    {
        public GlobalsMappingProfile()
        {
            Account();
            Address();
            Agence();
            BankAccount();
            CategoryDocuments();
            Client();
            ConfigMessagerie();
            DocumentParameters();
            CommercialExchange();
            SpecialArticle();
            Numerotation();
            PeriodeComptable();
            Produit();
            RegulationMode();
            Dossier();
            Supplier();
            Devis();
            Contacts();
            Unite();
            CategoryProduct();
            DossierPV();
            FicheControle();
            LogementType();
            DocumentComptable();
            Facture();
            FacturePaiment();
            PaiementMapping();
            AvoirMapping();
            FactureDevis();
            ModeleSms();
            Notification();
            TypeChauffage();
            Sms();
            AgendaEvenementType();
            ClientRelation();
            ChampsSiteInstallation();
            BonComande();
            SourceDuLead();
        }

        #region general

        private void Address()
        {
            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<Departement, DepartementModel>().ReverseMap();
            CreateMap<AddressCreateModel, Address>().ReverseMap();
        }

        private void Contacts()
        {
            CreateMap<Contact, ContactCreateModel>().ReverseMap();
        }

        private void Notification()
        {
            CreateMap<Notification, NotificationModel>().ReverseMap();
            CreateMap<Notification, NotificationPutModel>().ReverseMap();
        }

        private void Sms()
        {
            CreateMap<Sms, SmsModel>()
                .ReverseMap();
        }

        #endregion

        #region account managements

        private void Account()
        {
            CreateMap<User, UserModel>()
                .ReverseMap();

            CreateMap<User, UserCreateModel>()
                .ReverseMap();

            CreateMap<User, UserUpdateModel>()
                .ReverseMap();

            CreateMap<User, LoginModel>()
                .ReverseMap();

            CreateMap<User, UserLiteModel>()
                .ReverseMap();

            CreateMap<Permission, PermissionModel>()
                .ReverseMap();

            CreateMap<PermissionModule, PermissionModuleModel>()
                .ReverseMap();

            CreateMap<Role, RoleModel>()
                .ReverseMap();

            CreateMap<RoleModule, RoleModuleModel>()
               .ReverseMap();
        }

        #endregion

        #region external partners

        private void Agence()
        {
            CreateMap<Agence, AgenceModel>()
                .ReverseMap();

            CreateMap<Agence, AgenceCreateModel>()
                .ReverseMap();

            CreateMap<Agence, AgenceUpdateModel>()
                .ReverseMap();
        }

        private void Client()
        {
            CreateMap<Client, ClientModel>().ReverseMap();
            CreateMap<Client, ClientUpdateModel>().ReverseMap();
            CreateMap<Client, ClientCreateModel>().ReverseMap();
            CreateMap<Client, ClientListModel>().ForMember(d => d.Agence,
                                                        opt => opt.MapFrom(e => e.Agence.RaisonSociale));

            // Client Commercial
            CreateMap<ClientCommercial, ClientCommercialModel>().ReverseMap();
            CreateMap<ClientCommercial, ClientCommercialCreateModel>().ReverseMap();
        }

        private void Supplier()
        {
            CreateMap<Fournisseur, FournisseurModel>().ReverseMap();
            CreateMap<Fournisseur, FournisseurCreateModel>().ReverseMap();
            CreateMap<Fournisseur, FournisseurUpdateModel>().ReverseMap();
        }

        #endregion

        #region parameters

        private void BankAccount()
        {
            CreateMap<BankAccount, BankAccountModel>().ReverseMap();
            CreateMap<BankAccount, BankAccountCreateModel>().ReverseMap();
            CreateMap<BankAccount, BankAccountUpdateModel>().ReverseMap();
        }

        private void CategoryDocuments()
        {
            CreateMap<CategoryDocuments, CategoryDocumentCreateModel>().ReverseMap();
            CreateMap<CategoryDocuments, CategoryDocumentUpdateModel>().ReverseMap();
            CreateMap<CategoryDocuments, CategoryDocumentModel>().ReverseMap();
        }

        private void ConfigMessagerie()
        {
            CreateMap<ConfigMessagerie, ConfigMessagerieModel>().ReverseMap();
            CreateMap<ConfigMessagerie, ConfigMessagerieCreateModel>().ReverseMap();
            CreateMap<ConfigMessagerie, ConfigMessagerieUpdateModel>().ReverseMap();
        }

        private void DocumentParameters()
        {
            CreateMap<DocumentParameters, DocumentParametersModel>().ReverseMap();
            CreateMap<DocumentParameters, DocumentParametersCreateModel>().ReverseMap();
            CreateMap<DocumentParameters, DocumentParametersUpdateModel>().ReverseMap();
        }

        private void SpecialArticle()
        {
            CreateMap<SpecialArticle, SpecialArticleModel>().ReverseMap();
            CreateMap<SpecialArticle, SpecialArticleCreateModel>().ReverseMap();
            CreateMap<SpecialArticle, SpecialArticleUpdateModel>().ReverseMap();
        }

        private void Numerotation()
        {
            CreateMap<Numerotation, NumerotationModel>().ReverseMap();
            CreateMap<Numerotation, NumerotationCreateModel>().ReverseMap();
            CreateMap<Numerotation, NumerotationUpdateModel>().ReverseMap();
        }

        private void PeriodeComptable()
        {
            CreateMap<PeriodeComptableModel, PeriodeComptable>().ReverseMap();
            CreateMap<PeriodeComptableCreateModel, PeriodeComptable>().ReverseMap();
            CreateMap<PeriodeComptableUpdateModel, PeriodeComptable>().ReverseMap();
        }

        private void RegulationMode()
        {
            CreateMap<RegulationMode, RegulationModeModel>().ReverseMap();
            CreateMap<RegulationMode, RegulationModeCreateModel>().ReverseMap();
            CreateMap<RegulationMode, RegulationModeUpdateModel>().ReverseMap();
        }

        private void Unite()
        {
            CreateMap<Unite, UniteModel>().ReverseMap();
            CreateMap<Unite, UniteUpdateModel>().ReverseMap();
            CreateMap<Unite, UniteCreateModel>().ReverseMap();
        }

        private void CategoryProduct()
        {
            CreateMap<CategoryProduct, CategoryProductCreateModel>().ReverseMap();
            CreateMap<CategoryProduct, CategoryProductUpdateModel>().ReverseMap();
            CreateMap<CategoryProduct, CategoryProductModel>().ReverseMap();
        }

        private void LogementType()
        {
            CreateMap<LogementType, LogementTypeModel>().ReverseMap();
            CreateMap<LogementType, LogementTypeCreateModel>().ReverseMap();
            CreateMap<LogementType, LogementTypeUpdateModel>().ReverseMap();
        }

        private void TypeChauffage()
        {
            CreateMap<TypeChauffage, TypeChauffageModel>().ReverseMap();
            CreateMap<TypeChauffage, TypeChauffageCreateModel>().ReverseMap();
            CreateMap<TypeChauffage, TypeChauffageUpdateModel>().ReverseMap();
        }

        private void ModeleSms()
        {
            CreateMap<ModeleSms, ModeleSmsModel>().ReverseMap();
            CreateMap<ModeleSms, ModeleSmsCreateModel>().ReverseMap();
            CreateMap<ModeleSms, ModeleSmsUpdateModel>().ReverseMap();
        }

        private void AgendaEvenementType()
        {
            CreateMap<AgendaEvenement, AgendaEvenementModel>().ReverseMap();
            CreateMap<AgendaEvenement, AgendaEvenementCreateModel>().ReverseMap();
            CreateMap<AgendaEvenement, AgendaEvenementUpdateModel>().ReverseMap();
        }

        private void ChampsSiteInstallation()
        {
            CreateMap<ChampSiteInstallation, ChampSiteInstallationModel>().ReverseMap();
            CreateMap<ChampSiteInstallation, ChampSiteInstallationCreateModel>().ReverseMap();
            CreateMap<ChampSiteInstallation, ChampSiteInstallationUpdateModel>().ReverseMap();
        }

        private void SourceDuLead()
        {
            CreateMap<SourceDuLead, SourceDuLeadModel>().ReverseMap();
            CreateMap<SourceDuLead, SourceDuLeadCreateModel>().ReverseMap();
            CreateMap<SourceDuLead, SourceDuLeadUpdateModel>().ReverseMap();
        }

        #endregion

        #region documents

        private void Dossier()
        {
            // suivi dossier
            CreateMap<Dossier, DossierModel>().ReverseMap();
            CreateMap<Dossier, DossierCreateModel>().ReverseMap();
            CreateMap<Dossier, DossierUpdateModel>().ReverseMap();
            CreateMap<Dossier, DossierAssignationModel>().ReverseMap();

            // date installation suivi dossier
            CreateMap<DossierInstallation, DossierInstallationModel>().ReverseMap();
        }

        private void Devis()
        {
            CreateMap<Devis, DevisModel>()
                .ForMember(e => e.Agence, (opt) => opt.MapFrom(e => e.AgenceId.IsValid() ? e.Agence.RaisonSociale : ""))
                .ReverseMap();
            CreateMap<Devis, DevisCreateModel>().ReverseMap();
            CreateMap<Devis, DevisUpdateModel>().ReverseMap();
            CreateMap<Devis, DevisSignatureModel>().ReverseMap();
            CreateMap<Devis, DevisLiteModel>().ReverseMap();

            CreateMap<Devis, DevisLiteModel>()
                .ForMember(e => e.PrimeCEE, (opt) => opt.MapFrom(e => e.Dossier != null ? e.Dossier.PrimeCEE : default));

        }

        private void DossierPV()
        {
            CreateMap<DossierPV, DossierPVModel>().ReverseMap();
            CreateMap<DossierPV, DossierPVCreateModel>().ReverseMap();
            CreateMap<DossierPV, DossierPVUpdateModel>().ReverseMap();
        }

        private void FicheControle()
        {
            CreateMap<FicheControle, FicheControleModel>()
                .ReverseMap();
            CreateMap<FicheControleCreateModel, FicheControle>()
                .ForMember(e => e.DossierPV, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<FicheControleCreateModel, FicheControle>()
                .ForMember(e => e.DossierPV, opt => opt.Ignore())
                .ReverseMap();
        }

        private void DocumentComptable()
        {
            CreateMap<DocumentComptable, DocumentComptableModel>().ReverseMap();
            CreateMap<DocumentComptable, DocumentComptableCreateModel>().ReverseMap();
            CreateMap<DocumentComptable, DocumentComptableUpdateModel>().ReverseMap();
        }

        private void Facture()
        {
            CreateMap<Facture, FactureModel>().ReverseMap();
            CreateMap<Facture, FactureCreateModel>().ReverseMap();
            CreateMap<Facture, FactureUpdateModel>().ReverseMap();
            CreateMap<Facture, FactureLiteModel>().ReverseMap();
        }

        private void FacturePaiment()
        {
            CreateMap<FacturePaiement, FacturePaiementModel>().ReverseMap();
        }

        private void PaiementMapping()
        {
            CreateMap<Paiement, PaiementModel>().ReverseMap();
            CreateMap<Paiement, PaiementCreateModel>().ReverseMap();
            CreateMap<Paiement, PaiementUpdateModel>().ReverseMap();
            CreateMap<Paiement, PaiementGroupeObligeModel>().ReverseMap();
        }

        private void AvoirMapping()
        {
            CreateMap<Avoir, AvoirModel>().ReverseMap();
            CreateMap<Avoir, AvoirCreateModel>().ReverseMap();
            CreateMap<Avoir, AvoirUpdateModel>().ReverseMap();
        }

        private void BonComande()
        {

            CreateMap<BonCommande, BonCommandeModel>()
                .ForMember(e => e.PrimeCEE, (opt) => opt.MapFrom(e => e.Dossier != null ? e.Dossier.PrimeCEE : default));
        }

        #endregion

        #region commercial exchange

        private void CommercialExchange()
        {
            CreateMap<EchangeCommercial, EchangeCommercialModel>()
                .ForMember(e => e.Time, e => e.MapFrom(f => new TimeSpan(f.DateEvent.Hour, f.DateEvent.Minute, f.DateEvent.Second)));

            CreateMap<EchangeCommercial, EchangeCommercialUpdateModel>()
                .ReverseMap();

            CreateMap<EchangeCommercialCreateModel, EchangeCommercial>()
                .ForMember(e => e.DateEvent, e => e.MapFrom(f => f.Time.HasValue ? f.DateEvent.Date + f.Time.Value : f.DateEvent.Date))
                .ReverseMap();
        }

        #endregion

        #region products

        private void Produit()
        {
            // produit
            CreateMap<Produit, ProduitModel>().ReverseMap();
            CreateMap<Produit, ProduitCreateModel>().ReverseMap();
            CreateMap<Produit, ProduitUpdateModel>().ReverseMap();

            // prix Produit par agence
            CreateMap<PrixProduitParAgence, PrixProduitParAgenceModel>().ReverseMap();
            CreateMap<PrixProduitParAgence, PrixProduitParAgenceUpdateModel>().ReverseMap();
            CreateMap<PrixProduitParAgence, PrixProduitParAgenceCreateModel>().ReverseMap();
        }

        #endregion

        #region relations

        public void FactureDevis()
        {
            CreateMap<FactureDevis, FactureDevisModel>()
                .ReverseMap();
            CreateMap<FactureDevis, FactureDevisCreateModel>()
                .ReverseMap();
        }

        public void ClientRelation()
        {
            CreateMap<ClientRelation, ClientRelationModel>()
                .ReverseMap();
            CreateMap<ClientRelation, ClientRelationCreateModel>()
                .ReverseMap();
        }

        #endregion

    }
}
