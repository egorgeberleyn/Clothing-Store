namespace ClothingStore.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext shopDbContext;
        public ProductRepository(ShopDbContext context)
        {
            shopDbContext = context;
        }

        public async Task CreateProductAsync(Product product) =>
            await shopDbContext.Products.AddAsync(product);

        public async Task UpdateProductAsync(Product product)
        {
            var productFromDb = await shopDbContext.Products.FindAsync(new object[] { product.Id });           
            if (productFromDb is null) return;
            
            productFromDb.Name = product.Name;
            productFromDb.Description = product.Description;
            productFromDb.Price = product.Price;            
        }

        public async Task DeleteProductAsync(int id)
        {
            var productFromDb = await shopDbContext.Products.FindAsync(new object[] { id });
            if (productFromDb is null) return;
            shopDbContext.Remove(productFromDb);
        }

        public async Task<List<Product>> GetAllProductsAsync(Category category) =>
            await shopDbContext.Products.Include(p => p.Category).ToListAsync();
                 
        public async Task<List<Product>> GetProductAsync(string name) =>
            await shopDbContext.Products.Where(p => p.Name.Contains(name)).ToListAsync();

        public async Task<Product> GetProductAsync(int id) =>
            await shopDbContext.Products.FindAsync(new object[] { id });

        public async Task SaveAsync() => await shopDbContext.SaveChangesAsync();

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    shopDbContext.Dispose();
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
