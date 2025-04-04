using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC04.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email Name is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

    }
}
