using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieEvenements",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieEvenements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDocuments",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProducts",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    AccountingCode = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Code = table.Column<int>(nullable: false),
                    NomEnGb = table.Column<string>(maxLength: 256, nullable: true),
                    NomFrFr = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Reference = table.Column<string>(maxLength: 256, nullable: true),
                    RaisonSociale = table.Column<string>(maxLength: 256, nullable: false),
                    Historique = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    WebSite = table.Column<string>(maxLength: 256, nullable: true),
                    CodeComptable = table.Column<string>(maxLength: 256, nullable: true),
                    Siret = table.Column<string>(maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Contact = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogementTypes",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeleSms",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Text = table.Column<string>(type: "LONGTEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeleSms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdvTypes",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdvTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegulationModes",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    IsModify = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegulationModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialArticles",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Designation = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TacheTypes",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacheTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unites",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Abbreviation = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    DepartementCode = table.Column<string>(maxLength: 256, nullable: true),
                    DepartementNom = table.Column<string>(maxLength: 256, nullable: true),
                    CountryId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departements_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    ModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleModules",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleModules_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avoirs",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Reference = table.Column<string>(maxLength: 256, nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false),
                    Articles = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Objet = table.Column<string>(maxLength: 256, nullable: true),
                    Comptabilise = table.Column<bool>(nullable: false),
                    ReglementCondition = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Note = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Counter = table.Column<int>(nullable: true),
                    TotalHT = table.Column<decimal>(nullable: false),
                    TotalTTC = table.Column<decimal>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false),
                    RemiseType = table.Column<int>(nullable: false),
                    Historique = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Memos = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Emails = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    ClientId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    FactureId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avoirs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    CodeComptable = table.Column<string>(maxLength: 256, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    IsModify = table.Column<bool>(nullable: false),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Reference = table.Column<string>(maxLength: 256, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    WebSite = table.Column<string>(maxLength: 256, nullable: true),
                    Siret = table.Column<string>(maxLength: 256, nullable: true),
                    CodeComptable = table.Column<string>(maxLength: 256, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    Address = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Contacts = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    SourceLead = table.Column<int>(nullable: false),
                    DateReceptionLead = table.Column<DateTime>(nullable: true),
                    ParcelleCadastrale = table.Column<string>(maxLength: 256, nullable: true),
                    SurfaceTraiter = table.Column<string>(maxLength: 256, nullable: true),
                    NombrePersonne = table.Column<string>(maxLength: 256, nullable: true),
                    IsMaisonDePlusDeDeuxAns = table.Column<bool>(nullable: true),
                    Precarite = table.Column<int>(nullable: true),
                    RevenueFiscaleReference = table.Column<string>(maxLength: 256, nullable: true),
                    NumeroAH = table.Column<string>(maxLength: 256, nullable: true),
                    TypeTravaux = table.Column<int>(nullable: true),
                    LabelPrimeCEE = table.Column<string>(maxLength: 256, nullable: true),
                    NoteDevis = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    LogementTypeId = table.Column<string>(maxLength: 256, nullable: true),
                    PrimeCEEId = table.Column<string>(maxLength: 256, nullable: true),
                    CommercialId = table.Column<string>(maxLength: 256, nullable: true),
                    RegulationModeId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true),
                    ClientLoginId = table.Column<string>(maxLength: 256, nullable: true),
                    Historique = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Memo = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_LogementTypes_LogementTypeId",
                        column: x => x.LogementTypeId,
                        principalTable: "LogementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_Clients_PrimeCEEId",
                        column: x => x.PrimeCEEId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Clients_RegulationModes_RegulationModeId",
                        column: x => x.RegulationModeId,
                        principalTable: "RegulationModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ConfigMessageries",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Username = table.Column<string>(maxLength: 256, nullable: true),
                    Password = table.Column<string>(maxLength: 256, nullable: true),
                    Server = table.Column<string>(maxLength: 256, nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Ssl = table.Column<bool>(nullable: false),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigMessageries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devis",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Reference = table.Column<string>(maxLength: 256, nullable: true),
                    SiteIntervention = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    DateVisit = table.Column<DateTime>(nullable: false),
                    Articles = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    TotalHT = table.Column<decimal>(nullable: false),
                    TotalTTC = table.Column<decimal>(nullable: false),
                    TotalReduction = table.Column<decimal>(nullable: false),
                    TotalPaid = table.Column<decimal>(nullable: false),
                    RaisonPerdue = table.Column<string>(maxLength: 256, nullable: true),
                    DateSignature = table.Column<DateTime>(nullable: true),
                    Signe = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    NameClientSignature = table.Column<string>(maxLength: 256, nullable: true),
                    Note = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Photos = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Historique = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Emails = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    UserId = table.Column<string>(maxLength: 256, nullable: true),
                    ClientId = table.Column<string>(maxLength: 256, nullable: true),
                    DossierId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devis_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentParameters",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    TVA = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Facture = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Avoir = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Devis = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Reference = table.Column<string>(maxLength: 256, nullable: false),
                    DatePose = table.Column<DateTime>(nullable: false),
                    Contacts = table.Column<string>(maxLength: 256, nullable: true),
                    SiteIntervention = table.Column<string>(maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 256, nullable: true),
                    Historique = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Memo = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    SourceLead = table.Column<int>(nullable: false),
                    DateReceptionLead = table.Column<DateTime>(nullable: true),
                    ParcelleCadastrale = table.Column<string>(maxLength: 256, nullable: true),
                    SurfaceTraiter = table.Column<string>(maxLength: 256, nullable: true),
                    NombrePersonne = table.Column<string>(maxLength: 256, nullable: true),
                    IsMaisonDePlusDeDeuxAns = table.Column<bool>(nullable: true),
                    Precarite = table.Column<int>(nullable: true),
                    RevenueFiscaleReference = table.Column<string>(maxLength: 256, nullable: true),
                    NumeroAH = table.Column<string>(maxLength: 256, nullable: true),
                    TypeTravaux = table.Column<int>(nullable: true),
                    CommercialId = table.Column<string>(maxLength: 256, nullable: true),
                    DateRDV = table.Column<DateTime>(nullable: true),
                    LogementTypeId = table.Column<string>(maxLength: 256, nullable: true),
                    PrimeCEEId = table.Column<string>(maxLength: 256, nullable: true),
                    ClientId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dossiers_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dossiers_LogementTypes_LogementTypeId",
                        column: x => x.LogementTypeId,
                        principalTable: "LogementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dossiers_Clients_PrimeCEEId",
                        column: x => x.PrimeCEEId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EchangeCommercials",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Titre = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    DateEvent = table.Column<DateTime>(nullable: false),
                    Duree = table.Column<TimeSpan>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Priorite = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Contacts = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Memos = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Historique = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    TacheTypeId = table.Column<string>(maxLength: 256, nullable: true),
                    RdvTypeId = table.Column<string>(maxLength: 256, nullable: true),
                    CategorieId = table.Column<string>(maxLength: 256, nullable: true),
                    ResponsableId = table.Column<string>(maxLength: 256, nullable: true),
                    ClientId = table.Column<string>(maxLength: 256, nullable: true),
                    DossierId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EchangeCommercials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EchangeCommercials_CategorieEvenements_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "CategorieEvenements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EchangeCommercials_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EchangeCommercials_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_EchangeCommercials_RdvTypes_RdvTypeId",
                        column: x => x.RdvTypeId,
                        principalTable: "RdvTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EchangeCommercials_TacheTypes_TacheTypeId",
                        column: x => x.TacheTypeId,
                        principalTable: "TacheTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Reference = table.Column<string>(maxLength: 256, nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false),
                    Articles = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Objet = table.Column<string>(maxLength: 256, nullable: true),
                    Comptabilise = table.Column<bool>(nullable: false),
                    ReglementCondition = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Note = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Counter = table.Column<int>(nullable: true),
                    TotalHT = table.Column<decimal>(nullable: false),
                    TotalTTC = table.Column<decimal>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false),
                    RemiseType = table.Column<int>(nullable: false),
                    Historique = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Memos = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Emails = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    ClientId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    TotalReduction = table.Column<decimal>(nullable: false),
                    TotalPaid = table.Column<decimal>(nullable: false),
                    NumeroAH = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factures_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactureDevis",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Montant = table.Column<decimal>(nullable: false),
                    MontantType = table.Column<int>(nullable: false),
                    DevisId = table.Column<string>(maxLength: 256, nullable: true),
                    FactureId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactureDevis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactureDevis_Devis_DevisId",
                        column: x => x.DevisId,
                        principalTable: "Devis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactureDevis_Factures_FactureId",
                        column: x => x.FactureId,
                        principalTable: "Factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Numerotations",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Root = table.Column<string>(maxLength: 256, nullable: true),
                    DateFormat = table.Column<int>(nullable: false),
                    Counter = table.Column<int>(nullable: false),
                    CounterLength = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numerotations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paiements",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Montant = table.Column<decimal>(nullable: false),
                    DatePaiement = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Historique = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Comptabilise = table.Column<bool>(nullable: false),
                    BankAccountId = table.Column<string>(maxLength: 256, nullable: true),
                    RegulationModeId = table.Column<string>(maxLength: 256, nullable: true),
                    AvoirId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true),
                    PaiementId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paiements_Avoirs_AvoirId",
                        column: x => x.AvoirId,
                        principalTable: "Avoirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Paiements_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paiements_Paiements_PaiementId",
                        column: x => x.PaiementId,
                        principalTable: "Paiements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paiements_RegulationModes_RegulationModeId",
                        column: x => x.RegulationModeId,
                        principalTable: "RegulationModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacturePaiements",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Montant = table.Column<decimal>(nullable: false),
                    PaiementId = table.Column<string>(maxLength: 256, nullable: true),
                    FactureId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturePaiements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturePaiements_Factures_FactureId",
                        column: x => x.FactureId,
                        principalTable: "Factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturePaiements_Paiements_PaiementId",
                        column: x => x.PaiementId,
                        principalTable: "Paiements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeriodeComptables",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    DateCloture = table.Column<DateTime>(nullable: true),
                    IsClose = table.Column<bool>(nullable: false),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true),
                    UserId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodeComptables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrixProduitParAgences",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    PrixHT = table.Column<decimal>(nullable: false),
                    TVA = table.Column<double>(nullable: false),
                    ProduitId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrixProduitParAgences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Reference = table.Column<string>(maxLength: 256, nullable: true),
                    PrixAchat = table.Column<decimal>(nullable: true),
                    PrixHT = table.Column<decimal>(nullable: false),
                    TVA = table.Column<double>(nullable: false),
                    Description = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Designation = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    PrixParTranche = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Unite = table.Column<string>(maxLength: 256, nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    Labels = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Memos = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Historique = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    FournisseurId = table.Column<string>(maxLength: 256, nullable: true),
                    CategoryId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produits_CategoryProducts_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Produits_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Passwordhash = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LastConnection = table.Column<DateTime>(nullable: true),
                    AccessfailedCount = table.Column<int>(nullable: false),
                    RegistrationNumber = table.Column<string>(maxLength: 256, nullable: true),
                    Historique = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Memos = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    GoogleCalendarId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agence",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Reference = table.Column<string>(maxLength: 256, nullable: true),
                    RaisonSociale = table.Column<string>(maxLength: 256, nullable: true),
                    FormeJuridique = table.Column<string>(maxLength: 256, nullable: true),
                    Capital = table.Column<string>(maxLength: 256, nullable: true),
                    NumeroTvaINTRA = table.Column<string>(maxLength: 256, nullable: true),
                    Siret = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 256, nullable: true),
                    CodeComptable = table.Column<string>(maxLength: 256, nullable: true),
                    DateDebutActivite = table.Column<DateTime>(nullable: true),
                    DateFinActivite = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AdresseFacturation = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    AdresseLivraison = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Contacts = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Memo = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Historique = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    RegulationModeId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceLoginId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agence_Users_AgenceLoginId",
                        column: x => x.AgenceLoginId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agence_RegulationModes_RegulationModeId",
                        column: x => x.RegulationModeId,
                        principalTable: "RegulationModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DossierInstallations",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    DateInstallation = table.Column<DateTime>(nullable: false),
                    TechnicienId = table.Column<string>(maxLength: 256, nullable: true),
                    DossierId = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierInstallations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DossierInstallations_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DossierInstallations_Users_TechnicienId",
                        column: x => x.TechnicienId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FicheControles",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    NumberOperation = table.Column<string>(maxLength: 256, nullable: true),
                    DateControle = table.Column<DateTime>(nullable: false),
                    PrestationType = table.Column<int>(nullable: false),
                    Photos = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    ConstatCombles = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    ConstatPlanchers = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    ConstatMurs = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Remarques = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    EvaluationAccompagnement = table.Column<int>(nullable: false),
                    EvaluationTravauxRealises = table.Column<int>(nullable: false),
                    EvaluationPropreteChantier = table.Column<int>(nullable: false),
                    EvaluationContactAvecTechniciensApplicateurs = table.Column<int>(nullable: false),
                    SignatureController = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    SignatureClient = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    NameClientSignature = table.Column<string>(maxLength: 256, nullable: true),
                    ControllerId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FicheControles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FicheControles_Users_ControllerId",
                        column: x => x.ControllerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoogleCalendarEchangeCommercials",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    ExternalEventId = table.Column<string>(maxLength: 256, nullable: true),
                    CalendarId = table.Column<string>(maxLength: 256, nullable: true),
                    EchangeCommercialId = table.Column<string>(maxLength: 256, nullable: true),
                    UserId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleCalendarEchangeCommercials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoogleCalendarEchangeCommercials_EchangeCommercials_EchangeC~",
                        column: x => x.EchangeCommercialId,
                        principalTable: "EchangeCommercials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoogleCalendarEchangeCommercials_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: true),
                    DocType = table.Column<int>(nullable: false),
                    IdentityDocument = table.Column<string>(maxLength: 256, nullable: true),
                    IsSeen = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DossierPVs",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Photos = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Article = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    IsSatisfied = table.Column<bool>(nullable: false),
                    ReasonNoSatisfaction = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    NameClientSignature = table.Column<string>(maxLength: 256, nullable: true),
                    SignatureClient = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    SignatureTechnicien = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    FicheControleId = table.Column<string>(maxLength: 256, nullable: true),
                    DossierId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierPVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DossierPVs_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DossierPVs_FicheControles_FicheControleId",
                        column: x => x.FicheControleId,
                        principalTable: "FicheControles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "AgenceId", "CodeComptable", "CreatedOn", "IsModify", "LastModifiedOn", "Name", "SearchTerms", "Type" },
                values: new object[] { "BankAccount::1", null, "44553", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, null, "Caisse", null, 1 });

            migrationBuilder.InsertData(
                table: "LogementTypes",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[,]
                {
                    { "LogementType::1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Appartement", null },
                    { "LogementType::2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Maison", null }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[,]
                {
                    { 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Fournisseurs", null },
                    { 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", null },
                    { 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Users", null },
                    { 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", null },
                    { 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Agence", null },
                    { 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Suivi Dossier", null },
                    { 9, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Agenda Commercial", null },
                    { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", null },
                    { 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", null }
                });

            migrationBuilder.InsertData(
                table: "RegulationModes",
                columns: new[] { "Id", "CreatedOn", "IsModify", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[,]
                {
                    { "RegulationMode::7", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, null, "Avoir", null },
                    { "RegulationMode::6", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, null, "Virement", null },
                    { "RegulationMode::1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, null, "Carte bancaire", null },
                    { "RegulationMode::2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, null, "Chèque", null },
                    { "RegulationMode::3", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, null, "Espèces", null },
                    { "RegulationMode::4", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, null, "Paypal", null },
                    { "RegulationMode::5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, null, "Prélevèment", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[,]
                {
                    { 7, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Admin Agence", "agence admin" },
                    { 4, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "technicien", "technicien" },
                    { 6, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Commercial", "commercial" },
                    { 3, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "directeurCommercial", "directeur commercial" },
                    { 5, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "manager", "manager" },
                    { 1, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "admin", "admin" },
                    { 2, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "controleur", "controleur" }
                });

            migrationBuilder.InsertData(
                table: "TacheTypes",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[,]
                {
                    { "TacheType::2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Appel", null },
                    { "TacheType::1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Tâche", null }
                });

            migrationBuilder.InsertData(
                table: "Unites",
                columns: new[] { "Id", "Abbreviation", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[,]
                {
                    { "Unite::21", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "BO", null },
                    { "Unite::20", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "mm", null },
                    { "Unite::19", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "mg", null },
                    { "Unite::18", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "t", null },
                    { "Unite::17", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "cm3", null },
                    { "Unite::16", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "cm2", null },
                    { "Unite::15", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "cm", null },
                    { "Unite::14", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "km", null },
                    { "Unite::13", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "lot", null },
                    { "Unite::12", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "mL", null },
                    { "Unite::10", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "g", null },
                    { "Unite::9", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "j", null },
                    { "Unite::8", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "m", null },
                    { "Unite::7", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "U", null },
                    { "Unite::6", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "L", null },
                    { "Unite::5", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "m3", null },
                    { "Unite::4", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "m2", null },
                    { "Unite::3", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "h", null },
                    { "Unite::2", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "kg", null },
                    { "Unite::1", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "€", null },
                    { "Unite::22", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "BOI", null },
                    { "Unite::11", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "min", null },
                    { "Unite::23", null, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), null, "TUB", null }
                });

            migrationBuilder.InsertData(
                table: "RoleModules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "ModuleId", "RoleId", "SearchTerms" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 1, null },
                    { 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 5, null },
                    { 9, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 2, 5, null },
                    { 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 3, 5, null },
                    { 17, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 6, 5, null },
                    { 21, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 5, 5, null },
                    { 27, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 7, 5, null },
                    { 31, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 8, 5, null },
                    { 34, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 9, 4, null },
                    { 35, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 9, 5, null },
                    { 37, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 9, 6, null },
                    { 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 7, null },
                    { 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 2, 7, null },
                    { 14, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 3, 7, null },
                    { 18, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 6, 7, null },
                    { 22, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 5, 7, null },
                    { 28, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 7, 7, null },
                    { 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 6, null },
                    { 32, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 8, 7, null },
                    { 30, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 8, 4, null },
                    { 24, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 4, 4, null },
                    { 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 2, 1, null },
                    { 11, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 3, 1, null },
                    { 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 6, 1, null },
                    { 19, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 5, 1, null },
                    { 23, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 4, 1, null },
                    { 25, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 7, 1, null },
                    { 29, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 8, 1, null },
                    { 26, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 7, 4, null },
                    { 33, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 9, 1, null },
                    { 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 3, null },
                    { 39, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 9, 3, null },
                    { 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 1, 4, null },
                    { 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 2, 4, null },
                    { 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 3, 4, null },
                    { 16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 6, 4, null },
                    { 20, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 5, 4, null },
                    { 38, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 9, 2, null },
                    { 36, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 9, 7, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agence_AgenceLoginId",
                table: "Agence",
                column: "AgenceLoginId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agence_RegulationModeId",
                table: "Agence",
                column: "RegulationModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Agence_SearchTerms",
                table: "Agence",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Avoirs_AgenceId",
                table: "Avoirs",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Avoirs_ClientId",
                table: "Avoirs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Avoirs_FactureId",
                table: "Avoirs",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_Avoirs_SearchTerms",
                table: "Avoirs",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_AgenceId",
                table: "BankAccounts",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_SearchTerms",
                table: "BankAccounts",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieEvenements_SearchTerms",
                table: "CategorieEvenements",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducts_SearchTerms",
                table: "CategoryProducts",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AgenceId",
                table: "Clients",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientLoginId",
                table: "Clients",
                column: "ClientLoginId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CommercialId",
                table: "Clients",
                column: "CommercialId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LogementTypeId",
                table: "Clients",
                column: "LogementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PrimeCEEId",
                table: "Clients",
                column: "PrimeCEEId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_RegulationModeId",
                table: "Clients",
                column: "RegulationModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SearchTerms",
                table: "Clients",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigMessageries_AgenceId",
                table: "ConfigMessageries",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigMessageries_SearchTerms",
                table: "ConfigMessageries",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SearchTerms",
                table: "Countries",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Departements_CountryId",
                table: "Departements",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Departements_SearchTerms",
                table: "Departements",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Devis_AgenceId",
                table: "Devis",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Devis_ClientId",
                table: "Devis",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Devis_DossierId",
                table: "Devis",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_Devis_SearchTerms",
                table: "Devis",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Devis_UserId",
                table: "Devis",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentParameters_AgenceId",
                table: "DocumentParameters",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentParameters_SearchTerms",
                table: "DocumentParameters",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_DossierInstallations_DossierId",
                table: "DossierInstallations",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_DossierInstallations_SearchTerms",
                table: "DossierInstallations",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_DossierInstallations_TechnicienId",
                table: "DossierInstallations",
                column: "TechnicienId");

            migrationBuilder.CreateIndex(
                name: "IX_DossierPVs_DossierId",
                table: "DossierPVs",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_DossierPVs_FicheControleId",
                table: "DossierPVs",
                column: "FicheControleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DossierPVs_SearchTerms",
                table: "DossierPVs",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_AgenceId",
                table: "Dossiers",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_ClientId",
                table: "Dossiers",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_CommercialId",
                table: "Dossiers",
                column: "CommercialId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_LogementTypeId",
                table: "Dossiers",
                column: "LogementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_PrimeCEEId",
                table: "Dossiers",
                column: "PrimeCEEId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_SearchTerms",
                table: "Dossiers",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_AgenceId",
                table: "EchangeCommercials",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_CategorieId",
                table: "EchangeCommercials",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_ClientId",
                table: "EchangeCommercials",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_DossierId",
                table: "EchangeCommercials",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_RdvTypeId",
                table: "EchangeCommercials",
                column: "RdvTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_ResponsableId",
                table: "EchangeCommercials",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_SearchTerms",
                table: "EchangeCommercials",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_TacheTypeId",
                table: "EchangeCommercials",
                column: "TacheTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FactureDevis_DevisId",
                table: "FactureDevis",
                column: "DevisId");

            migrationBuilder.CreateIndex(
                name: "IX_FactureDevis_FactureId",
                table: "FactureDevis",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_FactureDevis_SearchTerms",
                table: "FactureDevis",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_FacturePaiements_FactureId",
                table: "FacturePaiements",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturePaiements_PaiementId",
                table: "FacturePaiements",
                column: "PaiementId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturePaiements_SearchTerms",
                table: "FacturePaiements",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_AgenceId",
                table: "Factures",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ClientId",
                table: "Factures",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_SearchTerms",
                table: "Factures",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_FicheControles_ControllerId",
                table: "FicheControles",
                column: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_FicheControles_SearchTerms",
                table: "FicheControles",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Fournisseurs_SearchTerms",
                table: "Fournisseurs",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleCalendarEchangeCommercials_EchangeCommercialId",
                table: "GoogleCalendarEchangeCommercials",
                column: "EchangeCommercialId");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleCalendarEchangeCommercials_SearchTerms",
                table: "GoogleCalendarEchangeCommercials",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleCalendarEchangeCommercials_UserId",
                table: "GoogleCalendarEchangeCommercials",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LogementTypes_SearchTerms",
                table: "LogementTypes",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_SearchTerms",
                table: "Modules",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SearchTerms",
                table: "Notifications",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Numerotations_AgenceId",
                table: "Numerotations",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Numerotations_SearchTerms",
                table: "Numerotations",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_AgenceId",
                table: "Paiements",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_AvoirId",
                table: "Paiements",
                column: "AvoirId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_BankAccountId",
                table: "Paiements",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_PaiementId",
                table: "Paiements",
                column: "PaiementId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_RegulationModeId",
                table: "Paiements",
                column: "RegulationModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_SearchTerms",
                table: "Paiements",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeComptables_AgenceId",
                table: "PeriodeComptables",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeComptables_SearchTerms",
                table: "PeriodeComptables",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeComptables_UserId",
                table: "PeriodeComptables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ModuleId",
                table: "Permissions",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_SearchTerms",
                table: "Permissions",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_PrixProduitParAgences_AgenceId",
                table: "PrixProduitParAgences",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_PrixProduitParAgences_ProduitId",
                table: "PrixProduitParAgences",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_PrixProduitParAgences_SearchTerms",
                table: "PrixProduitParAgences",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_AgenceId",
                table: "Produits",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategoryId",
                table: "Produits",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_FournisseurId",
                table: "Produits",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_SearchTerms",
                table: "Produits",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_RdvTypes_SearchTerms",
                table: "RdvTypes",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_RegulationModes_SearchTerms",
                table: "RegulationModes",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModules_ModuleId",
                table: "RoleModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModules_RoleId",
                table: "RoleModules",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModules_SearchTerms",
                table: "RoleModules",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_SearchTerms",
                table: "RolePermissions",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_SearchTerms",
                table: "Roles",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialArticles_SearchTerms",
                table: "SpecialArticles",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_TacheTypes_SearchTerms",
                table: "TacheTypes",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Unites_SearchTerms",
                table: "Unites",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AgenceId",
                table: "Users",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SearchTerms",
                table: "Users",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Avoirs_Agence_AgenceId",
                table: "Avoirs",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Avoirs_Clients_ClientId",
                table: "Avoirs",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Avoirs_Factures_FactureId",
                table: "Avoirs",
                column: "FactureId",
                principalTable: "Factures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Agence_AgenceId",
                table: "BankAccounts",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_ClientLoginId",
                table: "Clients",
                column: "ClientLoginId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CommercialId",
                table: "Clients",
                column: "CommercialId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Agence_AgenceId",
                table: "Clients",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigMessageries_Agence_AgenceId",
                table: "ConfigMessageries",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devis_Users_UserId",
                table: "Devis",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devis_Agence_AgenceId",
                table: "Devis",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devis_Dossiers_DossierId",
                table: "Devis",
                column: "DossierId",
                principalTable: "Dossiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentParameters_Agence_AgenceId",
                table: "DocumentParameters",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_Users_CommercialId",
                table: "Dossiers",
                column: "CommercialId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_Agence_AgenceId",
                table: "Dossiers",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_Users_ResponsableId",
                table: "EchangeCommercials",
                column: "ResponsableId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_Agence_AgenceId",
                table: "EchangeCommercials",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factures_Agence_AgenceId",
                table: "Factures",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Numerotations_Agence_AgenceId",
                table: "Numerotations",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paiements_Agence_AgenceId",
                table: "Paiements",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodeComptables_Users_UserId",
                table: "PeriodeComptables",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodeComptables_Agence_AgenceId",
                table: "PeriodeComptables",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrixProduitParAgences_Agence_AgenceId",
                table: "PrixProduitParAgences",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrixProduitParAgences_Produits_ProduitId",
                table: "PrixProduitParAgences",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_Agence_AgenceId",
                table: "Produits",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Agence_AgenceId",
                table: "Users",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agence_Users_AgenceLoginId",
                table: "Agence");

            migrationBuilder.DropTable(
                name: "CategoryDocuments");

            migrationBuilder.DropTable(
                name: "ConfigMessageries");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "DocumentParameters");

            migrationBuilder.DropTable(
                name: "DossierInstallations");

            migrationBuilder.DropTable(
                name: "DossierPVs");

            migrationBuilder.DropTable(
                name: "FactureDevis");

            migrationBuilder.DropTable(
                name: "FacturePaiements");

            migrationBuilder.DropTable(
                name: "GoogleCalendarEchangeCommercials");

            migrationBuilder.DropTable(
                name: "ModeleSms");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Numerotations");

            migrationBuilder.DropTable(
                name: "PeriodeComptables");

            migrationBuilder.DropTable(
                name: "PrixProduitParAgences");

            migrationBuilder.DropTable(
                name: "RoleModules");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "SpecialArticles");

            migrationBuilder.DropTable(
                name: "Unites");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "FicheControles");

            migrationBuilder.DropTable(
                name: "Devis");

            migrationBuilder.DropTable(
                name: "Paiements");

            migrationBuilder.DropTable(
                name: "EchangeCommercials");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Avoirs");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "CategorieEvenements");

            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropTable(
                name: "RdvTypes");

            migrationBuilder.DropTable(
                name: "TacheTypes");

            migrationBuilder.DropTable(
                name: "CategoryProducts");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "LogementTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Agence");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "RegulationModes");
        }
    }
}
