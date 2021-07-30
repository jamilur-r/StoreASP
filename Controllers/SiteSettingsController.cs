using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreASP.Data;
using Microsoft.AspNetCore.Authorization;


namespace StoreASP.Controllers
{

    [Authorize(Roles = "ADMIN")]
    public class SiteSettingsController : Controller
    {
        private readonly SiteDBContext _context;
        public SiteSettingsController(SiteDBContext context)
        {
            _context = context;
        }


        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

    }


}
