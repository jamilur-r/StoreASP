using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreASP.Models
{
    public class CartItem
    {
        public CartItem()
        {
            this.Carts = new HashSet<Cart>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public  Product Item {get; set;}
        public virtual ICollection<Cart> Carts {get; set;}
    }
}