using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Webbanhang.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public
       ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}