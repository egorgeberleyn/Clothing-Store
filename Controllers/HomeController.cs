namespace ClothingStore.Controllers
{
    public class HomeController : Controller
    {                
        private readonly IProductRepository _productRepository;
        
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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

        public IActionResult ContactUs() => View();
    }
}