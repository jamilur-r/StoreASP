using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace StoreASP.Models
{
    public class Cart
    {
        public Cart()
        {
            this.Items = new HashSet<CartItem>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public virtual ICollection<CartItem> Items { get; set; }
        [Required]
        public virtual User CartHolder { get; set; }
    }
}