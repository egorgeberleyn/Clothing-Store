namespace ClothingStore.Data.Repository
{
    public class ShopCartRepository : IShopCartRepository
    {        
        private readonly ShopCart shopCart = new();
        private readonly ShopDbContext shopDbContext;
        public ShopCartRepository(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;                         
        }             
        public ShopCart GetShopCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //var context = services.GetService<ShopDbContext>();
            byte[] shopCartId = session.Get("CartId") ?? Guid.NewGuid().ToByteArray();

            session.Set("CartId", shopCartId);
            shopCart.Id = BitConverter.ToInt32(shopCartId, 0);
            return shopCart;
        }

        public List<ShopCartItem> GetShopCartItems() => shopCart.ShopCartItems;

        public decimal CheckCartPrice() =>                   
           shopCart.ShopCartItems != null
           ? shopCart.ShopCartItems.Select(x => x.Product.Price).Sum()
           : 0;
        
        public void AddItem(Product item)
        {
            shopCart.ShopCartItems.Add(new ShopCartItem
            {
                Product = item,
                ShopCartId = shopCart.Id
            });
        }

        public void DeleteItem(int id)
        {
            var item = shopCart.ShopCartItems.FirstOrDefault(p => p.Id == id);
            shopCart.ShopCartItems.Remove(item);
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    shopDbContext.Dispose();
            _disposed = true;
        }

        public async Task SaveAsync() => 
            await shopDbContext.SaveChangesAsync();
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }               
    }
}
