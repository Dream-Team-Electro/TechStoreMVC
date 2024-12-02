using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechStoreMVC.Models;

namespace TechStoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        private static List<Product> products = new List<Product>();
        private static List<Category> categories = new List<Category>();
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;

            var tvCategory = new Category(1, "Телевизори");
            var fridgeCategory = new Category(2, "хладилници");
            var vacuumCategory = new Category(3, "Прахосмукачки");

            products.Add(new Product(1, "Samsung TV",1 ,1500M, "Уникален телевизор с висока резолюция", tvCategory));
            products.Add(new Product(2, "LG Fridge", 2, 800.00M, "Енергоефективен хладилник", fridgeCategory));
            products.Add(new Product(3, "Dyson Vacuum Cleaner", 3, 400.00M, "Мощна прахосмукачка за дома", vacuumCategory));
        }

        public IActionResult Index()
        {
            var viewModel = new ProductCategoryViewModel 
            {
                Products = products,
                Categories = categories
            };
            
            return View(viewModel);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
