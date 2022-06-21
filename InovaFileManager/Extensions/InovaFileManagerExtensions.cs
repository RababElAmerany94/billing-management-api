namespace InovaFileManager.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// a class defines extensions methods of Inova File Manager
    /// </summary>
    public static class InovaFileManagerExtensions
    {
        public static void AddInovaFileManager(this IServiceCollection services, string path)
        {
            services.AddSingleton<IFileManager>(provider => new FileManager(path));
        }
    }
}
