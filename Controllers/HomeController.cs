namespace ClothingStore.Controllers
{
    public class HomeController : Controller
    {                
        private readonly IProductRepository _productRepository;
        private ShopCart _shopCart;

        public HomeController(IProductRepository productRepository, ShopCart shopCart)
        {                       
            _productRepository = productRepository;
            _shopCart = shopCart;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {            
            var favoriteProducts = new HomeViewModel() 
            { 
                FavoriteProducts = await _productRepository.GetFavoriteProductsAsync()
            };
                                  
            
            ViewBag.CartPrice = _shopCart.ComputeCartPrice();
            return View(favoriteProducts);
        }        
    }
}