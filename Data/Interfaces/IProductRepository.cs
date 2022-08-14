namespace ClothingStore.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByCategoryAsync(Category category);
        Task<List<Product>> GetProductsOnPageAsync(Category category, int page, int pageSize);
        Task<List<Product>> GetFavoriteProductsAsync();
        Task<List<Product>> GetProductsByNameAsync(string name);
        Task<Product> GetProductAsync(int id);
        Task CreateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(Product product);
        Task SaveAsync();
    }
}
