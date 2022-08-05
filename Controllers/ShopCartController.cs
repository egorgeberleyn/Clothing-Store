namespace ClothingStore.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IProductRepository productRepository, ShopCart shopCart)
        {
            _productRepository = productRepository;
            _shopCart = shopCart;
        }   


        public IActionResult Cart()
        {            
            var cart = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };
            ViewBag.CartPrice = cart.ShopCart.ComputeCartPrice();
            return View(cart);
        }

        public async Task<RedirectToActionResult> AddToCart(int id)
        {
            var item = await _productRepository.GetProductAsync(id);
            if (item != null)                            
                _shopCart.AddItem(item, 1);                
            
            return RedirectToAction("Cart");
        }

        public RedirectToActionResult DeleteFromCart(int id)
        {            
            _shopCart.DeleteItem(id);                       
            return RedirectToAction("Cart");
        }        
    }
}
