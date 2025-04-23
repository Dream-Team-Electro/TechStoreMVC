using System.ComponentModel.DataAnnotations;

namespace TechStoreMVC.Views.Data.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Потребителят е задължителен.")]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required(ErrorMessage = "Дата на поръчка е задължителна.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Състоянието на поръчката е задължително.")]
        public string Status { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}
