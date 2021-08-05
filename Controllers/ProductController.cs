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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                Product data = await _context.Products.FindAsync(Id);
                _context.Products.Remove(data);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            try
            {
                Product data = await _context.Products.FindAsync(Id);
                ProductForm formData = new ProductForm
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description,
                    Discount = data.Discount,
                    Price = data.Price,
                };
                return View(formData);
            }
            catch (System.Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductForm formData, Guid Id, IFormFile Img)
        {
            try
            {
                Product product = await _context.Products.FindAsync(Id);
                // product.Name = formData.Name;
                if (Img != null)
                {
                    Utility utility = new Utility();
                    string saveName = await utility.Upload(Img, _env);

                    product.Name = formData.Name;
                    product.Description = formData.Description;
                    product.Price = formData.Price;
                    product.Discount = formData.Discount;
                    product.Image = saveName;

                    await _context.SaveChangesAsync();
                }
                else
                {
                    product.Name = formData.Name;
                    product.Description = formData.Description;
                    product.Price = formData.Price;
                    product.Discount = formData.Discount;

                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index");
                // return Ok(product);
            }
            catch (System.Exception)
            {
                throw;

                // return RedirectToAction("Index");
            }
        }
    }
}