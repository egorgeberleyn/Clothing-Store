namespace ClothingStore.Data.Repository
{
    public class ShopCartRepository : IShopCartRepository
    {        
        private readonly ShopCart shopCart;
       
        public void AddItemAsync(Product item)
        {
            shopCart.ShopCartItems.Add(new ShopCartItem
            {
                Product = item,
                ShopCartId = shopCart.Id
            });
        }

        public void DeleteItemAsync(int id)
        {
            var item = shopCart.ShopCartItems.FirstOrDefault(p => p.Id == id);
            shopCart.ShopCartItems.Remove(item);
        }

        public ShopCart GetAsync(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ShopDbContext>();
            byte[] shopCartId = session.Get("CartId") ?? Guid.NewGuid().ToByteArray();

            session.Set("CartId", shopCartId);
            shopCart.Id = BitConverter.ToInt32(shopCartId, 0);
            return shopCart;
        }
    }
}
