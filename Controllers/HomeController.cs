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
                  // Мишки
                  new Product { ProductId = 1, Name = "Геймърска мишка Logitech G502", Price = 59.99m, Description = "Ergonomic RGB мишка", ImagePath = "/images/mouses/gaming-mouse.jpg", Category = new Category { CategoryId = 1, Name = "Мишки" } },
                  new Product { ProductId = 2, Name = "Мишка Razer DeathAdder", Price = 49.99m, Description = "Оптична мишка с 16000 DPI", ImagePath = "/images/mouses/razer-deathadder.jpg", Category = new Category { CategoryId = 1, Name = "Мишки" } },
                  new Product { ProductId = 3, Name = "Мишка SteelSeries Rival 3", Price = 39.99m, Description = "FPS мишка с RGB подсветка", ImagePath = "/images/mouses/steelseries-rival3.jpg", Category = new Category { CategoryId = 1, Name = "Мишки" } },
                  new Product { ProductId = 4, Name = "Безжична мишка Logitech M185", Price = 24.99m, Description = "Компактна безжична мишка", ImagePath = "/images/mouses/logitech-m185.jpg", Category = new Category { CategoryId = 1, Name = "Мишки" } },
                  new Product { ProductId = 5, Name = "Геймърска мишка Redragon M711", Price = 29.99m, Description = "RGB мишка с програмируеми бутони", ImagePath = "/images/mouses/redragon-m711.jpg", Category = new Category { CategoryId = 1, Name = "Мишки" } },

                  // Клавиатури
                  new Product { ProductId = 6, Name = "Механична клавиатура Corsair K70", Price = 120.00m, Description = "Клавиатура с Cherry MX Blue", ImagePath = "/images/keyboards/Keyboard-MX-blue.jpg", Category = new Category { CategoryId = 2, Name = "Клавиатури" } },
                  new Product { ProductId = 7, Name = "Razer BlackWidow V3", Price = 109.99m, Description = "RGB механична клавиатура", ImagePath = "/images/keyboards/razer-blackwidow.jpg", Category = new Category { CategoryId = 2, Name = "Клавиатури" } },
                  new Product { ProductId = 8, Name = "Logitech G213 Prodigy", Price = 69.99m, Description = "Геймърска мембранна клавиатура", ImagePath = "/images/keyboards/logitech-g213.jpg", Category = new Category { CategoryId = 2, Name = "Клавиатури" } },
                  new Product { ProductId = 9, Name = "SteelSeries Apex 3", Price = 79.99m, Description = "Водоустойчива RGB клавиатура", ImagePath = "/images/keyboards/apex-3.jpg", Category = new Category { CategoryId = 2, Name = "Клавиатури" } },
                  new Product { ProductId = 10, Name = "Redragon K552 Kumara", Price = 49.99m, Description = "Механична клавиатура с червени суичове", ImagePath = "/images/keyboards/redragon-k552.jpg", Category = new Category { CategoryId = 2, Name = "Клавиатури" } },

                  // Слушалки
                  new Product { ProductId = 11, Name = "Геймърски слушалки Razer Kraken", Price = 99.00m, Description = "Слушалки с микрофон и RGB", ImagePath = "/images/headsets/headset-razer.jpg", Category = new Category { CategoryId = 3, Name = "Слушалки" } },
                  new Product { ProductId = 12, Name = "SteelSeries Arctis 5", Price = 89.99m, Description = "RGB геймърски слушалки", ImagePath = "/images/headsets/arctis-5.jpg", Category = new Category { CategoryId = 3, Name = "Слушалки" } },
                  new Product { ProductId = 13, Name = "HyperX Cloud II", Price = 109.99m, Description = "Геймърски слушалки с микрофон", ImagePath = "/images/headsets/hyperx-cloud2.jpg", Category = new Category { CategoryId = 3, Name = "Слушалки" } },
                  new Product { ProductId = 14, Name = "Logitech G432", Price = 79.99m, Description = "7.1 съраунд слушалки", ImagePath = "/images/headsets/logitech-g432.jpg", Category = new Category { CategoryId = 3, Name = "Слушалки" } },
                  new Product { ProductId = 15, Name = "Redragon Ares H120", Price = 39.99m, Description = "Бюджетни геймърски слушалки", ImagePath = "/images/headsets/redragon-h120.jpg", Category = new Category { CategoryId = 3, Name = "Слушалки" } },

                  // Монитори
                  new Product { ProductId = 16, Name = "Монитор ASUS 27''", Price = 369.99m, Description = "144Hz IPS монитор", ImagePath = "/images/monitors/Gaming-Monitor-144hz.jpg", Category = new Category { CategoryId = 4, Name = "Монитори" } },
                  new Product { ProductId = 17, Name = "Acer Predator 24''", Price = 299.99m, Description = "Gaming монитор с 165Hz", ImagePath = "/images/monitors/acer-predator.jpg", Category = new Category { CategoryId = 4, Name = "Монитори" } },
                  new Product { ProductId = 18, Name = "LG Ultragear 32''", Price = 449.99m, Description = "QHD монитор за игри", ImagePath = "/images/monitors/lg-ultragear.jpg", Category = new Category { CategoryId = 4, Name = "Монитори" } },
                  new Product { ProductId = 19, Name = "Samsung Odyssey 27''", Price = 399.99m, Description = "Извит 240Hz монитор", ImagePath = "/images/monitors/samsung-odyssey.jpg", Category = new Category { CategoryId = 4, Name = "Монитори" } },
                  new Product { ProductId = 20, Name = "Dell S2721HGF", Price = 279.99m, Description = "Curved монитор 144Hz", ImagePath = "/images/monitors/dell-s2721hgf.jpg", Category = new Category { CategoryId = 4, Name = "Монитори" } },

                  // Аксесоари
                  new Product { ProductId = 21, Name = "Уеб камера Logitech C920", Price = 89.99m, Description = "1080p уеб камера", ImagePath = "/images/accessories/camera-web-1080p.jpg", Category = new Category { CategoryId = 5, Name = "Аксесоари" } },
                  new Product { ProductId = 22, Name = "Подложка за мишка SteelSeries QcK", Price = 19.99m, Description = "Голяма подложка за мишка", ImagePath = "/images/accessories/qck-pad.jpg", Category = new Category { CategoryId = 5, Name = "Аксесоари" } },
                  new Product { ProductId = 23, Name = "Стойка за слушалки RGB", Price = 29.99m, Description = "LED поставка за слушалки", ImagePath = "/images/accessories/headset-stand.jpg", Category = new Category { CategoryId = 5, Name = "Аксесоари" } },
                  new Product { ProductId = 24, Name = "USB Hub 4-порта", Price = 14.99m, Description = "Разклонител за USB", ImagePath = "/images/accessories/usb-hub.jpg", Category = new Category { CategoryId = 5, Name = "Аксесоари" } },
                  new Product { ProductId = 25, Name = "Кабелен мениджмънт комплект", Price = 12.99m, Description = "Организиране на кабели", ImagePath = "/images/accessories/cable-management.jpg", Category = new Category { CategoryId = 5, Name = "Аксесоари" } }
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
            var demoProducts = GetDemoProducts(); // извеждаме списъка в отделен метод

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
        // Мишки
        new Product { ProductId = 1, Name = "Геймърска мишка Logitech G502", Price = 59.99m, Description = "Ergonomic RGB мишка", ImagePath = "/images/mouses/gaming-mouse.jpg", Category = new Category { CategoryId = 1, Name = "Мишки" } },
        new Product { ProductId = 2, Name = "Мишка Razer DeathAdder", Price = 49.99m, Description = "Оптична мишка с 16000 DPI", ImagePath = "/images/mouses/razer-deathadder.jpg", Category = new Category { CategoryId = 1, Name = "Мишки" } },
        new Product { ProductId = 3, Name = "Мишка SteelSeries Rival 3", Price = 39.99m, Description = "FPS мишка с RGB подсветка", ImagePath = "/images/mouses/steelseries-rival3.jpg", Category = new Category { CategoryId = 1, Name = "Мишки" } },
        new Product { ProductId = 4, Name = "Безжична мишка Logitech M185", Price = 24.99m, Description = "Компактна безжична мишка", ImagePath = "/images/mouses/logitech-m185.jpg", Category = new Category { CategoryId = 1, Name = "Мишки" } },
        new Product { ProductId = 5, Name = "Геймърска мишка Redragon M711", Price = 29.99m, Description = "RGB мишка с програмируеми бутони", ImagePath = "/images/mouses/redragon-m711.jpg", Category = new Category { CategoryId = 1, Name = "Мишки" } },

        // Клавиатури
        new Product { ProductId = 6, Name = "Механична клавиатура Corsair K70", Price = 120.00m, Description = "Клавиатура с Cherry MX Blue", ImagePath = "/images/keyboards/Keyboard-MX-blue.jpg", Category = new Category { CategoryId = 2, Name = "Клавиатури" } },
        new Product { ProductId = 7, Name = "Razer BlackWidow V3", Price = 109.99m, Description = "RGB механична клавиатура", ImagePath = "/images/keyboards/razer-blackwidow.jpg", Category = new Category { CategoryId = 2, Name = "Клавиатури" } },
        new Product { ProductId = 8, Name = "Logitech G213 Prodigy", Price = 69.99m, Description = "Геймърска мембранна клавиатура", ImagePath = "/images/keyboards/logitech-g213.jpg", Category = new Category { CategoryId = 2, Name = "Клавиатури" } },
        new Product { ProductId = 9, Name = "SteelSeries Apex 3", Price = 79.99m, Description = "Водоустойчива RGB клавиатура", ImagePath = "/images/keyboards/apex-3.jpg", Category = new Category { CategoryId = 2, Name = "Клавиатури" } },
        new Product { ProductId = 10, Name = "Redragon K552 Kumara", Price = 49.99m, Description = "Механична клавиатура с червени суичове", ImagePath = "/images/keyboards/redragon-k552.jpg", Category = new Category { CategoryId = 2, Name = "Клавиатури" } },

        // Слушалки
        new Product { ProductId = 11, Name = "Геймърски слушалки Razer Kraken", Price = 99.00m, Description = "Слушалки с микрофон и RGB", ImagePath = "/images/headsets/headset-razer.jpg", Category = new Category { CategoryId = 3, Name = "Слушалки" } },
        new Product { ProductId = 12, Name = "SteelSeries Arctis 5", Price = 89.99m, Description = "RGB геймърски слушалки", ImagePath = "/images/headsets/arctis-5.jpg", Category = new Category { CategoryId = 3, Name = "Слушалки" } },
        new Product { ProductId = 13, Name = "HyperX Cloud II", Price = 109.99m, Description = "Геймърски слушалки с микрофон", ImagePath = "/images/headsets/hyperx-cloud2.jpg", Category = new Category { CategoryId = 3, Name = "Слушалки" } },
        new Product { ProductId = 14, Name = "Logitech G432", Price = 79.99m, Description = "7.1 съраунд слушалки", ImagePath = "/images/headsets/logitech-g432.jpg", Category = new Category { CategoryId = 3, Name = "Слушалки" } },
        new Product { ProductId = 15, Name = "Redragon Ares H120", Price = 39.99m, Description = "Бюджетни геймърски слушалки", ImagePath = "/images/headsets/redragon-h120.jpg", Category = new Category { CategoryId = 3, Name = "Слушалки" } },

        // Монитори
        new Product { ProductId = 16, Name = "Монитор ASUS 27''", Price = 369.99m, Description = "144Hz IPS монитор", ImagePath = "/images/monitors/Gaming-Monitor-144hz.jpg", Category = new Category { CategoryId = 4, Name = "Монитори" } },
        new Product { ProductId = 17, Name = "Acer Predator 24''", Price = 299.99m, Description = "Gaming монитор с 165Hz", ImagePath = "/images/monitors/acer-predator.jpg", Category = new Category { CategoryId = 4, Name = "Монитори" } },
        new Product { ProductId = 18, Name = "LG Ultragear 32''", Price = 449.99m, Description = "QHD монитор за игри", ImagePath = "/images/monitors/lg-ultragear.jpg", Category = new Category { CategoryId = 4, Name = "Монитори" } },
        new Product { ProductId = 19, Name = "Samsung Odyssey 27''", Price = 399.99m, Description = "Извит 240Hz монитор", ImagePath = "/images/monitors/samsung-odyssey.jpg", Category = new Category { CategoryId = 4, Name = "Монитори" } },
        new Product { ProductId = 20, Name = "Dell S2721HGF", Price = 279.99m, Description = "Curved монитор 144Hz", ImagePath = "/images/monitors/dell-s2721hgf.jpg", Category = new Category { CategoryId = 4, Name = "Монитори" } },

        // Аксесоари
        new Product { ProductId = 21, Name = "Уеб камера Logitech C920", Price = 89.99m, Description = "1080p уеб камера", ImagePath = "/images/accessories/camera-web-1080p.jpg", Category = new Category { CategoryId = 5, Name = "Аксесоари" } },
        new Product { ProductId = 22, Name = "Подложка за мишка SteelSeries QcK", Price = 19.99m, Description = "Голяма подложка за мишка", ImagePath = "/images/accessories/qck-pad.jpg", Category = new Category { CategoryId = 5, Name = "Аксесоари" } },
        new Product { ProductId = 23, Name = "Стойка за слушалки RGB", Price = 29.99m, Description = "LED поставка за слушалки", ImagePath = "/images/accessories/headset-stand.jpg", Category = new Category { CategoryId = 5, Name = "Аксесоари" } },
        new Product { ProductId = 24, Name = "USB Hub 4-порта", Price = 14.99m, Description = "Разклонител за USB", ImagePath = "/images/accessories/usb-hub.jpg", Category = new Category { CategoryId = 5, Name = "Аксесоари" } },
        new Product { ProductId = 25, Name = "Кабелен мениджмънт комплект", Price = 12.99m, Description = "Организиране на кабели", ImagePath = "/images/accessories/cable-management.jpg", Category = new Category { CategoryId = 5, Name = "Аксесоари" } }
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
