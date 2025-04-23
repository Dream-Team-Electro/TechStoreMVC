using TechStoreMVC.Controllers;
using TechStoreMVC.Models;
using TechStoreMVC.Repositories;
{
    var repo = new InMemoryProductRepository();
    var controller = new InMemoryProductRepository();
    
    while (true)
    {
        Console.WriteLine("\n1. ������ �������\n2. ������ ������\n3. ����������\n4. ������\n5. ��������� �� ���������\n6. �������� �� ����\n7. �����");
        Console.Write("�����: ");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.Write("���: ");
                string name = Console.ReadLine();
                Console.Write("����: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.Write("�������� (%): ");
                decimal discount = decimal.Parse(Console.ReadLine());
                Console.Write("����������: ");
                int quantity = int.Parse(Console.ReadLine());
                Console.Write("���������: ");
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
                    Console.WriteLine($"{p.Id}. {p.Name} - {p.Price}�� -{p.Quantity}�� - {p.Status}");
                break;

            case "3":
                Console.Write("ID �� �������� �� ��������: ");
                int id = int.Parse(Console.ReadLine());
                var prod = controller.GetById(id);
                if (prod == null) break;
                Console.Write("���� ���: ");
                prod.Name = Console.ReadLine();
                Console.Write("���� ����: ");
                prod.Price = decimal.Parse(Console.ReadLine());
                Console.Write("���� ��������: ");
                prod.Discount = decimal.Parse(Console.ReadLine());
                Console.Write("���� ����������: ");
                prod.Quantity = int.Parse(Console.ReadLine());
                controller.Update(prod);
                break;

            case "4":
                Console.Write("ID �� ���������: ");
                controller.Delete(int.Parse(Console.ReadLine()));
                break;

            case "5":
                Console.Write("���������: ");
                var filtered = controller.FilterByCategory(Console.ReadLine());
                foreach (var p in filtered)
                    Console.WriteLine($"{p.Id}. {p.Name} - {p.Price}��");
                break;

            case "6":
                Console.Write("��������� ( 1 - ������, 2 - ������): ");
                bool desc = Console.ReadLine() == "2";
                var sorted = controller.SortByPrice(desc);
                foreach (var p in sorted)
                    Console.WriteLine($"{p.Id} . {p.Name} - {p.Price}��");
                break;

            case "7": return;
        }
    }

    
}
