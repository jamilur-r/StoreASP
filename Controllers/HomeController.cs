using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreASP.Models;
using StoreASP.Data;
using StoreASP.Models.ViewModel;


namespace StoreASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SiteDBContext _Context;

        public HomeController(ILogger<HomeController> logger, SiteDBContext context)
        {
            _logger = logger;
            _Context = context;
        }

        public IActionResult Index()
        {
            SiteSettings store = _Context.SiteSettingss.FirstOrDefault();
            List<Product> products = _Context.Products.OrderBy(item => item.Name).ToList();

            HomeView data = new HomeView
            {
                Store = store,
                Products = products
            };

            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
