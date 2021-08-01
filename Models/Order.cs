using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreASP.Models{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public virtual User Buyer {get; set;}

        [Required]
        public virtual List<Product> Products {get; set;}

        [Required]
        public string Status {get; set;}

        [Required]
        public float GrandTotal { get; set; }
    }
}