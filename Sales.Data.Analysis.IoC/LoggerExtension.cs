using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sales.Data.Analysis.IoC
{
    public static class LoggerExtension
    {
        public static IServiceCollection AddLoggerDependency(this IServiceCollection serviceCollection)
        {
            return serviceCollection
              .AddLogging(o => o.AddConsole())
              .Configure<LoggerFilterOptions>(o => o
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("Collect.Sale", LogLevel.Debug));
        }
    }
}
