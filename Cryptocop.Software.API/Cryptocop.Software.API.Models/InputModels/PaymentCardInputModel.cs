using System.ComponentModel.DataAnnotations;
namespace Cryptocop.Software.API.Models.InputModels
{
    public class PaymentCardInputModel
    {
        [Required]
        [MinLength(3)]
        public string CardholderName { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$", ErrorMessage = "Card Number isn't valid.")]
        public string CardNumber { get; set; }
        [Required]
        [Range(0, 12)]
        public int Month { get; set; }
        [Required]
        [Range(0, 99)]
        public int Year { get; set; }

    }
}