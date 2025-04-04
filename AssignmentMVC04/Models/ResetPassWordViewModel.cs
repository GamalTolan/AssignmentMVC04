using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC04.Models
{
    public class ResetPassWordViewModel
    {
        [Required(ErrorMessage = "Password Name is Required")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Name is Required")]
        [Compare(nameof(Password), ErrorMessage = "Password Dose not Match Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }

        public string Email { get; set; }
    }
}
