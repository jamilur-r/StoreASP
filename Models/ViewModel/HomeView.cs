using StoreASP.Models;
using System;
using System.Collections.Generic;


namespace StoreASP.Models.ViewModel
{
    public class HomeView
    {
        public SiteSettings Store { get; set; }
        public List<Product> Products { get; set; }
    }
}