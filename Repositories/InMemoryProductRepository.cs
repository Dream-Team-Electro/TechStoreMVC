using TechStoreMVC.Models;

namespace TechStoreMVC.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public void Add(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
        }
        public void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Quantity = product.Quantity;
                existing.Discount = product.Discount;
                existing.CategoryId = product.CategoryId;
            }
        }

        public void Delete(int id) => _products.RemoveAll(p => p.Id == id);
        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
        public List<Product> GetAll() => _products;
        public List<Product> FilterByCategory(string categoryName) =>
            _products.Where(p => p.Category?.Name == categoryName).ToList();
        public List<Product> SortByPrice(bool descending) =>
            descending ? _products.OrderByDescending(p => p.Price).ToList()
                       : _products.OrderBy(p => p.Price).ToList();
    }
}
