
# DivisoresPrimos - Caique Silva Pereira caique.pereiraphp@gmail.com

Este repositório contém uma solução que inclui três projetos principais: um projeto Console, uma API RESTful e um projeto de Testes Unitários. O objetivo principal é calcular divisores e divisores primos de um número, com resiliência implementada na API.

## Estrutura da Solução

A solução está organizada da seguinte maneira:

- **ConsoleApp**: Um projeto de linha de comando simples para interação com o usuário.
- **DivisoresPrimosApi**: Uma API RESTful em ASP.NET Core que expõe uma funcionalidade de cálculo de divisores e divisores primos.
- **DivisoresPrimosApi.Tests**: Um projeto de testes unitários usando xUnit para garantir a qualidade do código e a funcionalidade correta da API.

### Requisitos

Para rodar os projetos, você precisa ter instalado:

- [.NET SDK 6.0](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)

### ConsoleApp

O **ConsoleApp** é um projeto simples que permite ao usuário inserir um número e visualizar seus divisores e divisores primos.

#### Executando o ConsoleApp

1. Navegue até a pasta do ConsoleApp:

   \`\`\`bash
   cd ConsoleApp
   \`\`\`

2. Execute o aplicativo:

   \`\`\`bash
   dotnet run
   \`\`\`

3. Insira um número quando solicitado.

### DivisoresPrimosApi

O projeto **DivisoresPrimosApi** é uma API RESTful desenvolvida com ASP.NET Core. Ele expõe um endpoint que permite o cálculo dos divisores de um número, bem como a listagem dos divisores primos.

#### Executando a API

1. Navegue até a pasta da API:

   \`\`\`bash
   cd src/DivisoresPrimosApi
   \`\`\`

2. Execute a API:

   \`\`\`bash
   dotnet run
   \`\`\`

3. A API estará disponível em \`https://localhost:5001\` ou \`http://localhost:5000\`.

#### Endpoints

- **GET /api/divisores/{numero}**: Calcula os divisores e divisores primos do número informado.

##### Exemplo de Requisição:

\`\`\`bash
GET https://localhost:5001/api/divisores/45
\`\`\`

##### Exemplo de Resposta:

\`\`\`json
{
    "numeroEntrada": 45,
    "divisores": [1, 3, 5, 9, 15, 45],
    "divisoresPrimos": [1, 3, 5]
}
\`\`\`

### DivisoresPrimosApi.Tests

O projeto **DivisoresPrimosApi.Tests** contém testes unitários para garantir a qualidade e a corretude da API e dos métodos de cálculo de divisores. Utilizamos **xUnit** para testes e **Moq** para criar mocks de dependências.

#### Executando os Testes

1. Navegue até a pasta de testes:

   \`\`\`bash
   cd tests/DivisoresPrimosApi.Tests
   \`\`\`

2. Execute os testes:

   \`\`\`bash
   dotnet test
   \`\`\`

Os testes cobrem cenários de cálculo de divisores, verificação de números primos, além da resiliência do método \`CalcularDivisoresComResiliencia\`, que tenta novamente em caso de falhas.

### Funcionalidades

#### ConsoleApp
- Recebe um número do usuário.
- Calcula e exibe os divisores e divisores primos.

#### API RESTful
- Exposição de um serviço que calcula divisores e divisores primos.
- Resiliência implementada com retries em caso de falhas temporárias.

#### Testes
- Testes unitários e de integração para garantir a estabilidade e resiliência do sistema.
- Testes cobrem o cálculo de divisores, verificação de números primos e comportamento em caso de falha.

### Como Clonar e Executar

1. Clone este repositório:

   \`\`\`bash
   git clone https://github.com/caigol/DivisoresPrimos.git
   cd MinhaSolution
   \`\`\`

2. Para rodar o ConsoleApp:

   \`\`\`bash
   cd ConsoleApp
   dotnet run
   \`\`\`

3. Para rodar a API:

   \`\`\`bash
   cd src/DivisoresPrimosApi
   dotnet run
   \`\`\`

4. Para rodar os testes:

   \`\`\`bash
   cd tests/DivisoresPrimosApi.Tests
   dotnet test
   \`\`\`

