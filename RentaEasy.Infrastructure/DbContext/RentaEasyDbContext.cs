using Microsoft.EntityFrameworkCore;
using RentaEasy.Core.Entities;

namespace RentaEasy.Infrastructure.Data
{
    public class RentaEasyDbContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }

        public RentaEasyDbContext(DbContextOptions<RentaEasyDbContext> options) : base(options) { }
    }
}
