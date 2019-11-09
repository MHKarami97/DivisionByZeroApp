using Serilog;
using System;
using System.Threading.Tasks;
using ServerConnect.Services;

namespace ServerConnect
{
    class Program
    {
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Verbose()
            .CreateLogger();

            Task.Run(() => AsyncMain()).Wait();
        }

        static async Task AsyncMain()
        {
            var service = new CatsService(new Uri("https://api.thecatapi.com"));
            var results = await service.Search("bengal");

            Log.Debug("{results}", results);

        }
    }
}
