using System;
using System.ComponentModel.DataAnnotations;


namespace StoreASP.Models.FormModel
{
    public class SignUpForm {
        [Required]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}

        [Required]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}

        [Required]
        [StringLength(30)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email {get; set;}

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password {get; set;}

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm {get; set;}
    }
}
