using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sales.Data.Analysis.Domain;
using Sales.Data.Analysis.IoC;
using System;
using System.Threading.Tasks;

namespace Sales.Data.Analysis
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = Startup.ConfigureServices(new ServiceCollection());
            var logger = serviceProvider.GetService<ILogger<Program>>();

            try
            {
                var processReceivedFile = serviceProvider.GetService<ProcessReceivedFile>();
                await processReceivedFile.Run();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
            finally
            {
                Task.Delay(200).Wait();
            }
        }
    }
}
