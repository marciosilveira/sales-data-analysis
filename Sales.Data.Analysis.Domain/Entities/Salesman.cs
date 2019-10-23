using Sales.Data.Analysis.Domain.Builder;
using System.Globalization;

namespace Sales.Data.Analysis.Domain.Entities
{
    public class Salesman
    {
        public const string DataType = "001";
        public const char Separator = 'ç';

        public string Cpf { get; private set; }
        public string Name { get; private set; }
        public double Salary { get; private set; }
        public static SalesmanBuilder New(string line) => new SalesmanBuilder(line);

        /// <summary>
        /// Dados do vendedor
        /// Os dados do vendedor possuem o identificador 001 e seguem o seguinte formato:
        /// 001çCPFçNameçSalary
        /// </summary>
        public class SalesmanBuilder : Builder<Salesman>
        {
            public SalesmanBuilder(string line)
            {
                var splitLine = line.Split(Separator);
                if (splitLine.Length == 4)
                {
                    Instance.Cpf = splitLine[1];
                    Instance.Name = splitLine[2];
                    Instance.Salary = double.Parse(splitLine[3], NumberFormatInfo.InvariantInfo);
                }
            }
        }
    }
}
