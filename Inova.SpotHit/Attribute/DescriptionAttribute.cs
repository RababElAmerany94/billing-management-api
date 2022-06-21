namespace Inova.SpotHit.Attribute
{
    using System;

    [AttributeUsage(AttributeTargets.Field)]
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string message)
           => Message = message;

        public string Message { get; set; }
    }
}
