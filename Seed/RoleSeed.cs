using StoreASP.Enums;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using StoreASP.Models;


namespace StoreASP.Seed
{
    public class RoleSeed
    {
        public static async Task SeedRoles(UserManager<User> _userManager, RoleManager<UserRole> _roleManager)
        {
            await _roleManager.CreateAsync(new UserRole(Enums.Role.ADMIN.ToString()));
            await _roleManager.CreateAsync(new UserRole(Enums.Role.USER.ToString()));
            await _roleManager.CreateAsync(new UserRole(Enums.Role.SELLER.ToString()));
        }
        public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new User
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "Jamilur",
                LastName = "Rahman",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Keepaway1147++");
                await userManager.AddToRoleAsync(defaultUser, Role.ADMIN.ToString());
            }
        }
    }
}