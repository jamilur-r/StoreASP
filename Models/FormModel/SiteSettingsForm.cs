using System.ComponentModel.DataAnnotations;
using System;

namespace StoreASP.Models.FormModel
{
    public class SiteSettingsForm {
        public Guid Id {get; set;}

        
        [Required]
        [StringLength(15)]
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }


        [Required]
        [StringLength(300)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Decription")]
        public string Description { get; set; }

        [Display(Name = "Logo")]
        [DataType(DataType.Upload)]
        public string Logo { get; set; }
    }
}