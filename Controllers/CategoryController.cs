namespace ClothingStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        
        public int PageSize = 4;
                       
        public CategoryController(IProductRepository productRepository, 
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;            
            _categoryRepository = categoryRepository;           
        }
        
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
    }
}
