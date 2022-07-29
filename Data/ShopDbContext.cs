namespace ClothingStore.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Product> Products;
        public DbSet<Order> Orders;
        public DbSet<Category> Categories;
        public DbSet<ShopCartItem> ShopCartItems;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //build relations between models
            base.OnModelCreating(modelBuilder);
        }
    }
}
