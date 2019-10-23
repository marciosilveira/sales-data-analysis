using Microsoft.Extensions.DependencyInjection;
using Sales.Data.Analysis.IO;

namespace Sales.Data.Analysis.IoC
{
    public static class FileExtension
    {
        public static IServiceCollection AddFileDependency(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<ReadFromFile>()
                .AddSingleton<WriteTextFile>()
                .AddSingleton<MoveFile>();
        }
    }
}
