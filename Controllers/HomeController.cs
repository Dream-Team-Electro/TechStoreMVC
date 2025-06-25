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

        public IActionResult Index(int? categoryId)
        {
            var demoProducts = new List<Product>
            {
                  // �����
                  new Product { ProductId = 1, Name = "��������� ����� Logitech G502", Price = 59.99m, Description = "Ergonomic RGB �����", ImagePath = "/images/mouses/gaming-mouse.jpg", Category = new Category { CategoryId = 1, Name = "�����" } },
                  new Product { ProductId = 2, Name = "����� Razer DeathAdder", Price = 49.99m, Description = "������� ����� � 16000 DPI", ImagePath = "/images/mouses/razer-deathadder.jpg", Category = new Category { CategoryId = 1, Name = "�����" } },
                  new Product { ProductId = 3, Name = "����� SteelSeries Rival 3", Price = 39.99m, Description = "FPS ����� � RGB ���������", ImagePath = "/images/mouses/steelseries-rival3.jpg", Category = new Category { CategoryId = 1, Name = "�����" } },
                  new Product { ProductId = 4, Name = "�������� ����� Logitech M185", Price = 24.99m, Description = "��������� �������� �����", ImagePath = "/images/mouses/logitech-m185.jpg", Category = new Category { CategoryId = 1, Name = "�����" } },
                  new Product { ProductId = 5, Name = "��������� ����� Redragon M711", Price = 29.99m, Description = "RGB ����� � ������������� ������", ImagePath = "/images/mouses/redragon-m711.jpg", Category = new Category { CategoryId = 1, Name = "�����" } },

                  // ����������
                  new Product { ProductId = 6, Name = "��������� ���������� Corsair K70", Price = 120.00m, Description = "���������� � Cherry MX Blue", ImagePath = "/images/keyboards/Keyboard-MX-blue.jpg", Category = new Category { CategoryId = 2, Name = "����������" } },
                  new Product { ProductId = 7, Name = "Razer BlackWidow V3", Price = 109.99m, Description = "RGB ��������� ����������", ImagePath = "/images/keyboards/razer-blackwidow.jpg", Category = new Category { CategoryId = 2, Name = "����������" } },
                  new Product { ProductId = 8, Name = "Logitech G213 Prodigy", Price = 69.99m, Description = "��������� ��������� ����������", ImagePath = "/images/keyboards/logitech-g213.jpg", Category = new Category { CategoryId = 2, Name = "����������" } },
                  new Product { ProductId = 9, Name = "SteelSeries Apex 3", Price = 79.99m, Description = "������������� RGB ����������", ImagePath = "/images/keyboards/apex-3.jpg", Category = new Category { CategoryId = 2, Name = "����������" } },
                  new Product { ProductId = 10, Name = "Redragon K552 Kumara", Price = 49.99m, Description = "��������� ���������� � ������� �������", ImagePath = "/images/keyboards/redragon-k552.jpg", Category = new Category { CategoryId = 2, Name = "����������" } },

                  // ��������
                  new Product { ProductId = 11, Name = "��������� �������� Razer Kraken", Price = 99.00m, Description = "�������� � �������� � RGB", ImagePath = "/images/headsets/headset-razer.jpg", Category = new Category { CategoryId = 3, Name = "��������" } },
                  new Product { ProductId = 12, Name = "SteelSeries Arctis 5", Price = 89.99m, Description = "RGB ��������� ��������", ImagePath = "/images/headsets/arctis-5.jpg", Category = new Category { CategoryId = 3, Name = "��������" } },
                  new Product { ProductId = 13, Name = "HyperX Cloud II", Price = 109.99m, Description = "��������� �������� � ��������", ImagePath = "/images/headsets/hyperx-cloud2.jpg", Category = new Category { CategoryId = 3, Name = "��������" } },
                  new Product { ProductId = 14, Name = "Logitech G432", Price = 79.99m, Description = "7.1 ������� ��������", ImagePath = "/images/headsets/logitech-g432.jpg", Category = new Category { CategoryId = 3, Name = "��������" } },
                  new Product { ProductId = 15, Name = "Redragon Ares H120", Price = 39.99m, Description = "�������� ��������� ��������", ImagePath = "/images/headsets/redragon-h120.jpg", Category = new Category { CategoryId = 3, Name = "��������" } },

                  // ��������
                  new Product { ProductId = 16, Name = "������� ASUS 27''", Price = 369.99m, Description = "144Hz IPS �������", ImagePath = "/images/monitors/Gaming-Monitor-144hz.jpg", Category = new Category { CategoryId = 4, Name = "��������" } },
                  new Product { ProductId = 17, Name = "Acer Predator 24''", Price = 299.99m, Description = "Gaming ������� � 165Hz", ImagePath = "/images/monitors/acer-predator.jpg", Category = new Category { CategoryId = 4, Name = "��������" } },
                  new Product { ProductId = 18, Name = "LG Ultragear 32''", Price = 449.99m, Description = "QHD ������� �� ����", ImagePath = "/images/monitors/lg-ultragear.jpg", Category = new Category { CategoryId = 4, Name = "��������" } },
                  new Product { ProductId = 19, Name = "Samsung Odyssey 27''", Price = 399.99m, Description = "����� 240Hz �������", ImagePath = "/images/monitors/samsung-odyssey.jpg", Category = new Category { CategoryId = 4, Name = "��������" } },
                  new Product { ProductId = 20, Name = "Dell S2721HGF", Price = 279.99m, Description = "Curved ������� 144Hz", ImagePath = "/images/monitors/dell-s2721hgf.jpg", Category = new Category { CategoryId = 4, Name = "��������" } },

                  // ���������
                  new Product { ProductId = 21, Name = "��� ������ Logitech C920", Price = 89.99m, Description = "1080p ��� ������", ImagePath = "/images/accessories/camera-web-1080p.jpg", Category = new Category { CategoryId = 5, Name = "���������" } },
                  new Product { ProductId = 22, Name = "�������� �� ����� SteelSeries QcK", Price = 19.99m, Description = "������ �������� �� �����", ImagePath = "/images/accessories/qck-pad.jpg", Category = new Category { CategoryId = 5, Name = "���������" } },
                  new Product { ProductId = 23, Name = "������ �� �������� RGB", Price = 29.99m, Description = "LED �������� �� ��������", ImagePath = "/images/accessories/headset-stand.jpg", Category = new Category { CategoryId = 5, Name = "���������" } },
                  new Product { ProductId = 24, Name = "USB Hub 4-�����", Price = 14.99m, Description = "����������� �� USB", ImagePath = "/images/accessories/usb-hub.jpg", Category = new Category { CategoryId = 5, Name = "���������" } },
                  new Product { ProductId = 25, Name = "������� ���������� ��������", Price = 12.99m, Description = "������������ �� ������", ImagePath = "/images/accessories/cable-management.jpg", Category = new Category { CategoryId = 5, Name = "���������" } }
            };

            if (categoryId.HasValue)
            {
                demoProducts = demoProducts
                    .Where(p => p.Category.CategoryId == categoryId.Value)
                    .ToList();
            }

            var limitedProducts = demoProducts.Take(12).ToList();

            return View(limitedProducts);
        }


        public IActionResult Details(int id)
        {
            var demoProducts = GetDemoProducts(); // ��������� ������� � ������� �����

            var product = demoProducts.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        private List<Product> GetDemoProducts()
        {
            return new List<Product>
    {
        // �����
        new Product { ProductId = 1, Name = "��������� ����� Logitech G502", Price = 59.99m, Description = "Ergonomic RGB �����", ImagePath = "/images/mouses/gaming-mouse.jpg", Category = new Category { CategoryId = 1, Name = "�����" } },
        new Product { ProductId = 2, Name = "����� Razer DeathAdder", Price = 49.99m, Description = "������� ����� � 16000 DPI", ImagePath = "/images/mouses/razer-deathadder.jpg", Category = new Category { CategoryId = 1, Name = "�����" } },
        new Product { ProductId = 3, Name = "����� SteelSeries Rival 3", Price = 39.99m, Description = "FPS ����� � RGB ���������", ImagePath = "/images/mouses/steelseries-rival3.jpg", Category = new Category { CategoryId = 1, Name = "�����" } },
        new Product { ProductId = 4, Name = "�������� ����� Logitech M185", Price = 24.99m, Description = "��������� �������� �����", ImagePath = "/images/mouses/logitech-m185.jpg", Category = new Category { CategoryId = 1, Name = "�����" } },
        new Product { ProductId = 5, Name = "��������� ����� Redragon M711", Price = 29.99m, Description = "RGB ����� � ������������� ������", ImagePath = "/images/mouses/redragon-m711.jpg", Category = new Category { CategoryId = 1, Name = "�����" } },

        // ����������
        new Product { ProductId = 6, Name = "��������� ���������� Corsair K70", Price = 120.00m, Description = "���������� � Cherry MX Blue", ImagePath = "/images/keyboards/Keyboard-MX-blue.jpg", Category = new Category { CategoryId = 2, Name = "����������" } },
        new Product { ProductId = 7, Name = "Razer BlackWidow V3", Price = 109.99m, Description = "RGB ��������� ����������", ImagePath = "/images/keyboards/razer-blackwidow.jpg", Category = new Category { CategoryId = 2, Name = "����������" } },
        new Product { ProductId = 8, Name = "Logitech G213 Prodigy", Price = 69.99m, Description = "��������� ��������� ����������", ImagePath = "/images/keyboards/logitech-g213.jpg", Category = new Category { CategoryId = 2, Name = "����������" } },
        new Product { ProductId = 9, Name = "SteelSeries Apex 3", Price = 79.99m, Description = "������������� RGB ����������", ImagePath = "/images/keyboards/apex-3.jpg", Category = new Category { CategoryId = 2, Name = "����������" } },
        new Product { ProductId = 10, Name = "Redragon K552 Kumara", Price = 49.99m, Description = "��������� ���������� � ������� �������", ImagePath = "/images/keyboards/redragon-k552.jpg", Category = new Category { CategoryId = 2, Name = "����������" } },

        // ��������
        new Product { ProductId = 11, Name = "��������� �������� Razer Kraken", Price = 99.00m, Description = "�������� � �������� � RGB", ImagePath = "/images/headsets/headset-razer.jpg", Category = new Category { CategoryId = 3, Name = "��������" } },
        new Product { ProductId = 12, Name = "SteelSeries Arctis 5", Price = 89.99m, Description = "RGB ��������� ��������", ImagePath = "/images/headsets/arctis-5.jpg", Category = new Category { CategoryId = 3, Name = "��������" } },
        new Product { ProductId = 13, Name = "HyperX Cloud II", Price = 109.99m, Description = "��������� �������� � ��������", ImagePath = "/images/headsets/hyperx-cloud2.jpg", Category = new Category { CategoryId = 3, Name = "��������" } },
        new Product { ProductId = 14, Name = "Logitech G432", Price = 79.99m, Description = "7.1 ������� ��������", ImagePath = "/images/headsets/logitech-g432.jpg", Category = new Category { CategoryId = 3, Name = "��������" } },
        new Product { ProductId = 15, Name = "Redragon Ares H120", Price = 39.99m, Description = "�������� ��������� ��������", ImagePath = "/images/headsets/redragon-h120.jpg", Category = new Category { CategoryId = 3, Name = "��������" } },

        // ��������
        new Product { ProductId = 16, Name = "������� ASUS 27''", Price = 369.99m, Description = "144Hz IPS �������", ImagePath = "/images/monitors/Gaming-Monitor-144hz.jpg", Category = new Category { CategoryId = 4, Name = "��������" } },
        new Product { ProductId = 17, Name = "Acer Predator 24''", Price = 299.99m, Description = "Gaming ������� � 165Hz", ImagePath = "/images/monitors/acer-predator.jpg", Category = new Category { CategoryId = 4, Name = "��������" } },
        new Product { ProductId = 18, Name = "LG Ultragear 32''", Price = 449.99m, Description = "QHD ������� �� ����", ImagePath = "/images/monitors/lg-ultragear.jpg", Category = new Category { CategoryId = 4, Name = "��������" } },
        new Product { ProductId = 19, Name = "Samsung Odyssey 27''", Price = 399.99m, Description = "����� 240Hz �������", ImagePath = "/images/monitors/samsung-odyssey.jpg", Category = new Category { CategoryId = 4, Name = "��������" } },
        new Product { ProductId = 20, Name = "Dell S2721HGF", Price = 279.99m, Description = "Curved ������� 144Hz", ImagePath = "/images/monitors/dell-s2721hgf.jpg", Category = new Category { CategoryId = 4, Name = "��������" } },

        // ���������
        new Product { ProductId = 21, Name = "��� ������ Logitech C920", Price = 89.99m, Description = "1080p ��� ������", ImagePath = "/images/accessories/camera-web-1080p.jpg", Category = new Category { CategoryId = 5, Name = "���������" } },
        new Product { ProductId = 22, Name = "�������� �� ����� SteelSeries QcK", Price = 19.99m, Description = "������ �������� �� �����", ImagePath = "/images/accessories/qck-pad.jpg", Category = new Category { CategoryId = 5, Name = "���������" } },
        new Product { ProductId = 23, Name = "������ �� �������� RGB", Price = 29.99m, Description = "LED �������� �� ��������", ImagePath = "/images/accessories/headset-stand.jpg", Category = new Category { CategoryId = 5, Name = "���������" } },
        new Product { ProductId = 24, Name = "USB Hub 4-�����", Price = 14.99m, Description = "����������� �� USB", ImagePath = "/images/accessories/usb-hub.jpg", Category = new Category { CategoryId = 5, Name = "���������" } },
        new Product { ProductId = 25, Name = "������� ���������� ��������", Price = 12.99m, Description = "������������ �� ������", ImagePath = "/images/accessories/cable-management.jpg", Category = new Category { CategoryId = 5, Name = "���������" } }
    };
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
