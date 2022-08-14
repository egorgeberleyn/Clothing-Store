namespace ClothingStore.Models
{
    public class ShopCart
    {
        public int Id { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; } = new List<ShopCartItem>();
                      
        public virtual decimal ComputeCartPrice() =>
           ShopCartItems != null
           ? ShopCartItems.Sum(item => item.Quantity * item.Product.Price)
           : 0;

        public virtual void AddItem(Product item, int quantity)
        {
            var shopItem = ShopCartItems.Where(p => p.Product.Id == item.Id)
                                        .FirstOrDefault();
            if(shopItem is null)
                ShopCartItems.Add(new ShopCartItem
                {
                    Product = item,
                    Quantity = quantity
                });
            else
                shopItem.Quantity += quantity;
        }

        public virtual void DeleteItem(int id)
        {
            var shopItem = ShopCartItems.Where(p => p.Product.Id == id)
                                        .FirstOrDefault();
            if (shopItem != null)
                ShopCartItems.Remove(shopItem);
        }
        
        public virtual void Clear() => ShopCartItems.Clear();
    }
}
