namespace ClothingStore.Data.Interfaces
{
    public interface IShopCartRepository : IDisposable
    {
        ShopCart GetShopCart(IServiceProvider service);
        void AddItem(Product item);
        void DeleteItem(int id);
        Task SaveAsync();
    }
}
