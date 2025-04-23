using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechStoreMVC.Views.Data.Models;

namespace TechStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var demoProducts = new List<Product>
            {
                 new Product { ProductId = 1, Name = "��������� �����", Price = 59.99m, Description = "Ergonomic RGB �����", Category = new Category { CategoryId = 1, Name = "���������" } },
                 new Product { ProductId = 2, Name = "��������� ����������", Price = 120.00m, Description = "���������� � Cherry MX Blue", Category = new Category { CategoryId = 1, Name = "���������" } },
                 new Product { ProductId = 3, Name = "������� 27''", Price = 369.99m, Description = "144Hz IPS �������", Category = new Category { CategoryId = 2, Name = "�������" } },
                 new Product { ProductId = 4, Name = "��� ������ Full HD", Price = 89.99m, Description = "1080p ��� ������", Category = new Category { CategoryId = 3, Name = "���������" } },
            };

            return View(demoProducts);
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
