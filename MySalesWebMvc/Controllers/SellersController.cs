using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySalesWebMvc.Models;
using MySalesWebMvc.Services;

namespace MySalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (ModelState.IsValid)
            {
                // Define BirthDate como UTC
                seller.BirthDate = DateTime.SpecifyKind(seller.BirthDate, DateTimeKind.Utc);

                // Adicione a lógica para salvar o objeto Seller no banco de dados aqui
                _sellerService.Insert(seller);
                return RedirectToAction(nameof(Index));
            }
            return View(seller);
        }
      
    }
}
