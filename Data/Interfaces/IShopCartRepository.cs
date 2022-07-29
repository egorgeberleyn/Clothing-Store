namespace ClothingStore.Data.Interfaces
{
    public interface IShopCartRepository
    {
        ShopCart GetAsync(IServiceProvider service);
        void AddItemAsync(Product item);
        void DeleteItemAsync(int id);
    }
}
