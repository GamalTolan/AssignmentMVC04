using System.ComponentModel.DataAnnotations;

namespace AssignmentMVC04.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="Frist Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Name is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Name is Required")]
        
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Name is Required")]
        [Compare(nameof(Password),ErrorMessage ="Password Dose not Match Confirm Password")]
        public string ConfirmPassword{ get; set; }
        [Required(ErrorMessage = "Require To Agree")]
        public bool IsAgree { get; set; }


    }
}
