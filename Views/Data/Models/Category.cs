using System.ComponentModel.DataAnnotations;

namespace TechStoreMVC.Views.Data.Models
{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }

        [StringLength(100, ErrorMessage = "Името на категорията не трябва да надвишава 100 символа.")]
        public string Name { get; set; } = null!;


        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
