using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace StoreASP.Models
{
    public class User: IdentityUser<Guid> {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName {get; set;} 

        [Required]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}
        
    }
}