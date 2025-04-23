using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechStoreMVC.Models;
using TechStoreMVC.Repositories;

namespace TechStoreMVC.Controllers
{
    public class ProductController 
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Add(Product product) => _repository.Add(product);
        public void Update(Product product) => _repository.Update(product);
        public void Delete(int id) => _repository.Delete(id);
        public Product GetById(int id) => _repository.GetById(id);
        public List<Product> GetAll() => _repository.GetAll();
        public List<Product> FilterByCategory(string category) => _repository.FilterByCategory(category);
        public List<Product> SortByPrice(bool desc) => _repository.SortByPrice(desc);
    }
}
