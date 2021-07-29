using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using StoreASP.Models;
using System.Threading.Tasks;
using System.Web;
using StoreASP.Models.FormModel;


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
        public IActionResult Register() {
            return View("/Account/Register");
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
                            await _userManager.AddToRoleAsync(user, "Admin");
                            await _signinManager.SignInAsync(user, true);
                            
                            return RedirectToPage("/Index");
                        }
                    }
                }
                return RedirectToPage("/Index");

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}