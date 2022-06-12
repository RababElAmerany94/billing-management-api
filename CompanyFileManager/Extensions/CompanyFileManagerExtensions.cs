namespace CompanyFileManager.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// a class defines extensions methods of Company File Manager
    /// </summary>
    public static class CompanyFileManagerExtensions
    {
        public static void AddCompanyFileManager(this IServiceCollection services, string path)
        {
            services.AddSingleton<IFileManager>(provider => new FileManager(path));
        }
    }
}
