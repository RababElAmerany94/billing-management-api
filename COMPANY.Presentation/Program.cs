namespace COMPANY.Presentation
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Serilog;

    public class Program
    {
        public static void Main(string[] args)
        {
            var webhost = CreateWebHostBuilder(args).Build();
            webhost.SetUpAsync();
            webhost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseStartup<Startup>();
    }
}
