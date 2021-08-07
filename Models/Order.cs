using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreASP.Models{
    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        public  ICollection<User> Buyer {get; set;}

        [Required]
        public virtual ICollection<Product> Products {get; set;}

        [Required]
        public string Status {get; set;}

        [Required]
        public float GrandTotal { get; set; }
    }
}