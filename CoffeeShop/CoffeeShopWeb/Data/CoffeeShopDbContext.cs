using CoffeeShopWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopWeb.Data
{
    public class CoffeeShopDbContext : DbContext
    {
        public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options) : base(options)
        { 
        }
        public DbSet<Cafe> Cafes { get; set; }
    }
}
