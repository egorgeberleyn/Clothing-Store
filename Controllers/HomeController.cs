namespace ClothingStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository productRepository;
        private readonly IShopCartRepository shopCartRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {            
            var favoriteProducts = new HomeViewModel() 
            { 
                FavoriteProducts = productRepository.GetFavoriteProductsAsync()
            };
            
            ViewBag.CartPrice = shopCartRepository.GetShopCartItems().Select(x => x.Product.Price).Sum();
            return View(favoriteProducts);
        }               
    }
}