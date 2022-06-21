namespace Inova.AutoInjection
{
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using System;
    using System.Linq;
    using System.Reflection;

    public static class Extentions
    {
        public static void Inject(this IServiceCollection services)
        {
            var items = Assembly
                 .GetCallingAssembly()
                 .GetReferencedAssemblies()
                 .SelectMany((item) => Assembly.Load(item).GetTypes())
                 .Concat(Assembly.GetCallingAssembly().GetTypes())
                 .Where(type => Attribute.IsDefined(type, typeof(InjectAttribute)))
                 .Select(type => new
                 {
                     ImplementationType = type,
                     ServiceType = type.GetCustomAttribute<InjectAttribute>().Type,
                     Lifetime = type.GetCustomAttribute<InjectAttribute>().ServiceLifetime
                 })
                 .ToList();

            foreach (var item in items)
            {
                if (item.ServiceType is null)
                    services.TryAdd(new ServiceDescriptor(item.ImplementationType, item.Lifetime));
                else
                    services.TryAdd(new ServiceDescriptor(item.ServiceType, item.ImplementationType, item.Lifetime));
            }
        }

    }
}
