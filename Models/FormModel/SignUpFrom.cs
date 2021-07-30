using System;
using System.ComponentModel.DataAnnotations;


namespace StoreASP.Models.FormModel
{
    public class SignUpForm {
        [Required(ErrorMessage = "Required")]
        [StringLength(20, ErrorMessage ="First name must not exceed 20 character")]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}

        [Required(ErrorMessage = "Required")]
        [StringLength(20, ErrorMessage ="Last name must not exceed 20 character")]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}

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

        [Required(ErrorMessage = "Required")]
        [StringLength(20, ErrorMessage ="Password must not exceed 20 character")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password does not match")]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm {get; set;}
    }
}
