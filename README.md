API C# - ASP.NET Core + swagger
-------------------------------

API REST desenvolvida em C# com ASP.NET Core, utilizando boas práticas de arquitetura e extensível para integrações com bancos de dados e serviços externos.

🚀 Tecnologias utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/download)
- ASP.NET Core Web API
- Swagger (Swashbuckle)
- Visual Studio Code

📁 Estrutura do Projeto

MinhaApi/
├── Controllers/ # Controllers da aplicação
├── Models/ # Modelos de dados (caso adicionados)
├── Program.cs # Ponto de entrada da aplicação
├── appsettings.json # Configurações do projeto
├── MinhaApi.csproj # Arquivo de configuração do projeto .NET

🔧 Como rodar o projeto

1. **Clonar o repositório**

git clone https://github.com/walacepessoa/api_csharp.git
cd api_csharp

Restaurar os pacotes
dotnet restore

Rodar o projeto
dotnet run

Acessar no navegador
API: http://localhost:5000

Swagger: https://localhost:5001/swagger

Obs.: Se necessário, edite Program.cs para rodar apenas em HTTP:

builder.WebHost.UseUrls("http://localhost:5000");
✅ Endpoints disponíveis
GET /api/produto → Lista produtos

(Adicione novos conforme criar)

Criado por:
-----------
Walace Pessôa Rio de Janeiro, Brasil V01.01.00
