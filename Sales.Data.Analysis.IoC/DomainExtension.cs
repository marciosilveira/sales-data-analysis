using Microsoft.Extensions.DependencyInjection;
using Sales.Data.Analysis.Domain;

namespace Sales.Data.Analysis.IoC
{
    public static class DomainExtension
    {
        public static IServiceCollection AddDomainDependency(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ProcessReceivedFile>();

            return serviceCollection;
        }
    }
}
