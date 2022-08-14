namespace ClothingStore.Controllers
{
    public class HomeController : Controller
    {                
        private readonly IProductRepository _productRepository;
        private readonly ShopCart _shopCart;

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
            return View(favoriteProducts);
        }        
    }
}