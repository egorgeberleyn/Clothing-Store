namespace ClothingStore.Controllers
{
    public class HomeController : Controller
    {                
        private readonly IProductRepository _productRepository;        

        public HomeController(IProductRepository productRepository)
        {                       
            _productRepository = productRepository;            
        }

        public async Task<IActionResult> Index()
        {            
            var favoriteProducts = new HomeViewModel() 
            { 
                FavoriteProducts = await _productRepository.GetFavoriteProductsAsync()
            };
                                  
            
            ViewBag.CartPrice = GetCart().ComputeCartPrice();
            return View(favoriteProducts);
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