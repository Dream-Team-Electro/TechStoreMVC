using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStoreMVC.Views.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [StringLength(500, ErrorMessage = "Описание на продукта не трябва да надвишава 500 символа.")]
        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;


        [Required]
        public string ImagePath { get; set; }

    }
}
