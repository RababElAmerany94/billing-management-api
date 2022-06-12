namespace COMPANY.Presentation
{
    using Application.Data;
    using AutoMapper;
    using COMPANY.Application;
    using COMPANY.Application.Models.GeneralModels;
    using COMPANY.BackgroundServices;
    using COMPANY.Infrastructure.Utilities;
    using COMPANY.Presentation.BackgroundServices;
    using COMPANY.Presistence.Builders;
    using COMPANY.Presistence.DataContext;
    using Coravel;
    using Company.AutoInjection;
    using Company.AutoMapperRegister;
    using Company.SpotHit.Models;
    using Company.SpotHit.Utilities;
    using CompanyFileManager.Extensions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Presistence;
    using Serilog;
    using Swashbuckle.AspNetCore.Swagger;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// a class for adding application extensions and register application dependencies
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// add the Application Core Functionalities
        /// </summary>
        /// <param name="services">the DI Service Collection</param>
        /// <param name="configuration">the configuration manager</param>
        internal static void AddCompanyConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // set the globalConfig
            services.Configure<AppSettings>(configuration);

            var connectionStrings = new ConnectionStrings();
            configuration.Bind("ConnectionStrings", connectionStrings);

            // register automapper
            services.RegisterAutoMapper();

            // add database
            services.ConfigureDb(configuration.GetConnectionString("DefaultConnection"));

            // configure logger
            ConfigureLogger(connectionStrings.SerilogConnection);

            // register AutoMapper
            services.AddAutoMapper(typeof(GlobalsMappingProfile).Assembly);

            // configure Company File manager
            services.AddCompanyFileManager(configuration.GetSection("CompanyFileManager").GetSection("Path").Value);

            // Register Builders and Factories
            services.RegiseterApplicationFactoriesAndBuilders();

            // auto inject dependencies
            services.Inject();

            // register DataAccess
            services.AddPresistenceLayer(options =>
            {
                options.ConnectionString = connectionStrings.DefaultConnection;
            });

            // register Data Services
            services.RegiseterApplicationDataServices();

            // register infrastructure service
            services.RegiseterInfrastructureServices();

            // register background services
            services.RegisterBackgroundServices();

            // register spothit
            services.RegisterSpotHit(configuration);
        }

        /// <summary>
        /// register spothit
        /// </summary>
        /// <param name="services">the DI Service collection</param>
        /// <param name="configuration">the configuration</param>
        private static void RegisterSpotHit(this IServiceCollection services, IConfiguration configuration)
        {
            var spotHitSecrets = new SpotHitSecrets();
            configuration.Bind("SpotHitSecrets", spotHitSecrets);

            services.AddSpotHit(options =>
            {
                options.APIKey = spotHitSecrets.APIKey;
                options.SendSmsEndpoint = spotHitSecrets.SendSmsEndpoint;
            });
        }

        /// <summary>
        /// we use this method to register all Builders and factories
        /// </summary>
        /// <param name="services">the DI Service collection</param>
        private static void RegiseterApplicationFactoriesAndBuilders(this IServiceCollection services)
        {
            // register DataRequestBuilder
            services.AddSingleton(typeof(IDataRequestBuilder<>), typeof(DataRequestBuilder<>));
        }

        /// <summary>
        /// configue cors
        /// </summary>
        /// <param name="services">the DI service Collection</param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors();
        }

        /// <summary>
        /// configure Swagger for API Documentation
        /// </summary>
        /// <param name="services">the DI service Collection</param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // Configure the XML comments file path for the Swagger JSON and UI.
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile));

                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();

                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "COMPANY Color API",
                    Description = "Web Api COMPANY Color",
                    TermsOfService = "None"
                });

                c.AddSecurityDefinition(
                    "Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Name = "Authorization",
                        Type = "apiKey"
                    }
                );

                c.AddSecurityRequirement(
                    new Dictionary<string, IEnumerable<string>> {
                    { "Bearer", Enumerable.Empty<string>() },
                    }
                );
            });
        }

        /// <summary>
        /// this method is used to automatically create the database by implementing the panding migrations
        /// </summary>
        /// <param name="webHost"></param>
        internal static IWebHost SetUpAsync(this IWebHost webHost)
        {
            using (var serviceScope = webHost.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CompanyDbContext>();
                context.Database.Migrate();

                var appSettingOptions = serviceScope.ServiceProvider.GetService<IOptions<AppSettings>>();

                if (appSettingOptions.Value.BackgroundService.Launch)
                    webHost.SetUpBackgroundServices();

            }
            return webHost;
        }

        /// <summary>
        /// set up the background services
        /// </summary>
        /// <param name="webHost">the web host instant</param>
        internal static void SetUpBackgroundServices(this IWebHost webHost)
        {
            webHost.Services.UseScheduler(scheduler =>
            {
                scheduler.Schedule<SynchronizeDossiersWithAnsroute>().DailyAt(00, 30);
                scheduler.Schedule<DossierEnRetardService>().DailyAt(01, 00);
                scheduler.Schedule<DevisEnRetardService>().DailyAt(01, 30);
                scheduler.Schedule<FactureEnRetardService>().DailyAt(02, 00);
                scheduler.Schedule<AvoirEnRetardService>().DailyAt(02, 30);
                scheduler.Schedule<SynchronizeDossiersWithAnsroute>().DailyAt(12, 30);
            });
        }

        /// <summary>
        /// configure background services
        /// </summary>
        /// <param name="services">the services collections</param>
        internal static void RegisterBackgroundServices(this IServiceCollection services)
        {
            // first register the background services
            services.AddTransient<DossierEnRetardService>();
            services.AddTransient<DevisEnRetardService>();
            services.AddTransient<FactureEnRetardService>();
            services.AddTransient<AvoirEnRetardService>();
            services.AddTransient<SynchronizeDossiersWithAnsroute>();

            // register the background services with Coravel Manager
            services.AddScheduler();
        }

        /// <summary>
        /// get the service from the given service scope
        /// </summary>
        /// <typeparam name="TService">the type of the service to retrieve</typeparam>
        /// <param name="scope">the scope service instant</param>
        /// <returns>the service instant</returns>
        internal static TService GetService<TService>(this IServiceScope scope)
            => scope.ServiceProvider.GetRequiredService<TService>();

        /// <summary>
        /// this method is user to configure the logger
        /// </summary>
        internal static void ConfigureLogger(string connectionString)
        {
            // Configure SERILOG
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console()
                        .WriteTo.MySQL(
                            connectionString: connectionString,
                            restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning
                        ).CreateLogger();
        }
    }
}
