using Microsoft.AspNetCore.Mvc;
using Store.Manager.Sell.Interfaces.Services;
using Store.Manager.Sell.Models;
using Store.Manager.Sell.Report;
using Store.Manager.Sell.Services;

namespace Store.Manager.Sell.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;
        private readonly IProductService _productService;

        public SalesController(ISalesService salesService, IProductService productService)
        {
            _salesService = salesService;
            _productService = productService;
        }

        [HttpPost]
        public IActionResult CreateSale(Sale request)
        {
            List<int> productIds= new List<int>();

            // Verificar se o modelo é válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Mapear o modelo de requisição para a entidade Sale
            var sale = new Sale
            {
                CustomerId = request.CustomerId,
                Products = new List<Product>()
            };

            // Obter os produtos pelo ID a partir do serviço de produtos
            foreach (var productId in request.Products)
            {
                var product = _productService.GetProductById(productId.Id);
                if (product != null)
                {
                    sale.Products.Add(product);
                    productIds.Add(product.Id);
                }
            }

            // Chamar o método correspondente na service de vendas para criar a venda
            var createdSale = _salesService.CreateSale(sale.CustomerId, productIds);

            if (createdSale != null)
            {
                // Venda criada com sucesso, retornar a resposta 201 Created com os detalhes da venda
                var responseModel = new Sale
                {
                    Id = createdSale.Id,
                    CustomerId = createdSale.CustomerId,
                    Products = createdSale.Products.Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price
                    }).ToList()
                };

                return CreatedAtAction(nameof(GetSale), new { id = createdSale.Id }, responseModel);
            }
            else
            {
                // Ocorreu algum erro ao criar a venda
                return StatusCode(500, "Erro ao criar a venda.");
            }
        }


        [HttpGet]
        public ActionResult<List<Sale>> GetSales()
        {
            var sales = _salesService.GetSales();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public ActionResult<Sale> GetSale(int id)
        {
            var sale = _salesService.GetSaleById(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        [HttpGet("report")]
        public ActionResult<List<SaleReportItem>> GetSalesReport()
        {
            var report = _salesService.GetSalesReport();
            return Ok(report);
        }
    }
}
