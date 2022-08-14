namespace ClothingStore.Components
{
    public class CartTotalPriceViewComponent : ViewComponent
    {
        private readonly ShopCart _shopCart;
        public CartTotalPriceViewComponent(ShopCart shopCart) => _shopCart = shopCart;
        public IViewComponentResult Invoke() => View(_shopCart);
    }
}
