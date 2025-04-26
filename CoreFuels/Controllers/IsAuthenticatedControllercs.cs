using Microsoft.AspNetCore.Mvc;
using CoreFuels.ModelsEF;
using CoreFuels.Model;

namespace CoreFuels.Controllers
{
    public class IsAuthenticatedController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Authorization");
            }
            return View();
        }
    }
}

