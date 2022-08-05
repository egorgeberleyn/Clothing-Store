namespace ClothingStore.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ShopCartController(IProductRepository productRepository) =>
            _productRepository = productRepository;


        public IActionResult Cart()
        {            
            var cart = new ShopCartViewModel
            {
                ShopCart = GetCart()
            };
            ViewBag.CartPrice = cart.ShopCart.ComputeCartPrice();
            return View(cart);
        }

        public async Task<RedirectToActionResult> AddToCart(int id)
        {
            var item = await _productRepository.GetProductAsync(id);
            if (item != null)
            {
                ShopCart cart = GetCart();
                cart.AddItem(item, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Cart");
        }

        public IActionResult DeleteFromCart(int id)
        {
            ShopCart cart = GetCart();
            cart.DeleteItem(id);
            SaveCart(cart);
            return RedirectToAction("Cart");
        }


        public ShopCart GetCart()
        {
            ShopCart cart = HttpContext.Session.GetJson<ShopCart>("Cart")
                ?? new ShopCart();
            return cart;
        }
        public void SaveCart(ShopCart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
