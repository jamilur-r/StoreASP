using System.ComponentModel.DataAnnotations;
using System;

namespace StoreASP.Models
{
    public class SiteSettings
    {
        [Key]
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
        public byte[] Logo { get; set; }
    }
}