using Microsoft.Extensions.DependencyInjection;
using Sales.Data.Analysis.Domain;

namespace Sales.Data.Analysis.IoC
{
    public static class DomainExtension
    {
        public static IServiceCollection AddDomainDependency(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<ProcessFile>();
        }
    }
}
