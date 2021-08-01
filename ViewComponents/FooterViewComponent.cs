using StoreASP.Models;
using StoreASP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace StoreASP.ViewComponents
{
    public class FooterViewComponent: ViewComponent {

        private readonly SiteDBContext _context;
        public FooterViewComponent(SiteDBContext context){ _context = context; }

        public IViewComponentResult Invoke(){
            SiteSettings data = _context.SiteSettingss.FirstOrDefaultAsync().Result;
            return View("~/Views/Shared/_Footer.cshtml", data);
        }
    }
}
