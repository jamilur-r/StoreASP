using System;
using Microsoft.AspNetCore.Identity;


namespace StoreASP.Models
{
    public class UserRole : IdentityRole<Guid>
    {
        public UserRole(string Name) : base(Name) { }
    }
}