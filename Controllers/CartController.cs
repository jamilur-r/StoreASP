using System;
using System.Collections.Generic;
using StoreASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StoreASP.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace StoreASP.Controllers
{
    [Authorize(Roles = "USER")]
    public class CartController : Controller
    {
        private readonly SiteDBContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;

        public CartController(SiteDBContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signInManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNew(Guid ProductId)
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                Product product = await _context.Products.FindAsync(ProductId);
                Cart doesHaveCart = _context.Carts.Where(obj => obj.CartHolder.Id == user.Id).FirstOrDefault();

                if (doesHaveCart != null)
                {
                    CartItem cartItem = new CartItem
                    {
                        Item = product
                    };


                    doesHaveCart.Items.Add(cartItem);

                    await _context.CartItems.AddAsync(cartItem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    CartItem cartItem = new CartItem
                    {
                        Item = product
                    };

                    List<CartItem> items = new List<CartItem>();
                    items.Add(cartItem);

                    await _context.CartItems.AddAsync(cartItem);

                    Cart cart = new Cart
                    {
                        Items = items,
                        CartHolder = user
                    };
                    await _context.Carts.AddAsync(cart);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (System.Exception)
            {

                return RedirectToAction("Index", "Home");
            }
        }
    }
}