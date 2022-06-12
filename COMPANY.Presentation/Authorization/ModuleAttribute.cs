namespace COMPANY.Presentation.Authorization
{
    using COMPANY.Application.Enums;
    using System;

    /// <summary>
    /// a class define permission attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ModuleAttribute : Attribute
    {
        public ModuleAttribute(Modules module)
           => Module = module.ToString();

        public string Module { get; set; }

    }
}
