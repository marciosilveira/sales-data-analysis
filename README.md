# Conceito

Sistema de análise de dados de venda que irá importar lotes de arquivos e produzir
um relatório baseado em informações presentes no mesmo.
Existem 3 tipos de dados dentro dos arquivos e eles podem ser distinguidos pelo seu
identificador que estará presente na primeira coluna de cada linha, onde o separador de
colunas é o caractere “ç”.

### Dados do vendedor
Os dados do vendedor possuem o identificador 001 e seguem o seguinte formato:
<table>
  <tbody>
    <tr>
      <td>
        <b>001çCPFçNameçSalary</b>
      </td>
    </tr>
  </tbody>
</table>

###  Dados do cliente
Os dados do cliente possuem o identificador 002 e seguem o seguinte formato:
<table>
  <tbody>
    <tr>
      <td>
        <b>002çCNPJçNameçBusiness Area</b>
      </td>
    </tr>
  </tbody>
</table>

###  Dados de venda
Os dados de venda possuem o identificador 003 e seguem o seguinte formato:
<table>
  <tbody>
    <tr>
      <td>
        <b>003çSale IDç[Item ID-Item Quantity-Item Price]çSalesman name</b>
      </td>
    </tr>
  </tbody>
</table>

<table>
  <thead>
    <th>
      <b>Exemplo de conteúdo total do arquivo</b>
    </th>
  </thead>
  <tbody>
    <tr>
      <td>001ç1234567891234çPedroç50000</td>
    </tr>
    <tr>
      <td>001ç3245678865434çPauloç40000.99</td>
    </tr>
    <tr>
      <td>002ç2345675434544345çJose da SilvaçRural</td>
    </tr>
    <tr>
      <td>002ç2345675433444345çEduardo PereiraçRural</td>
    </tr>
    <tr>
      <td>003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro</td>
    </tr>
    <tr>
      <td>003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çPaulo</td>
    </tr>
  </tbody>
</table>

# Critérios de Aceite

O sistema deverá ler continuamente todos os arquivos dentro do diretório padrão
HOMEPATH/data/in e colocar o arquivo de saída em HOMEPATH/data/out.
No arquivo de saída o sistema deverá possuir os seguintes dados:
* Quantidade de clientes no arquivo de entrada
* Quantidade de vendedores no arquivo de entrada
* ID da venda mais cara
* O pior vendedor

### Requisitos técnicos
* O sistema deve rodar continuamente e capturar novos arquivos assim que eles sejam
inseridos no diretório padrão.
