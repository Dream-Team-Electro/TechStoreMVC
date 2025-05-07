namespace TechStoreMVC.Data.Models
{
    public class ErrorViewModel
    {
        // Това е идентификаторът на заявката, който ще се показва при грешка
        public string RequestId { get; set; }

        // Тази част проверява дали RequestId е наличен и дали трябва да бъде показан
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}