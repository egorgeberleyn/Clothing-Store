namespace ClothingStore.Data.Repository
{
    public class ShopCartRepository : IShopCartRepository
    {        
        private readonly ShopCart shopCart;
        private readonly ShopDbContext shopDbContext;
        public ShopCartRepository(ShopDbContext shopDbContext, ShopCart shopCart)
        {
            this.shopDbContext = shopDbContext;
            this.shopCart = shopCart;
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
