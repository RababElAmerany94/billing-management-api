namespace Company.AutoMapperRegister
{
    using AutoMapper;
    using Company.AutoMapperRegister.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Reflection;

    public static class Extentions
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            var assemblies = Assembly
                .GetCallingAssembly()
                .GetReferencedAssemblies()
                .Select((item) => Assembly.Load(item))
                .ToList();
            assemblies.Add(Assembly.GetCallingAssembly());

            var types = assemblies
                .SelectMany((item) => item.GetTypes())
                .Where(type => Attribute.IsDefined(type, typeof(ModelFor)))
                .Select(type => new
                {
                    Model = type,
                    Entity = type.GetCustomAttribute<ModelFor>().Type
                });

            services.AddAutoMapper(options =>
            {
                foreach (var item in types)
                    options.CreateMap(item.Entity, item.Model).ReverseMap();

            }, assemblies);
        }

    }
}
