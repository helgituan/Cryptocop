using System.ComponentModel.DataAnnotations;
namespace Cryptocop.Software.API.Models.InputModels
{
    public class RegisterInputModel
    {
        /*
         * RegisterInputModel
•Email* (string)
•Must be a valid email address
•FullName* (string)
•A minimum length of 3 characters
•Password* (string)
•A minimum length of 8 characters
•PasswordConfirmation* (string)
•A minimum length of 8 characters
•Must be the same value as the property Password
         */
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }

    }
}