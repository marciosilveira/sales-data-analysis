using Sales.Data.Analysis.IO;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sales.Data.Analysis.Domain.Entities
{
    public class FileIn
    {
        public const string FolderIn = @"data\in";
        public const string FolderOut = @"data\out";
        public const string FolderProcessed = @"data\processed";

        private readonly WriteTextFile _writeTextFile;
        private readonly MoveFile _moveFile;
        private readonly List<string> _fileLines;
        private readonly string _pathFolderOut;

        public string Name { get; }
        public List<Salesman> Sellers { get; private set; }
        public List<Client> Clients { get; private set; }
        public List<Sale> Sales { get; private set; }

        public FileIn(WriteTextFile writeTextFile, MoveFile moveFile, string fileName,
            List<string> fileLines)
        {
            _writeTextFile = writeTextFile;
            _moveFile = moveFile;
            Name = fileName;
            _fileLines = fileLines;
            _pathFolderOut = $@"{Directory.GetCurrentDirectory()}\{FolderOut}";

            ProcessSalesman();
            ProcessClient();
            ProcessSale();
        }

        private void ProcessSalesman()
        {
            Sellers = _fileLines
                .Where(o => o.StartsWith(Salesman.DataType))
                .Select(s => Salesman.New(s).Build())
                .ToList();
        }

        private void ProcessClient()
        {
            Clients = _fileLines
                .Where(w => w.StartsWith(Client.DataType))
                .Select(s => Client.New(s).Build())
                .ToList();
        }

        private void ProcessSale()
        {
            Sales = _fileLines
                .Where(w => w.StartsWith(Sale.DataType))
                .Select(s => Sale.New(s).Build())
                .ToList();
        }

        /// <summary>
        /// • Quantidade de clientes no arquivo de entrada
        /// • Quantidade de vendedores no arquivo de entrada
        /// • ID da venda mais cara
        /// • O pior vendedor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Quantidade de clientes no arquivo de entrada: {Clients?.Count}");
            stringBuilder.AppendLine($"Quantidade de vendedores no arquivo de entrada: {Sellers?.Count}");
            stringBuilder.AppendLine($"ID da venda mais cara: {GetBiggestSaleId()}");
            stringBuilder.AppendLine($"O pior vendedor: {GetWorstSeller()}");

            return stringBuilder.ToString();
        }

        private int? GetBiggestSaleId() => Sales.OrderByDescending(o => o.Total).FirstOrDefault()?.Id;

        private string GetWorstSeller() => Sales.OrderBy(o => o.Total).FirstOrDefault()?.SalesmanName;

        public void GenerateReport() => _writeTextFile.WriteText(_pathFolderOut, Path.GetFileName(Name), ToString(), true);

        public void SetProcessedFile() => _moveFile.Move(Name, FolderProcessed);
    }
}
