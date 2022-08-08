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
            await shopDbContext.Categories.FindAsync(new object[] { id });

        public async Task<Category> GetCategoryByNameAsync(string name) => await shopDbContext.Categories.FirstOrDefaultAsync(c => c.Name.Equals(name));

        public async Task CreateCategoryAsync(Category category)
        {
            await shopDbContext.Categories.AddAsync(category);
            await SaveAsync();
        }
        
        public async Task DeleteCategoryAsync(int id)
        {
            var categoryFromDb = await shopDbContext.Categories.FindAsync(new object[] {id});
            if (categoryFromDb is null) return;
            shopDbContext.Categories.Remove(categoryFromDb);
            await SaveAsync();
        }
                    
        public async Task UpdateCategoryAsync(Category category)
        {
            var categoryFromDb = await shopDbContext.Categories.FindAsync(new object[] { category.Id });
            if (categoryFromDb is null) return;
            categoryFromDb.Name = category.Name;
            categoryFromDb.Description = category.Description;
            await SaveAsync();
        }

        public async Task SaveAsync() => 
            await shopDbContext.SaveChangesAsync();       
    }
}
