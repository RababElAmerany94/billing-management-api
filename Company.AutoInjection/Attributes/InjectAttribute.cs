namespace Company.AutoInjection.Attributes
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    /// <summary>
    /// this attribute to inject a classes
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
        public Type Type { get; }
        public ServiceLifetime ServiceLifetime { get; }

        public InjectAttribute(Type type, ServiceLifetime serviceLifetime)
        {
            Type = type;
            ServiceLifetime = serviceLifetime;
        }

        public InjectAttribute(ServiceLifetime serviceLifetime)
        {
            ServiceLifetime = serviceLifetime;
        }
    }
}
