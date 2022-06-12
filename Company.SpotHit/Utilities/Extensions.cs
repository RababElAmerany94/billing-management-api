namespace Company.SpotHit.Utilities
{
    using Company.SpotHit.Attribute;
    using Company.SpotHit.Interface;
    using Company.SpotHit.Models;
    using Company.SpotHit.Services;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;

    public static class Extensions
    {
        public static void AddSpotHit(this IServiceCollection services, Action<SpotHitSecrets> options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            // set options
            var option = new SpotHitSecrets();
            options(option);

            // options
            services.AddSingleton<SpotHitSecrets>(option);

            // services
            services.AddTransient<ISpotHitService, SpotHitService>();
        }

        /// <summary>
        /// convert string to enum
        /// </summary>
        /// <typeparam name="T">the type</typeparam>
        /// <param name="value">the value to parse</param>
        /// <returns>an enum</returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// retrieve description of property
        /// </summary>
        /// <param name="property">the property to be checked</param>
        /// <returns>true or false</returns>
        public static string DescriptionAttribute(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<DescriptionAttribute>()
                .SingleOrDefault()?.Message ?? "";
        }


        public static string FormatPhoneNumberForFrance(this string phoneNumber)
        {
            if (phoneNumber.StartsWith("0"))
                phoneNumber = phoneNumber.Remove(0, 1);

            return $"+33{phoneNumber}";
        }

    }
}
