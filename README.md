API C# - ASP.NET Core + swagger
-------------------------------
📌 Projeto: MinhaApi.sln<br/>
Descrição:<br/>
API REST desenvolvida em C# com ASP.NET Core, utilizando boas práticas de arquitetura e extensível para integrações com bancos de dados e serviços externos.
<p>
🚀 Tecnologias utilizadas<br/>

- [.NET 8](https://dotnet.microsoft.com/en-us/download)<br/>
- ASP.NET Core Web API<br/>
- Swagger (Swashbuckle)<br/>
- Visual Studio Code<br/>
</p>
<p>
✅ PRÉ-REQUISITOS<br/>
Antes de começar, verifique se você tem instalado:<br/>

.NET SDK<br/>
Baixe e instale em: https://dotnet.microsoft.com/en-us/download<br/>
Verifique com:<br/>
dotnet --version<br/>
Visual Studio Code (VS Code)<br/>
Baixe aqui: https://code.visualstudio.com/<br/>

Extensões para VS Code:<br/>

C# Dev Kit (opcional, mas útil)<br/>
</p>
<p>
🚀 CRIANDO O PROJETO<br/>
Abra o terminal (cmd, powershell ou terminal do VS Code)<br/>
Vá até a pasta onde deseja criar o projeto:<br/>
mkdir MinhaApi<br/>
cd MinhaApi<br/>

Crie o projeto Web API:<br/>
dotnet new webapi -n MinhaApi<br/>
cd MinhaApi<br/>
Isso criará uma estrutura com Swagger já habilitado no Program.cs.<br/>

Abra no VS Code:<br/>
code .<br/>
</p>
<p>
🔧 Como rodar o projeto<br/>

1. **Clonar o repositório**<br/>

git clone https://github.com/walacepessoa/api_csharp.git<br/>
cd api_csharp<br/>

Restaurar os pacotes<br/>
dotnet restore<br/>

Rodar o projeto<br/>
dotnet run<br/>

Acessar no navegador<br/>
API: http://localhost:5000<br/>

Swagger: https://localhost:5001/swagger<br/>

Obs.: Se necessário, edite Program.cs para rodar apenas em HTTP:<br/>

builder.WebHost.UseUrls("http://localhost:5000");<br/>
✅ Endpoints disponíveis<br/>
GET /api/produto → Lista produtos<br/>
</p>

### Adicionando o SQLite
<p>
✅ 1. Instale os pacotes necessários<br/>
No terminal, na raiz do projeto:<br/>

bash<br/>
dotnet add package Microsoft.EntityFrameworkCore.Sqlite<br/>
dotnet add package Microsoft.EntityFrameworkCore.Tools<br/>
Se ainda não tem o CLI do EF Core:<br/>

bash<br/>
dotnet tool install --global dotnet-ef<br/>
</p>
<p>
✅ 2. Crie o modelo Produto<br/>
📁 Models/Produto.cs<br/>

namespace MinhaApi.Models<br/>
{<br/>
    public class Produto<br/>
    {<br/>
        public int Id { get; set; }<br/>
        public string Nome { get; set; }<br/>
        public decimal Preco { get; set; }<br/>
        public int Estoque { get; set; }<br/>
    }<br/>
}<br/>
</p>
<p>
✅ 3. Crie o DbContext<br/>
📁 Data/AppDbContext.cs<br/>

using Microsoft.EntityFrameworkCore;<br/>
using MinhaApi.Models;<br/>

namespace MinhaApi.Data<br/>
{<br/>
    public class AppDbContext : DbContext<br/>
    {<br/>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }<br/>
<br/>
        public DbSet<Produto> Produtos { get; set; }<br/>
    }<br/>
}<br/>
</p>
<p>
✅ 4. Configure o Program.cs<br/>
📄 Program.cs<br/>

using Microsoft.EntityFrameworkCore;<br/>
using MinhaApi.Data;<br/>

var builder = WebApplication.CreateBuilder(args);<br/>

builder.Services.AddDbContext<AppDbContext>(options =><br/>
    options.UseSqlite("Data Source=meubanco.db"));<br/>

builder.Services.AddControllers();<br/>
builder.Services.AddEndpointsApiExplorer();<br/>
builder.Services.AddSwaggerGen();<br/>

var app = builder.Build();<br/>

if (app.Environment.IsDevelopment())<br/>
{<br/>
    app.UseSwagger();<br/>
    app.UseSwaggerUI();<br/>
}<br/>

app.UseHttpsRedirection();<br/>
app.UseAuthorization();<br/>
app.MapControllers();<br/>
app.Run();<br/>
</p>
<p>
✅ 5. Crie o ProdutosController<br/>
📁 Controllers/ProdutosController.cs<br/>

using Microsoft.AspNetCore.Mvc;<br/>
using MinhaApi.Data;<br/>
using MinhaApi.Models;<br/>

namespace MinhaApi.Controllers<br/>
{<br/>
    [ApiController]<br/>
    [Route("api/[controller]")]<br/>
    public class ProdutosController : ControllerBase<br/>
    {<br/>
        private readonly AppDbContext _context;<br/>
<br/>
        public ProdutosController(AppDbContext context)<br/>
        {<br/>
            _context = context;<br/>
        }<br/>
<br/>
        [HttpGet]<br/>
        public ActionResult<IEnumerable<Produto>> Get() =><br/>
            _context.Produtos.ToList();<br/>
<br/>
        [HttpPost]<br/>
        public IActionResult Post([FromBody] Produto produto)<br/>
        {<br/>
            _context.Produtos.Add(produto);<br/>
            _context.SaveChanges();<br/>
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);<br/>
        }<br/>
    }<br/>
}<br/>
</p>
<p>
✅ 6. Crie o banco e a tabela com EF Core<br/>
No terminal:<br/>

dotnet ef migrations add CriarTabelaProdutos<br/>
dotnet ef database update<br/>
Isso criará:<br/>

Arquivo meubanco.db<br/>

Tabela Produtos<br/>
</p>
<p>
✅ 7. Execute e teste com o Swagger<br/>

dotnet run<br/>
Acesse: https://localhost:5001/swagger<br/>

Você poderá:<br/>

Fazer GET /api/produtos para listar produtos<br/>

Fazer POST /api/produtos com JSON como:<br/>

{<br/>
  "nome": "Notebook Dell",<br/>
  "preco": 3999.99,<br/>
  "estoque": 10<br/>
}<br/>
</p>
<p>
📁 Estrutura do Projeto<br/>

MinhaApi/<br/>
├── Controllers/<br/>
│   └── ProdutosController.cs<br/>
├── Data/<br/>
│   └── AppDbContext.cs<br/>
├── Models/<br/>
│   └── Produto.cs<br/>
├── Migrations/<br/>
│   └── [Arquivos gerados pelo EF Core]<br/>
├── Properties/<br/>
│   └── launchSettings.json<br/>
├── appsettings.json<br/>
├── Program.cs<br/>
├── MinhaApi.csproj<br/>
└── meubanco.db  ← Criado após `dotnet ef database update`<br/>
</p>

Criado por:<br/>
-----------<br/>
Walace Pessôa<br/>
Rio de Janeiro, Brasil<br/>
V01.01.00
