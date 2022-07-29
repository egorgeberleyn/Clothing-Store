namespace ClothingStore.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext shopDbContext;
        public CategoryRepository(ShopDbContext context)
        {
            shopDbContext = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync() =>        
            await shopDbContext.Categories.ToListAsync();        

        public async Task<Category> GetCategoryAsync(int id) => 
            await shopDbContext.Categories.FindAsync(new object[] {id});
        
        public async Task CreateCategoryAsync(Category category) =>        
            await shopDbContext.Categories.AddAsync(category);
        
        public async Task DeleteCategoryAsync(int id)
        {
            var categoryFromDb = await shopDbContext.Categories.FindAsync(new object[] {id});
            if (categoryFromDb is null) return;
            shopDbContext.Categories.Remove(categoryFromDb);
        }
                    
        public async Task UpdateCategoryAsync(Category category)
        {
            var categoryFromDb = await shopDbContext.Categories.FindAsync(new object[] { category.Id });
            if (categoryFromDb is null) return;
            categoryFromDb.Name = category.Name;
            categoryFromDb.Description = category.Description;
        }

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
