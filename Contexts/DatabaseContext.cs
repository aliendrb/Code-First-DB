using Code_First.Models;
using Microsoft.EntityFrameworkCore;

namespace Code_First.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Categories> Categories {  get; set; }

    public DbSet<Products> Products { get; set; }

    public DbSet<Roles> Roles { get; set; }

    public DbSet<Accounts> Accounts { get; set; }

    public DbSet<Shopping_Carts> Shopping_Carts { get; set; }

    public DbSet<Products_Categories> Products_Categories { get; set; }

    protected DatabaseContext() 
    {

    }

    public DatabaseContext(DbContextOptions options) : base(options) 
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categories>().HasData(new List<Categories>
        {
            new Categories
            {
                CategoryID = 1,
                Name = "Garden",
            }
        });

        modelBuilder.Entity<Products>().HasData(new List<Products> 
        {
            new Products 
            { 
                ProductID = 1, 
                Depth = 3, 
                Height = 15, 
                Weight = 1.2m, 
                Width = 2.3m, 
                Name = "Mini fork" 
            }
        });

        modelBuilder.Entity<Products_Categories>().HasData(new List<Products_Categories>
        {
            new Products_Categories
            {
                ProductId = 1,
                CategoryId = 1,
            }
        });

        modelBuilder.Entity<Products_Categories>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });

        modelBuilder.Entity<Shopping_Carts>()
            .HasKey(sc => new { sc.AccountId, sc.ProductId });

        modelBuilder.Entity<Products_Categories>()
            .HasOne(pc => pc.Products)
            .WithMany(p => p.Products_Categories)
            .HasForeignKey(pc => pc.ProductId);

        modelBuilder.Entity<Products_Categories>()
            .HasOne(pc => pc.Categories)
            .WithMany(c => c.Products_Categories)
            .HasForeignKey(pc => pc.CategoryId);

        modelBuilder.Entity<Shopping_Carts>()
            .HasOne(sc => sc.Products)
            .WithMany(p => p.Shopping_Carts)
            .HasForeignKey(sc => sc.ProductId);

        modelBuilder.Entity<Shopping_Carts>()
            .HasOne(sc => sc.Accounts)
            .WithMany(a => a.Shopping_Carts)
            .HasForeignKey(sc => sc.AccountId);
    }
}