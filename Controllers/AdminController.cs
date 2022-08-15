namespace ClothingStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AdminController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllProductsAsync();
            foreach (var product in products)
            {
                var category = await _categoryRepository.GetCategoryAsync(product.CategoryId);
                product.Category = category;
            }
            return View(products);
        }

        [HttpGet]
        public IActionResult CreateProduct() => PartialView();
        

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Category = await _categoryRepository.GetCategoryByNameAsync(product.Category.Name);
                await _productRepository.CreateProductAsync(product);
                return RedirectToAction("Complete");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int productId)
        {
            var product = await _productRepository.GetProductAsync(productId);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                await _productRepository.UpdateProductAsync(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Product is created";
            return View();
        }
    }
}
