// === EatController.cs ===
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CoreFuels.ModelsEF;
using System.Security.Claims;

namespace CoreFuels.Controllers
{
    public class EatController : Controller
    {
        private readonly AppDbContext _context;

        public EatController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Calories = p.Calories,
                    Proteins = p.Proteins,
                    Fats = p.Fats,
                    Carbohydrates = p.Carbohydrates,
                    
                }).ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products
                .Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Calories = p.Calories,
                    Proteins = p.Proteins,
                    Fats = p.Fats,
                    Carbohydrates = p.Carbohydrates,
                   
                }).ToListAsync();

            return Json(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var user = await _context.Authorizations
                .Include(a => a.Products)
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null)
                return NotFound(new { success = false, message = "Пользователь не найден" });

            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null)
                return NotFound(new { success = false, message = "Продукт не найден" });

            if (!user.Products.Any(p => p.ProductId == request.ProductId))
            {
                user.Products.Add(product);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    productId = product.ProductId,
                    name = product.Name,
                    calories = product.Calories,
                    protein = product.Proteins,
                    fat = product.Fats,
                    carbs = product.Carbohydrates,
       
                });
            }

            return Json(new { success = false, message = "Продукт уже добавлен" });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduct([FromBody] RemoveProductRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _context.Authorizations
                .Include(a => a.Products)
                .FirstOrDefaultAsync(a => a.Id == userId);

            var product = user?.Products?.FirstOrDefault(p => p.ProductId == request.ProductId);
            if (product != null)
            {
                user.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Продукт не найден" });
        }

        public class AddProductRequest
        {
            public int ProductId { get; set; }
        }

        public class RemoveProductRequest
        {
            public int ProductId { get; set; }
        }

        public class ProductViewModel
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public string Calories { get; set; }
            public double Proteins { get; set; }
            public double Fats { get; set; }
            public double Carbohydrates { get; set; }
            public string Emoji { get; set; }
        }
    }
} // === END OF EatController.cs ===

