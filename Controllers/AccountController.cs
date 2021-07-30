using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using StoreASP.Models;
using System.Threading.Tasks;
using System.Web;
using StoreASP.Models.FormModel;
using Microsoft.AspNetCore.Authorization;


namespace StoreASP.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private UserManager<User> _userManager { get; }
        private SignInManager<User> _signinManager { get; }

        public AccountController(ILogger<AccountController> logger, UserManager<User> userManager, SignInManager<User> signinManager)
        {
            _logger = logger;
            _signinManager = signinManager;
            _userManager = userManager;
        }


        [HttpGet]
        [Authorize(Roles = "USER")]
        public IActionResult Dash()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult AdminDash()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetDash()
        {
            var x = _userManager.GetUserAsync(HttpContext.User).Result;

            if (_userManager.IsInRoleAsync(x, "ADMIN").Result)
            {
                return RedirectToAction("AdminDash");
            }
            else
            {
                return RedirectToAction("Dash");
            }
        }

        public IActionResult Login()
        {
            if (_signinManager.IsSignedIn(HttpContext.User))
            {
                var x = _userManager.GetUserAsync(HttpContext.User).Result;

                if (_userManager.IsInRoleAsync(x, "ADMIN").Result)
                {
                    return RedirectToAction("AdminDash");
                }
                else
                {
                    return RedirectToAction("Dash");
                }

            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (_signinManager.IsSignedIn(HttpContext.User))
            {
                var x = _userManager.GetUserAsync(HttpContext.User).Result;

                if (_userManager.IsInRoleAsync(x, "ADMIN").Result)
                {
                    return RedirectToAction("AdminDash");
                }
                else
                {
                    return RedirectToAction("Dash");
                }

            }
            else
            {
                return View();
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(SignInForm formData)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    User user = await _userManager.FindByEmailAsync(formData.Email);
                    if (user != null)
                    {
                        await _signinManager.SignInAsync(user, true);
                        if (_userManager.IsInRoleAsync(user, "ADMIN").Result)
                        {
                            return RedirectToAction("AdminDash", "Account");
                        }
                        else
                        {
                            return RedirectToAction("Dash", "Accoount");
                        }
                    }
                    else
                    {
                        return View();
                    }
                }
                return View();
            }
            catch (System.Exception)
            {

                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(SignUpForm formData)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    User user = await _userManager.FindByEmailAsync(formData.Email);
                    if (user == null)
                    {
                        user = new User();
                        user.Email = formData.Email;
                        user.UserName = formData.Email;
                        user.FirstName = formData.FirstName;
                        user.LastName = formData.LastName;

                        IdentityResult result = await _userManager.CreateAsync(user, formData.Password);
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, "USER");
                            await _signinManager.SignInAsync(user, true);

                            if (_userManager.IsInRoleAsync(user, "ADMIN").Result)
                            {
                                return RedirectToAction("AdminDash");
                            }
                            else
                            {
                                return RedirectToAction("Dash");
                            }
                        }
                    }
                }
                return View();

            }
            catch (System.Exception)
            {

                return View();
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signinManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception)
            {

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Route("/Account/AccessDenied")]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}


