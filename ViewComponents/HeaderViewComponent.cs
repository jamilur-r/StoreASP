using System.Linq;
using StoreASP.Data;
using StoreASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace StoreASP.ViewComponents
{
    public class DataFormat
    {
        public Cart Usercart { get; set; }
        public SiteSettings Settings { get; set; }
        public int ItemCount { get; set; }
    }

    public class HeaderViewComponent
    : ViewComponent
    {
        private readonly SiteDBContext _context;
        private readonly UserManager<User> _userMageger;
        private readonly SignInManager<User> _signinManager;

        public HeaderViewComponent(SiteDBContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userMageger = userManager;
            _signinManager = signInManager;
        }

        public IViewComponentResult Invoke()
        {

            SiteSettings settings = _context.SiteSettingss.FirstOrDefaultAsync().Result;
            User user = _userMageger.GetUserAsync(Request.HttpContext.User).Result;
            if (_signinManager.IsSignedIn(Request.HttpContext.User))
            {
                List<Cart> cart = _context.Carts.Where(item => item.CartHolder.Id == user.Id).ToList();
                List<CartItem> items = new List<CartItem>();


                DataFormat data = new DataFormat
                {
                    Settings = settings,
                    ItemCount = cart.Count
                };

                return View("~/Views/Shared/_Header.cshtml", data);
            }
            else
            {
                DataFormat data = new DataFormat
                {
                    Settings = settings,
                };

                return View("~/Views/Shared/_Header.cshtml", data);
            }

        }
    }
}
