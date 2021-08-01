using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreASP.Models
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public virtual Product Item {get; set;}

    }
}