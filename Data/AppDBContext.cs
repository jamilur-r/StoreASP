using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StoreASP.Models;

namespace StoreASP.Data
{
    public class AppDBContext : IdentityDbContext<User, UserRole, Guid> {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options){}
    }
}