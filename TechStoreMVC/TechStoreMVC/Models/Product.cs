namespace TechStoreMVC.Models
{
    public class Product
    {
        public Product(int id, string name, int categoryId, decimal price, string description, Category _category)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Price = price;
            Description = description;
            _Category = _category;
        }

        public int Id { get; set; }  

        public string Name { get; set; }  

        public int CategoryId { get; set; } 

        public decimal Price { get; set; } 

        public string Description { get; set; }

        public Category _Category { get; set; }

        public override string ToString()
        {
            return $"{Name} {_Category.Name} - {Price:f2}: {Description}";
        }
    }
}
