namespace ClothingStore.Data.Interfaces
{
    public interface IShopCartRepository : IDisposable
    {
        ShopCart GetShopCart(IServiceProvider service);
        List<ShopCartItem> GetShopCartItems();
        void AddItem(Product item);
        void DeleteItem(int id);
        Task SaveAsync();
    }
}
