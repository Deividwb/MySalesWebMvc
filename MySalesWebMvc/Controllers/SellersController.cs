using Microsoft.AspNetCore.Mvc;

namespace MySalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
