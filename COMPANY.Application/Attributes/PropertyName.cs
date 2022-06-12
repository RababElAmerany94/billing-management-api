namespace COMPANY.Application
{
    /// <summary>
    /// use this attribute to define the name of the property when creating a history changes
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class PropertyNameAttribute : System.Attribute
    {
        /// <summary>
        /// a constructor with the property name
        /// </summary>
        /// <param name="propretyName">the name of the property to be used</param>
        public PropertyNameAttribute(string propretyName)
        {
            if (string.IsNullOrEmpty(propretyName))
                throw new System.ArgumentException("you must supply a value or remove the attribute", nameof(propretyName));

            PropertyName = propretyName;
        }

        /// <summary>
        /// name of the property
        /// </summary>
        public string PropertyName { get; }
    }
}
