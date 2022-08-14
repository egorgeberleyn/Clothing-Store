namespace ClothingStore.Models
{
    public class ShopCartItem
    {        
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }        
    }
}
