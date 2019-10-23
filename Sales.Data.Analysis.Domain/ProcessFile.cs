using Microsoft.Extensions.Logging;
using Sales.Data.Analysis.Domain.Entities;
using Sales.Data.Analysis.IO;
using System;
using System.IO;
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

        public async Task Run()
        {
            await Task.Factory.StartNew(() =>
            {
                string[] fileNames = _readFromFile.GetFiles(FileIn.FolderIn);
                if (fileNames != null)
                {
                    foreach (var name in fileNames)
                    {
                        Process(name);
                    }
                }

                _logger.LogWarning("Finalizado processamento do arquivo de entrada.");
            });
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
