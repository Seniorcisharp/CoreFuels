using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CoreFuels.Model;
using CoreFuels.ModelsEF;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace CoreFuels.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorizationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new AuthorizationModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(AuthorizationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingUser = await _context.Authorizations
                .FirstOrDefaultAsync(a => a.login == model.login);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "Пользователь с таким логином уже существует.");
                return View(model);
            }

            var newUser = new Authorization
            {
                login = model.login,
                pass = model.pass
            };

            try
            {
                _context.Authorizations.Add(newUser);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetString("UserLogin", newUser.login);

                TempData["SuccessMessage"] = "Регистрация прошла успешно!";
                return RedirectToAction("UserPage", "Login"); 

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ошибка сохранения данных: " + ex.Message);
                return View(model);
            }
        }




    }
}
