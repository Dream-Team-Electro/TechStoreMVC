using TechStoreMVC.Controllers;
using TechStoreMVC.Models;
using TechStoreMVC.Repositories;
{
    var repo = new InMemoryProductRepository();
    var controller = new InMemoryProductRepository();
    
    while (true)
    {
        Console.WriteLine("\n1. Добави продукт\n2. Покажи всички\n3. Редактирай\n4. Изтрий\n5. Филтрирай по категория\n6. Сортирай по цена\n7. Изход");
        Console.Write("Избор: ");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.Write("Име: ");
                string name = Console.ReadLine();
                Console.Write("Цена: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.Write("Отстъпка (%): ");
                decimal discount = decimal.Parse(Console.ReadLine());
                Console.Write("Количество: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.Write("Категория: ");
                string cat = Console.ReadLine();

                var category = new Category { Id = 1, Name = cat };
                controller.Add(new Product
                {
                    Name = name,
                    Price = price,
                    Discount = discount,
                    Quantity = quantity,
                    Category = category,
                    CategoryId = category.Id
                });
                break;

            case "2":
                var products = controller.GetAll();
                foreach (var p in products)
                    Console.WriteLine($"{p.Id}. {p.Name} - {p.Price}лв -{p.Quantity}бр - {p.Status}");
                break;

            case "3":
                Console.Write("ID на продукта за редакция: ");
                int id = int.Parse(Console.ReadLine());
                var prod = controller.GetById(id);
                if (prod == null) break;
                Console.Write("Ново име: ");
                prod.Name = Console.ReadLine();
                Console.Write("Нова цена: ");
                prod.Price = decimal.Parse(Console.ReadLine());
                Console.Write("Нова отстъпка: ");
                prod.Discount = decimal.Parse(Console.ReadLine());
                Console.Write("Ново количество: ");
                prod.Quantity = int.Parse(Console.ReadLine());
                controller.Update(prod);
                break;

            case "4":
                Console.Write("ID за изтриване: ");
                controller.Delete(int.Parse(Console.ReadLine()));
                break;

            case "5":
                Console.Write("Категория: ");
                var filtered = controller.FilterByCategory(Console.ReadLine());
                foreach (var p in filtered)
                    Console.WriteLine($"{p.Id}. {p.Name} - {p.Price}лв");
                break;

            case "6":
                Console.Write("Сортитрай ( 1 - нагоре, 2 - надолу): ");
                bool desc = Console.ReadLine() == "2";
                var sorted = controller.SortByPrice(desc);
                foreach (var p in sorted)
                    Console.WriteLine($"{p.Id} . {p.Name} - {p.Price}лв");
                break;

            case "7": return;
        }
    }

    
}
