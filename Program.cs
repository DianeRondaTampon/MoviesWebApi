
// Program.cs
using log4net;
using log4net.Config;

namespace MoviesWebApi


{
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            // Configure log4net using the configuration file
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

            // Use the logger
            log.Info("Logging from program.");


            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

