using Sales.Data.Analysis.Domain.Builder;

namespace Sales.Data.Analysis.Domain.Entities
{
    public class Client
    {
        public const string DataType = "002";
        public const char Separator = 'ç';

        public string Cnpj { get; private set; }
        public string Name { get; private set; }
        public string BusinessArea { get; private set; }
        public static ClientBuilder New(string line) => new ClientBuilder(line);

        /// <summary>
        /// Dados do cliente
        /// Os dados do cliente possuem o identificador 002 e seguem o seguinte formato:
        /// 002çCNPJçNameçBusiness Area
        /// </summary>
        public class ClientBuilder : Builder<Client>
        {
            public ClientBuilder(string line)
            {
                var splitLine = line.Split(Separator);
                if (splitLine.Length > 0)
                {
                    Instance.Cnpj = splitLine[1];
                    Instance.Name = splitLine[2];
                    Instance.BusinessArea = splitLine[3];
                }
            }
        }
    }
}
