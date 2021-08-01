using System.Linq;
using StoreASP.Data;
using StoreASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace StoreASP.ViewComponents
{
    public class HeaderViewComponent
    : ViewComponent
    {
        private readonly SiteDBContext _context;

        public HeaderViewComponent(SiteDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            SiteSettings data = _context.SiteSettingss.FirstOrDefaultAsync().Result;


            return View("~/Views/Shared/_Header.cshtml", data);
        }
    }
}
