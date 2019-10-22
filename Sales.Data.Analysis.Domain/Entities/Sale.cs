using Sales.Data.Analysis.Domain.Builder;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Data.Analysis.Domain.Entities
{
    public class Sale
    {
        public const string DataType = "003";
        public const char Separator = 'ç';
        public const char SeparatorItem = ',';

        public int Id { get; private set; }
        public List<SaleItem> Items { get; private set; }
        public double Total { get { return Items?.Sum(o => o.Total) ?? 0; } }
        public string SalesmanName { get; private set; }
        public static SaleBuilder New(string line) => new SaleBuilder(line);

        /// <summary>
        /// Dados de venda
        /// Os dados de venda possuem o identificador 003 e seguem o seguinte formato:
        /// 003çSale IDç[Item ID - Item Quantity - Item Price]çSalesman name
        /// </summary>
        public class SaleBuilder : Builder<Sale>
        {
            public SaleBuilder(string line)
            {
                var splitLine = line.Split(Separator);
                if (splitLine.Length > 0)
                {
                    Instance.Id = int.Parse(splitLine[1]);
                    Instance.SalesmanName = splitLine[3];
                    Instance.Items = splitLine[2]
                        .Split(SeparatorItem)
                        ?.Select(s => SaleItem.New(s).Build())
                        .ToList();
                }
            }
        }
    }
}
