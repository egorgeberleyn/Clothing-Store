namespace ClothingStore.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDbContext shopDbContext;
        private readonly ShopCart shopCart;
        public OrderRepository(ShopDbContext shopDbContext, ShopCart shopCart)
        {
            this.shopDbContext = shopDbContext;  
            this.shopCart = shopCart;
        }

        public async Task<List<Order>> GetAllOrdersAsync() =>
            await shopDbContext.Orders.ToListAsync();
             
        public async Task<Order> GetOrderByIdAsync(int id) =>
            await shopDbContext.Orders.FindAsync(new object[] { id });

        public async Task CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;           
            order.Products = shopCart.ShopCartItems;  
            await shopDbContext.Orders.AddAsync(order);
            await SaveAsync();
        }

        public async Task DeleteOrder(int orderId)
        {
            var orderFromDb = await shopDbContext.Orders.FindAsync(new object[] {orderId});
            shopDbContext.Orders.Remove(orderFromDb);
        }


        public async Task SaveAsync() =>
            await shopDbContext.SaveChangesAsync();    
        

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    shopDbContext.Dispose();
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
