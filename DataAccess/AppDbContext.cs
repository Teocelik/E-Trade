using E_Trade.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Trade.DataAccess
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
