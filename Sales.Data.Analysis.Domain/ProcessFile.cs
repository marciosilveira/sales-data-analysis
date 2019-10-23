using Microsoft.Extensions.Logging;
using Sales.Data.Analysis.Domain.Entities;
using Sales.Data.Analysis.IO;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Data.Analysis.Domain
{
    public class ProcessFile
    {
        private readonly ILogger<ProcessFile> _logger;
        private readonly ReadFromFile _readFromFile;
        private readonly WriteTextFile _writeTextFile;
        private readonly MoveFile _moveFile;

        public ProcessFile(ILogger<ProcessFile> logger, ReadFromFile readFromFile,
            WriteTextFile writeTextFile, MoveFile moveFile)
        {
            _logger = logger;
            _readFromFile = readFromFile;
            _writeTextFile = writeTextFile;
            _moveFile = moveFile;
            _logger.LogWarning("Iniciado processamento do arquivo de entrada.");
        }

        public async Task Run(CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    string[] fileNames = _readFromFile.GetFiles(FileIn.FolderIn);
                    if (fileNames == null || fileNames.Length == 0)
                        Task.Delay(800).Wait();
                    else
                    {
                        foreach (var name in fileNames)
                            Process(name);
                    }
                }

                _logger.LogWarning("Finalizado processamento do arquivo de entrada.");
            }, cancellationToken);
        }

        private void Process(string fileName)
        {
            try
            {
                FileIn file = new FileIn(_writeTextFile, _moveFile, fileName, _readFromFile.ReadAllLines(fileName));
                file.GenerateReport();
                file.SetProcessedFile();
                _logger.LogInformation($"Arquivo processado: {Path.GetFileName(fileName)}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
