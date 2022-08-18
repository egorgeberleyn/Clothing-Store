namespace ClothingStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductRepository _productRepository;
        public SearchController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task<IActionResult> Index(string name)
        {
            var products = await _productRepository.GetProductsByNameAsync(name);
            if(products == null || products.Count == 0)
                return NotFound();
            return View(products);
        }
    }
}
