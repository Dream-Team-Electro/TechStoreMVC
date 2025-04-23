namespace TechStoreMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int Quantity { get; set; }
        public string Status => Quantity == 0 ? "Изчерпан" : "Наличен";
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
