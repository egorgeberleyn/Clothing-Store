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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            //инициализация бд начальными значениями

            var womanStore = new Category { Id = 1, Name = "Woman Store", Description = "товары для женщин" };
            var accesories = new Category { Id = 2, Name = "Accesories", Description = "аксессуары" };
            var manStore = new Category { Id = 3, Name = "Man Store", Description = "товары для мужчин" };
            var shoes = new Category { Id = 4, Name = "Shoes", Description = "обувь" };
            var sale = new Category { Id = 5, Name = "Sale", Description = "распродажа" };
            var vintage = new Category { Id = 6, Name = "Vintage", Description = "винтажные вещи" };

            modelBuilder.Entity<Category>()
                .HasData(womanStore, accesories, manStore, shoes, sale, vintage);

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1, CategoryId = manStore.Id, Name = "VANS T-SHIRT", ImageUrl = "/img/branded/vans_tshirt.png", Price = 30, IsFavorite = true },
                new Product { Id = 2, CategoryId = manStore.Id, Name = "RUBY SWEATER", ImageUrl = "/img/branded/sweater.png", Price = 65, IsFavorite = true },
                new Product { Id = 3, CategoryId = manStore.Id, Name = "MEN'S COAT", ImageUrl = "/img/branded/coat.png", Price = 140, IsFavorite = true },
                new Product { Id = 4, CategoryId = accesories.Id, Name = "WOMAN BAG", ImageUrl = "/img/branded/women_bag.png", Price = 550, IsFavorite = true },
                new Product { Id = 5, CategoryId = womanStore.Id, Name = "BLUE DRESS", ImageUrl = "/img/branded/dress.png", Price = 78, IsFavorite = true },
                new Product { Id = 6, CategoryId = shoes.Id, Name = "HEALED SHOES", ImageUrl = "/img/branded/healed shoes.png", Price = 260, IsFavorite = true },

                new Product { Id = 7, CategoryId = sale.Id, Name = "NIKE T-SHIRT", ImageUrl = "/img/nike-tshirt.png", Price = 14, IsSlide = true },
                new Product { Id = 8, CategoryId = sale.Id, Name = "GUCCI T-SHIRT", ImageUrl = "/img/gucci-tshirt.png", Price = 25, IsSlide = true },


                new Product { Id = 9, CategoryId = shoes.Id, Name = "MEN SHOES", ImageUrl = "/img/shoes.png", Price = 225},
                new Product { Id = 10, CategoryId = manStore.Id, Name = "JEANS", ImageUrl = "/img/jeans.png", Price = 53},
                new Product { Id = 11, CategoryId = manStore.Id, Name = "SHIRT", ImageUrl = "/img/dress_shirt.png", Price = 44},
                new Product { Id = 12, CategoryId = shoes.Id, Name = "CONVERSE", ImageUrl = "/img/converse.png", Price = 37},
                new Product { Id = 13, CategoryId = manStore.Id, Name = "HOODIE", ImageUrl = "/img/hoodie2.png", Price = 105},
                new Product { Id = 14, CategoryId = manStore.Id, Name = "LEVI'S T-SHIRT", ImageUrl = "/img/t-shirt.png", Price = 28}
                );       
        }
    }
}
