using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreASP.Models.FormModel
{
    public class ProductForm
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }

        [Display(Name = "Discount")]
        [Range(0.0, 1.0)]

        public float Discount { get; set; }

        [Required]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public string Image { get; set; }
    }
}