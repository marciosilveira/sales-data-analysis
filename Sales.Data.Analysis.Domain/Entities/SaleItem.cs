using Sales.Data.Analysis.Domain.Builder;
using System.Globalization;

namespace Sales.Data.Analysis.Domain.Entities
{
    public class SaleItem
    {
        public const char Separator = '-';

        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }
        public double Total { get { return Price * Quantity; } }
        public static SaleItemBuilder New(string line) => new SaleItemBuilder(line);

        /// <summary>
        /// Dados de venda
        /// Os dados de venda possuem o identificador 003 e seguem o seguinte formato:
        /// 003çSale IDç[Item ID - Item Quantity - Item Price]çSalesman name
        /// </summary>
        public class SaleItemBuilder : Builder<SaleItem>
        {
            public SaleItemBuilder(string line)
            {
                var splitLine = line.Replace("[", "").Replace("]", "").Split(Separator);
                if (splitLine.Length > 0)
                {
                    Instance.Id = int.Parse(splitLine[0]);
                    Instance.Quantity = int.Parse(splitLine[1]);
                    Instance.Price = double.Parse(splitLine[2], NumberFormatInfo.InvariantInfo);
                }
            }
        }

    }
}
