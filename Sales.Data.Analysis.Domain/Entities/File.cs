using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales.Data.Analysis.Domain.Entities
{
    public class File
    {
        public List<Salesman> Sellers { get; }
        public List<Client> Clients { get; }
        public List<Sale> Sales { get; }

        public File(List<Salesman> sellers, List<Client> clients, List<Sale> sales)
        {
            Sellers = sellers;
            Clients = clients;
            Sales = sales;
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
            stringBuilder.AppendLine($"ID da venda mais cara: {GetBiggestSale()}");
            stringBuilder.AppendLine($"O pior vendedor: {GetWorstSeller()}");

            return stringBuilder.ToString();
        }

        private int? GetBiggestSale()
        {
            return Sales.OrderByDescending(o => o.Total).FirstOrDefault()?.Id;
        }

        private string GetWorstSeller()
        {
            return Sales.OrderBy(o => o.Total).FirstOrDefault()?.SalesmanName;
        }

    }
}
