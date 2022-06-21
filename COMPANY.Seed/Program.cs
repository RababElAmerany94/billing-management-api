namespace COMPANY.Seed
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Presistence;
    using COMPANY.Seed.Models;
    using Inova.AutoInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using OfficeOpenXml;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = RegisterDependencyInjection();
            ILogger logger = RegisterLogger();
            IConfigurationRoot config = RegisterConfiguration();
            RegisterPersistenceLayer(services, config);

            var serviceProvider = services.BuildServiceProvider(true);
            IServiceScope scope = serviceProvider.CreateScope();
            var unitOfwork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            logger.LogInformation("Init ....");

            try
            {
                SeedProduits(unitOfwork);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurs during seed produits");
            }

            logger.LogInformation("Finish importation");

            Console.ReadKey();
        }

        private static void SeedProduits(IUnitOfWork unitOfwork)
        {
            var produitsToImport =
                ImportProduitFromFicherExcel(".\\Files\\produits_1.xlsx")
                .Concat(ImportProduitFromFicherExcel(".\\Files\\produits_2.xlsx"))
                .Where(e => e.Designation.IsValid() || e.Reference.IsValid() || e.Description.IsValid())
                .ToList();

            var fournisseurs = produitsToImport
                .Select(e => e.Fournisseur)
                .GroupBy(e => e, StringComparer.InvariantCultureIgnoreCase)
                .Select((e, index) => new Fournisseur()
                {
                    RaisonSociale = e.Key,
                    CodeComptable = e.Key.ToLower(),
                    Reference = $"FR::{(index + 2).ToString().PadLeft(5, '0')}",
                    CreatedOn = DateTimeOffset.Now,
                    LastModifiedOn = DateTimeOffset.Now,
                })
                .ToList();


            unitOfwork
                .DataAccess<Fournisseur, string>()
                .AddRangeAsync(fournisseurs)
                .GetAwaiter()
                .GetResult();

            var category = new CategoryProduct()
            {
                AccountingCode = "",
                Id = "CategoryProduct::01",
                Name = "Produit",
                CreatedOn = DateTimeOffset.Now,
                LastModifiedOn = DateTimeOffset.Now,
            };

            unitOfwork
                .DataAccess<CategoryProduct, string>()
                .AddAsync(category)
                .GetAwaiter()
                .GetResult();

            var produits = produitsToImport
                .Select(e => new Produit()
                {
                    CreatedOn = DateTimeOffset.Now,
                    LastModifiedOn = DateTimeOffset.Now,
                    Reference = e.Reference,
                    Designation = e.Designation,
                    Description = e.Description,
                    FournisseurId = e.Fournisseur.IsValid() ? fournisseurs.FirstOrDefault(f => f.RaisonSociale.ToLower().Equals(e.Fournisseur.ToLower())).Id : null,
                    Unite = e.Unite,
                    PrixAchat = e.PrixAchat,
                    PrixHT = e.PrixHT,
                    IsPublic = e.Visible,
                    Labels = e.Labels.IsValid() ? e.Labels.Split(',').ToList() : new List<string>(),
                    CategoryId = category.Id
                })
                .ToList();

            unitOfwork
                .DataAccess<Produit, string>()
                .AddRangeAsync(produits)
                .GetAwaiter()
                .GetResult();

            unitOfwork
                .SaveChangesAsync()
                .GetAwaiter()
                .GetResult();
        }

        private static List<ProduitDatabaseModel> ImportProduitFromFicherExcel(string path)
        {
            byte[] bin = File.ReadAllBytes(path);
            var cars = new List<ProduitDatabaseModel>();

            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                    {
                        decimal.TryParse(worksheet.Cells[i, worksheet.Dimension.Start.Column + 3].Value?.ToString() ?? "", out decimal prixAchat);
                        decimal.TryParse(worksheet.Cells[i, worksheet.Dimension.Start.Column + 4].Value?.ToString() ?? "", out decimal prixHT);
                        decimal.TryParse(worksheet.Cells[i, worksheet.Dimension.Start.Column + 5].Value?.ToString() ?? "", out decimal tva);
                        var visible = (worksheet.Cells[i, worksheet.Dimension.Start.Column + 7].Value?.ToString() ?? "").Trim().ToLower();

                        var car = new ProduitDatabaseModel(
                            reference: worksheet.Cells[i, worksheet.Dimension.Start.Column]?.Value?.ToString() ?? "",
                            designation: worksheet.Cells[i, worksheet.Dimension.Start.Column + 1].Value?.ToString() ?? "",
                            description: worksheet.Cells[i, worksheet.Dimension.Start.Column + 2].Value?.ToString() ?? "",
                            prixAchat: prixAchat,
                            prixHT: prixHT,
                            tva: tva,
                            unite: worksheet.Cells[i, worksheet.Dimension.Start.Column + 6].Value?.ToString() ?? "",
                            visible: visible.IsValid() && visible == "oui",
                            labels: worksheet.Cells[i, worksheet.Dimension.Start.Column + 8].Value?.ToString() ?? "",
                            fournisseur: worksheet.Cells[i, worksheet.Dimension.Start.Column + 9].Value?.ToString() ?? "",
                            categorie: worksheet.Cells[i, worksheet.Dimension.Start.Column + 10].Value?.ToString() ?? ""
                        );
                        cars.Add(car);
                    }
                }
            }

            return cars;
        }

        private static ServiceCollection RegisterDependencyInjection()
        {
            var services = new ServiceCollection();
            services.Inject();

            //IServiceScope scope = _serviceProvider.CreateScope();
            //scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();
            return services;
        }

        private static ILogger RegisterLogger()
        {
            ILoggerFactory loggerFactory = new LoggerFactory().AddConsole();
            ILogger logger = loggerFactory.CreateLogger<Program>();
            return logger;
        }

        private static IConfigurationRoot RegisterConfiguration()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            return config;
        }

        private static void RegisterPersistenceLayer(ServiceCollection services, IConfigurationRoot config)
        {
            services.AddPresistenceLayer(options =>
            {
                options.ConnectionString = config.GetConnectionString("DefaultConnection");
            });
        }
    }
}
