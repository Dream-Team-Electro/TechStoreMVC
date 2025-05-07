using System.ComponentModel.DataAnnotations;

namespace TechStoreMVC.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Потребителското име е задължително.")]
        [StringLength(50, ErrorMessage = "Потребителското име не трябва да надвишава 50 символа.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Имейл адресът е задължителен.")]
        [EmailAddress(ErrorMessage = "Моля, въведете валиден имейл адрес.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Паролата трябва да е поне 6 символа.")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } // Допълнителен атрибут за администраторски права
    }
}