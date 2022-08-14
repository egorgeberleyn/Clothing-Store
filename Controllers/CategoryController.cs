namespace ClothingStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ShopCart _shopCart;
        public int PageSize = 3;
                       
        public CategoryController(IProductRepository productRepository, 
            ICategoryRepository categoryRepository, ShopCart shopCart)
        {
            _productRepository = productRepository;            
            _categoryRepository = categoryRepository;
            _shopCart = shopCart;
        }

        [Route("Category/ProductList/{category}/{page?}")]
        public async Task<IActionResult> ProductList(string category, int page = 1)
        {
            Category currentCategory = await _categoryRepository
                    .GetCategoryByNameAsync(category);
            List<Product> products = await _productRepository
                    .GetProductsOnPageAsync(currentCategory, page, PageSize); ;

            var model = new ProductListViewModel
            {
                ProductsByCategory = products,
                CurrentCategory = currentCategory,
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _productRepository.GetProductsByCategoryAsync(currentCategory)
                                                   .Result.Count
                }
            };                                                       
            return View(model);            
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {            
            return View();    
        }

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

        public IActionResult Complete()
        {
            ViewBag.Message = "Product is created";            
            return View();
        }
    }
}
