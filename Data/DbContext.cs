using Microsoft.EntityFrameworkCore;
using BuriPosApi.Models;

namespace BuriPosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}