using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CoreFuels.ModelsEF;

namespace CoreFuels.Controllers
{
    public class EatController : Controller
    {
        private readonly AppDbContext _context;

        public EatController(AppDbContext context)
        {
            _context = context;
        }

        // Загружаем список продуктов и передаём их в представление
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Select(p => new ProductViewModel { ProductId = p.ProductId, Name = p.Name })
                .ToListAsync();
            return View(products);
        }

        // Если нужен POST-запрос на сервер при выборе продукта
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null)
            {
                return NotFound(new { success = false, message = "Продукт не найден" });
            }

            // Допустим, здесь можно выполнить дополнительную логику (например, сохранить выбор)
            return Json(new { success = true, message = "Продукт добавлен!" });
        }
    }

    public class AddProductRequest
    {
        public int ProductId { get; set; }
    }

    // ViewModel для передачи продуктов в представление
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
