using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace StoreASP.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public virtual List<CartItem> Items { get; set; }
        [Required]
        public virtual User CartHolder { get; set; }
    }
}