namespace ClothingStore.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShopCartId { get; set; }
        public ShopCart ShopCart { get; set; }
        public Product Product { get; set; }

    }
}
