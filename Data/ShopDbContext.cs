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
            modelBuilder.Entity<Category>() //инициализация бд начальными значениями
                .HasData(
                        new Category { Name = "Woman Store", Description = "товары для женщин" },
                        new Category { Name = "Accesories", Description = "аксессуары" },
                        new Category { Name = "Man Store", Description = "товары для мужчин" },
                        new Category { Name = "Shoes", Description = "обувь" },
                        new Category { Name = "Sale", Description = "распродажа" },
                        new Category { Name = "Vintage", Description = "винтажные вещи" }
                );
        }
    }
}
