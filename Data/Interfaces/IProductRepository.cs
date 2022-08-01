﻿namespace ClothingStore.Data.Interfaces
{
    public interface IProductRepository : IDisposable
    {
        Task<List<Product>> GetAllProductsAsync(Category category);
        List<Product> GetFavoriteProducts();
        Task<List<Product>> GetProductsByNameAsync(string name);
        Task<Product> GetProductAsync(int id);
        Task CreateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(Product product);
        Task SaveAsync();
    }
}
