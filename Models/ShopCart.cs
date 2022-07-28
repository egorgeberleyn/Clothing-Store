namespace ClothingStore.Models
{
    public class ShopCart
    {
        public int Id { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; }
    }
}
