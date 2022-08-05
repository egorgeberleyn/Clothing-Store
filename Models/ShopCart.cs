namespace ClothingStore.Models
{
    public class ShopCart
    {
        public int Id { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; } = new List<ShopCartItem>();
                      
        public decimal ComputeCartPrice() =>
           ShopCartItems != null
           ? ShopCartItems.Sum(item => item.Quantity * item.Product.Price)
           : 0;

        public void AddItem(Product item, int quantity)
        {
            var shopItem = ShopCartItems.Where(p => p.Product.Id == item.Id)
                                        .FirstOrDefault();
            if(shopItem is null)
                ShopCartItems.Add(new ShopCartItem
                {
                    Product = item,
                    ShopCartId = Id,
                    Quantity = quantity
                });
            else
                shopItem.Quantity += quantity;
        }

        public void DeleteItem(int id) =>         
            ShopCartItems.RemoveAll(p => p.Id == id);        
    }
}
