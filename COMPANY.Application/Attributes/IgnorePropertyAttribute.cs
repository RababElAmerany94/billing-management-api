namespace COMPANY.Application
{
    using System;

    /// <summary>
    /// this attribute mark a property as a Ignored
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class IgnorePropertyAttribute : Attribute
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public IgnorePropertyAttribute()
        {
        }
    }
}
