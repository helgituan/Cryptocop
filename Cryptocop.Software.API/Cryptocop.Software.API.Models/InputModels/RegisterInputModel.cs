using System.ComponentModel.DataAnnotations;
namespace Cryptocop.Software.API.Models.InputModels
{
    public class RegisterInputModel
    {

        // [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string PasswordConfirmation { get; set; }

    }
}