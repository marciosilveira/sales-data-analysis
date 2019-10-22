using Microsoft.Extensions.Logging;
using Sales.Data.Analysis.Domain.Entities;
using Sales.Data.Analysis.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Data.Analysis.Domain
{
    public class ProcessReceivedFile
    {
        public const string FolderIn = @"data\in";
        private readonly ILogger<ProcessReceivedFile> _logger;

        public ProcessReceivedFile(ILogger<ProcessReceivedFile> logger)
        {
            _logger = logger;
            _logger.LogWarning("Iniciado processamento do arquivo de entrada.");
        }

        public async Task Run()
        {
            await Task.Factory.StartNew(() =>
            {
                string[] fileNames = FileHelper.GetFiles(FolderIn);
                if (fileNames != null)
                {
                    foreach (var name in fileNames)
                    {
                        var fileData = FileHelper.ReadFile(name);
                        var file = Process(fileData);
                        _logger.LogInformation(file.ToString());
                    }
                }

                _logger.LogWarning("Finalizado processamento do arquivo de entrada.");
            });
        }

        private File Process(List<string> fileLines)
        {
            var file = new File(
                ProcessSalesman(fileLines),
                ProcessClient(fileLines),
                ProcessSale(fileLines));

            return file;
        }

        private List<Salesman> ProcessSalesman(List<string> fileLines)
        {
            return fileLines
                .Where(o => o.StartsWith(Salesman.DataType))
                .Select(s => Salesman.New(s).Build())
                .ToList();
        }

        private List<Client> ProcessClient(List<string> fileLines)
        {
            return fileLines
                .Where(w => w.StartsWith(Client.DataType))
                .Select(s => Client.New(s).Build())
                .ToList();
        }

        private List<Entities.Sale> ProcessSale(List<string> fileLines)
        {
            return fileLines
                .Where(w => w.StartsWith(Entities.Sale.DataType))
                .Select(s => Entities.Sale.New(s).Build())
                .ToList();
        }
    }
}
