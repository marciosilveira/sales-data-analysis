using Microsoft.Extensions.DependencyInjection;

namespace Sales.Data.Analysis.IoC
{
    public static class Startup
    {
        public static ServiceProvider ConfigureServices(IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddLoggerDependency()
                .AddDomainDependency()
                .AddFileDependency()
                .BuildServiceProvider();
        }
    }
}
