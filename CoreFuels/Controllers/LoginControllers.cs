using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreFuels.ModelsEF;
using CoreFuels.Model;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace CoreFuels.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Login/UserPage
        [HttpGet]
        public IActionResult UserPage()
        {
            return View(new AuthorizationModel());
        }

        // POST: Login/UserPage
        [HttpPost]
        public async Task<IActionResult> UserPage(AuthorizationModel model)
        {
            var user = _context.Authorizations
                .FirstOrDefault(u => u.login == model.login);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Пользователь не найден";
                return View();
            }

            if (user.pass.Trim() != model.pass.Trim())
            {
                TempData["ErrorMessage"] = "Неверный пароль";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.login),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) 

            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );

            HttpContext.Session.SetString("UserLogin", user.login);
            HttpContext.Session.SetString("UserId", user.Id.ToString());

            TempData["SuccessMessage"] = "Вы успешно вошли!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UserProfile()
        {
            var userLogin = HttpContext.Session.GetString("UserLogin");

            if (string.IsNullOrEmpty(userLogin))
                return RedirectToAction("UserPage", "Login");

            var user = _context.Authorizations
                .FirstOrDefault(u => u.login == userLogin);

            if (user == null)
                return RedirectToAction("UserPage", "Login");

            var model = new AuthorizationModel
            {
                login = user.login
            };

            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear(); 
            return RedirectToAction("UserPage", "Login");
        }


    }
}
