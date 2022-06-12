namespace COMPANY.Presistence
{
    using COMPANY.Domain.Entities;
    using COMPANY.Presistence.DataContext.EntitiesConfigurations;
    using COMPANY.Presistence.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Microsoft.Extensions.DependencyInjection;
    using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
    using Presistence.DataContext;
    using System;
    using System.Linq;
    using System.Reflection;

    public static class Extentions
    {
        /// <summary>
        /// this method is used to register all application dataAccess services
        /// </summary>
        /// <param name="services">the DI Service collection</param>
        public static void AddPresistenceLayer(this IServiceCollection services, Action<PresistenceOptions> options)
        {
            var settings = new PresistenceOptions();
            options(settings);

            services.AddDbContext<CompanyDbContext>(optionsAction =>
            {
                optionsAction.EnableSensitiveDataLogging();
                optionsAction.UseMySql(
                    settings.ConnectionString,
                    mySqlOptions => mySqlOptions.ServerVersion(new Version(10, 3), ServerType.MariaDb));
            });

            // register DataSource
            services.AddScoped<IDataSource>(o => o.GetService<CompanyDbContext>());
        }

        /// <summary>
        /// this method is used to configure the database
        /// </summary>
        /// <param name="services">the DI service collection</param>
        /// <param name="connectionString">the connection string for the database</param>
        public static void ConfigureDb(this IServiceCollection services, string connectionString)
        {
          
        }

        #region internal methods

        /// <summary>
        /// Apply the configuration from the current assembly
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        internal static ModelBuilder ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            var typesToRegister = AgenceEntityConfiguration
                .GetAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            return modelBuilder;
        }

        /// <summary>
        /// apply a default size to all properties of type string
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        internal static ModelBuilder ApplyStringDefaultSize(this ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                        .SelectMany(t => t.GetProperties())
                        .Where(p => p.ClrType == typeof(string)))
            {
                property.AsProperty().Builder
                    .HasMaxLength(256, ConfigurationSource.Convention);
            }

            return modelBuilder;
        }

        /// <summary>
        /// Apply the Commune Configuration to all entities that derives from <see cref="Entity{Tkey}"/>
        /// </summary>
        /// <param name="modelBuilder">the module builder instant</param>
        /// <returns>the module builder instant</returns>
        internal static ModelBuilder ApplyBaseEntityConfiguration(this ModelBuilder modelBuilder)
        {
            var method = typeof(Extentions).GetTypeInfo().DeclaredMethods
                .Single(m => m.Name == nameof(Configure)); // use the Configure to configure commune configurations

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.IsBaseEntity(out var T))
                    method.MakeGenericMethod(entityType.ClrType, T)
                        .Invoke(null, new[] { modelBuilder });
            }

            return modelBuilder;
        }

        #endregion

        #region private methods

        /// <summary>
        /// here apply all commune configuration to all entities that derives from <see cref="Entity{Tkey}"/>
        /// </summary>
        /// <typeparam name="TEntity">the type of the entity to be configured</typeparam>
        /// <typeparam name="T">the type of the key</typeparam>
        /// <param name="modelBuilder">the module builder instant</param>
        private static void Configure<TEntity, T>(ModelBuilder modelBuilder)
            where TEntity : Entity<T>
        {
            modelBuilder.Entity<TEntity>(builder =>
            {
                //key
                builder.HasKey(e => e.Id);

                //properties configurations
                builder.Property(e => e.CreatedOn);

                builder.Property(e => e.LastModifiedOn)
                    .IsRequired(false);

                builder.Property(e => e.SearchTerms)
                    .HasMaxLength(750);

                // index
                builder.HasIndex(e => e.SearchTerms);
            });
        }

        /// <summary>
        /// check if the given type is the base type
        /// </summary>
        /// <param name="type">the type to be checked</param>
        /// <param name="T">the output key type</param>
        /// <returns>true if it the base type, false if not</returns>
        private static bool IsBaseEntity(this Type type, out Type T)
        {
            for (var baseType = type.BaseType; baseType != null; baseType = baseType.BaseType)
            {
                if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(Entity<>))
                {
                    T = baseType.GetGenericArguments()[0];
                    return true;
                }
            }

            T = null;
            return false;
        }

        #endregion
    }
}
