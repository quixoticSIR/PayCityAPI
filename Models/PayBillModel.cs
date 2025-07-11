using System.ComponentModel.DataAnnotations;

namespace PayCityAPI.Models
{
    public class PayBillModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BillerName { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public int UserId { get; set; }
    }
} 