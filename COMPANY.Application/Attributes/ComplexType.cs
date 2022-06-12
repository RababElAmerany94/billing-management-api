namespace COMPANY.Application
{
    using System;

    /// <summary>
    /// this attribute mark a property as a complex type
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class ComplexTypeAttribute : Attribute
    {
        /// <summary>
        /// default constructor 
        /// </summary>
        public ComplexTypeAttribute()
        {
        }
    }
}
