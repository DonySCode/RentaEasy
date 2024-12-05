using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentaEasy.Core.Entities;

namespace RentaEasy.Infrastructure.Data
{
    public class RentaEasyDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Property> Properties { get; set; }

        public RentaEasyDbContext(DbContextOptions<RentaEasyDbContext> options) : base(options) { }
    }
}
