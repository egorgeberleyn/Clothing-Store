namespace ClothingStore.Models
{
    public class ShopCart
    {
        public int Id { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; }

        public ShopCart GetShopCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;  
            byte[] shopCartId = session.Get("CartId") ?? Guid.NewGuid().ToByteArray();

            session.Set("CartId", shopCartId);
            Id = BitConverter.ToInt32(shopCartId, 0);
            return this;
        }
    }
}
