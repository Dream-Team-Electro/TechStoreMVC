using TechStoreMVC.Models;
namespace TechStoreMVC.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        Product GetById(int id);
        List<Product> GetAll();
        List<Product> FilterByCategory(string categoryName);
        List<Product> SortByPrice(bool descending);
    }
}
