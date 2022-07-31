namespace ClothingStore.Data.Interfaces
{
    public interface IOrderRepository : IDisposable
    {
        Task<List<Order>> GetAllOrdersAsync();
        //Task<Order> GetOrderAsync(int number); do it
        Task<Order> GetOrderByIdAsync(int id);

        Task CreateOrder(Order order);
        Task DeleteOrder(int orderId);
        Task SaveAsync();
    }
}
