using Microsoft.EntityFrameworkCore;
using ClothingStore.Models;
namespace ClothingStore.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var womanStore = new Category { Id = 1, Name = "Woman Store", Description = "товары для женщин" };
            var accesories = new Category { Id = 2, Name = "Accesories", Description = "аксессуары" };
            var manStore = new Category { Id = 3, Name = "Man Store", Description = "товары для мужчин" };
            var shoes = new Category { Id = 4, Name = "Shoes", Description = "обувь" };
            var sale = new Category { Id = 5, Name = "Sale", Description = "распродажа" };
            var vintage = new Category { Id = 6, Name = "Vintage", Description = "винтажные вещи" };

            modelBuilder.Entity<Category>() //инициализация бд начальными значениями
                .HasData(womanStore, accesories, manStore, shoes, sale, vintage);

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1, CategoryId = manStore.Id, Name = "VANS T-SHIRT", ImageUrl = "/img/branded/vans_tshirt.png", Price = 30, IsFavorite = true },
                new Product { Id = 2, CategoryId = manStore.Id, Name = "RUBY SWEATER", ImageUrl = "/img/branded/sweater.png", Price = 65, IsFavorite = true},
                new Product { Id = 3, CategoryId = manStore.Id, Name = "MEN'S COAT", ImageUrl = "/img/branded/coat.png", Price = 140, IsFavorite = true}
                );
        }

        public DbSet<ClothingStore.Models.ShopCart> ShopCart { get; set; }
    }
}
