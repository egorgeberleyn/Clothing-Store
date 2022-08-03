namespace ClothingStore.Controllers
{
    public class HomeController : Controller
    {        
        private readonly ShopDbContext _shopDbContext;
        private readonly IProductRepository _productRepository;
        private readonly IShopCartRepository _shopCartRepository;
        

        public HomeController(ShopDbContext shopDbContext, IProductRepository productRepository, 
            IShopCartRepository shopCartRepository)
        {           
            _shopDbContext = shopDbContext;
            _productRepository = productRepository;
            _shopCartRepository = shopCartRepository;
        }

        public async Task<IActionResult> Index()
        {            
            var favoriteProducts = new HomeViewModel() 
            { 
                FavoriteProducts = await _productRepository.GetFavoriteProductsAsync()
            };
                                  
            ViewBag.CartPrice = _shopCartRepository.CheckCartPrice();
            return View(favoriteProducts);
        }               
    }
}