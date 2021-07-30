using System.ComponentModel.DataAnnotations;

namespace StoreASP.Models.FormModel
{
    public class SignInForm {
        [Required(ErrorMessage = "Required")]
        [StringLength(30, ErrorMessage ="Email must not exceed 30 character")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email {get; set;}

        [Required(ErrorMessage = "Required")]
        [StringLength(20, ErrorMessage ="Password must not exceed 20 character")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password {get; set;}
    }
}