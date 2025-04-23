using TechStoreMVC.Controllers;
using TechStoreMVC.Models;
using TechStoreMVC.Repositories;
using Xunit;


    public class ProductControllerTests
    {
    [Fact]
    public void Add_ShouldIncreaseProductCount()
    {
        var repo = new InMemoryProductRepository();
        var controller = new ProductController(repo);

        var product = new Product
        {
            Name = "Тестов продукт",
            Price = 100,
            Quantity = 5,
            Category = new Category { Id = 1, Name = "Тест" }
        };

        controller.Add(product);
        var all = controller.GetAll();

        Assert.Single(all);
        Assert.Equal("Тестов продукт", all[0].Name);
    }
    }

