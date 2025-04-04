using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC04.Models
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Email Name is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Name is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$",
        ErrorMessage = "The password must be at least 6 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;

    }
}
