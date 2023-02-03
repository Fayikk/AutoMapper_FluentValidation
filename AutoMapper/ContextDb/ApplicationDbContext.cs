using AutoMapper_FluentValidation.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoMapper_FluentValidation.ContextDb
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set; }

    }
}
