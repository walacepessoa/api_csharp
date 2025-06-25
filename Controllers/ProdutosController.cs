using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        // Modelo simples de produto
        public class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }
        }

        // Lista mockada de produtos
        private static readonly List<Produto> Produtos = new()
        {
            new Produto { Id = 1, Nome = "Notebook", Preco = 3500.00M },
            new Produto { Id = 2, Nome = "Mouse Gamer", Preco = 150.00M },
            new Produto { Id = 3, Nome = "Teclado Mecânico", Preco = 450.00M }
        };

        // GET: api/produto
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return Ok(Produtos);
        }
    }
}