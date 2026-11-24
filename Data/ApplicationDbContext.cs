using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ordella_deliverable2.Models;
namespace Ordella_deliverable2.Data;
public class ApplicationDbContext : IdentityDbContext
{
 public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
 public DbSet<Shop> Shops => Set<Shop>(); public DbSet<Product> Products => Set<Product>();
 public DbSet<CustomerOrder> Orders => Set<CustomerOrder>(); public DbSet<OrderItem> OrderItems => Set<OrderItem>();
 protected override void OnModelCreating(ModelBuilder builder){base.OnModelCreating(builder);builder.Entity<Shop>().HasIndex(x=>x.Slug).IsUnique();builder.Entity<Product>().Property(x=>x.Price).HasPrecision(18,2);builder.Entity<CustomerOrder>().Property(x=>x.Total).HasPrecision(18,2);builder.Entity<OrderItem>().Property(x=>x.UnitPrice).HasPrecision(18,2);}
}
