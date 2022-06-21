namespace Inova.AutoMapperRegister.Attributes
{
    using System;

    /// <summary>
    /// this attribute associate model with his class
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class ModelFor : Attribute
    {
        public Type Type { get; set; }

        public ModelFor(Type type)
        {
            Type = type;
        }
    }
}
