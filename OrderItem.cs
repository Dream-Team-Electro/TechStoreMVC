using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechStoreMVC.Data.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }


        [Required(ErrorMessage = "Продуктът е задължителен!")]
        public int ProductId { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "Количеството е задължително.")]
        [Range(1, int.MaxValue, ErrorMessage = "Количеството трябва да е поне 1.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Цената е задължителна.")]
        public decimal Price { get; set; }
    }
}