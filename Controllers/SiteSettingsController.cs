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
        public IActionResult Update()
        {
            SiteSettings data = _context.SiteSettingss.FirstOrDefaultAsync().Result;
            SiteSettingsForm formData = new SiteSettingsForm
            {
                Id = data.Id,
                StoreName = data.StoreName,
                Description = data.Description,
                Logo = data.Logo
            };
            return View(formData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SiteSettingsForm formData, IFormFile logo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(logo.FileName);
                    var saveName = "Upload/" + Guid.NewGuid().ToString() + "_" + fileName;
                    var serverPath = Path.Combine(_env.WebRootPath, saveName);
                    await logo.CopyToAsync(new FileStream(serverPath, FileMode.Create));

                    SiteSettings data = new SiteSettings
                    {
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                if (Id != null)
                {
                    SiteSettings settings = await _context.SiteSettingss.FindAsync(Id);
                    _context.SiteSettingss.Remove(settings);
                    await _context.SaveChangesAsync();


                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception)
            {

                ViewBag.Error = "Failed To Delete";
                return RedirectToAction("Index");
                // throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(SiteSettingsForm formData, IFormFile Logo, Guid Id)
        {
            try
            {
                SiteSettings old = await _context.SiteSettingss.FindAsync(Id);

                if (Logo != null)
                {
                    var fileName = Path.GetFileName(Logo.FileName);
                    var saveName = "Upload/" + Guid.NewGuid().ToString() + "_" + fileName;
                    var serverPath = Path.Combine(_env.WebRootPath, saveName);
                    await Logo.CopyToAsync(new FileStream(serverPath, FileMode.Create));

                    old.Logo = saveName;
                    old.StoreName = formData.StoreName;
                    old.Description = formData.Description;
                    await _context.SaveChangesAsync();

                }
                else
                {
                    old.StoreName = formData.StoreName;
                    old.Description = formData.Description;
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }


}
