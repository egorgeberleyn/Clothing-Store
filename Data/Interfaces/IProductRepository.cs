namespace ClothingStore.Data.Interfaces
{
    public interface IProductRepository : IDisposable
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetProductAsync(string name);
        Task<Product> GetProductAsync(int id);
        Task CreateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(Product product);
        Task SaveAsync();
    }
}
