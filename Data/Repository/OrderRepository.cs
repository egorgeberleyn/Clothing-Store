namespace ClothingStore.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDbContext shopDbContext;

        public IQueryable<Order> Orders
        {
            get => shopDbContext.Orders
                                .Include(o => o.Items)
                                .ThenInclude(i => i.Product);
        }
                                   
        public OrderRepository(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        public async Task<List<Order>> GetAllOrdersAsync() =>
            await shopDbContext.Orders.ToListAsync();

        public async Task<Order> GetOrderByIdAsync(int id) =>
            await shopDbContext.Orders.FindAsync(new object[] { id });
        
        public async Task CreateOrderAsync(Order order)
        {
            order.OrderDate = DateTime.Now;              
            shopDbContext.AttachRange(order.Items.Select(i => i.Product));                        
            if (order.Id == 0)
                await shopDbContext.Orders.AddAsync(order);
            await SaveAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var orderFromDb = await shopDbContext.Orders.FindAsync(new object[] { orderId });
            shopDbContext.Orders.Remove(orderFromDb);
        }

        public async Task SaveAsync() =>
            await shopDbContext.SaveChangesAsync();
    }
}
