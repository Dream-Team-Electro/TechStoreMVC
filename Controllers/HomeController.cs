using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechStoreMVC.Views.Data.Models;
using System.Linq;
using System.Collections.Generic;

namespace TechStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? categoryId)  // Единствената версия на Index, която приема категория.
        {
            var demoProducts = new List<Product>
            {
                new Product { ProductId = 1, Name = "Геймърска мишка", Price = 59.99m, Description = "Ergonomic RGB мишка", ImagePath = "/images/Gaming-mouse.jpg", Category = new Category { CategoryId = 1, Name = "Периферия" } },
                new Product { ProductId = 2, Name = "Механична клавиатура", Price = 120.00m, Description = "Клавиатура с Cherry MX Blue", ImagePath = "/images/Keyboard-MX-blue.jpg", Category = new Category { CategoryId = 1, Name = "Периферия" } },
                new Product { ProductId = 3, Name = "Монитор 27''", Price = 369.99m, Description = "144Hz IPS монитор", ImagePath = "/images/Gaming-Monitor-144hz.jpg", Category = new Category { CategoryId = 2, Name = "Дисплеи" } },
                new Product { ProductId = 4, Name = "Уеб камера Full HD", Price = 89.99m, Description = "1080p уеб камера", ImagePath = "/images/camera-web-1080p.jpg", Category = new Category { CategoryId = 3, Name = "Аксесоари" } },
            };

            if (categoryId.HasValue)
            {
                demoProducts = demoProducts.Where(p => p.Category.CategoryId == categoryId.Value).ToList();
            }

            return View(demoProducts);
        }

        public IActionResult Details(int id)
        {
            var demoProducts = new List<Product>
            {
                new Product { ProductId = 1, Name = "Геймърска мишка", Price = 59.99m, Description = "Ergonomic RGB мишка", ImagePath = "/images/Gaming-mouse.jpg", Category = new Category { CategoryId = 1, Name = "Периферия" } },
                new Product { ProductId = 2, Name = "Механична клавиатура", Price = 120.00m, Description = "Клавиатура с Cherry MX Blue", ImagePath = "/images/Keyboard-MX-blue.jpg", Category = new Category { CategoryId = 1, Name = "Периферия" } },
                new Product { ProductId = 3, Name = "Монитор 27''", Price = 369.99m, Description = "144Hz IPS монитор", ImagePath = "/images/Gaming-Monitor-144hz.jpg", Category = new Category { CategoryId = 2, Name = "Дисплеи" } },
                new Product { ProductId = 4, Name = "Уеб камера Full HD", Price = 89.99m, Description = "1080p уеб камера", ImagePath = "/images/camera-web-1080p.jpg", Category = new Category { CategoryId = 3, Name = "Аксесоари" } },
            };

            var product = demoProducts.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
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
