using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStoreMVC.Data;
using System.Threading.Tasks;

namespace TechStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context) => _context = context;
       

        public async Task<IActionResult> Index()
        {
            // Зарежда всички продукти от базата, включително категорията им
            var products = await _context.Products
                                       .Include(p => p.Category)
                                       .ToListAsync();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(); // Грешките ще се хващат тук
        }
    }
}
