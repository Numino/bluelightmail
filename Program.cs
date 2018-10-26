using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;

namespace BlueLight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args.Where(arg => arg != "--service").ToArray());

            if (IsService(args))
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                var pathToContentRoot = Path.GetDirectoryName(pathToExe);
                builder.UseContentRoot(pathToContentRoot);
            }

            var configuration = builder.Build();

            if (IsService(args))
                configuration.RunAsService();
            else
                configuration.Run();
        }

        private static bool IsService(IEnumerable<string> args) => args.Contains("--service");

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel();
    }
}