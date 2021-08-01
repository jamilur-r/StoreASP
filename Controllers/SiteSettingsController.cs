using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreASP.Data;
using Microsoft.AspNetCore.Authorization;
using StoreASP.Models;
using Microsoft.EntityFrameworkCore;
using StoreASP.Models.FormModel;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Hosting;



namespace StoreASP.Controllers
{

    [Authorize(Roles = "ADMIN")]
    public class SiteSettingsController : Controller
    {
        private readonly SiteDBContext _context;
        private readonly IWebHostEnvironment _env;
        public SiteSettingsController(SiteDBContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        [HttpGet]

        public IActionResult Index()
        {
            SiteSettings data = _context.SiteSettingss.FirstOrDefaultAsync().Result;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SiteSettingsForm formData, IFormFile logo){
            try
            {
                if(ModelState.IsValid){
                    var fileName = Path.GetFileName(logo.FileName);
                    var saveName = "Upload/" + Guid.NewGuid().ToString() + "_" + fileName;
                    var serverPath = Path.Combine(_env.WebRootPath, saveName);
                    await logo.CopyToAsync(new FileStream(serverPath, FileMode.Create));

                    SiteSettings data = new SiteSettings{
                        StoreName = formData.StoreName,
                        Description = formData.Description,
                        Logo = saveName
                    };
                    await _context.AddAsync(data);
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
