using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreASP.Data;
using StoreASP.Models;
using StoreASP.Models.FormModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using StoreASP.Utils;


namespace StoreASP.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class ProductController : Controller
    {
        private readonly SiteDBContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(SiteDBContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Products.ToListAsync().Result;
            // return Ok(products);
            return View(products);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductForm formData, IFormFile Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    Utility utility = new Utility();
                    string saveName = await utility.Upload(Image, _env);

                    Product product = new Product
                    {
                        Name = formData.Name,
                        Description = formData.Description,
                        Price = formData.Price,
                        Discount = formData.Discount,
                        Image = saveName
                    };

                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                ViewBag.Error = "Data not valid";

                return View();
            }
            catch (System.Exception)
            {

                ViewBag.Error = "Failed To Create";
                return View();
            }
        }
    }
}