using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ShopDbContext _shopDbContext;
        public CategoryController(IProductRepository productRepository, 
            ShopDbContext shopDbContext, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _shopDbContext = shopDbContext;
            _categoryRepository = categoryRepository;
        }

        [Route("Category/ProductList")]
        [Route("Category/ProductList/{category}")]
        public IActionResult ProductList(string category)
        {
            var allProducts = new List<Product>();            
            Category currentCategory = _categoryRepository.GetCategoryByName(category);
            if (string.IsNullOrEmpty(category))
            {
                allProducts = _productRepository.GetAllProducts();
                currentCategory = new Category { Name = "All Products"};
            }
            else
            {                
                allProducts = _productRepository.GetAllProducts()
                    .Where(i => string.Equals(i.Category.Id, currentCategory.Id))
                    .Select(x => x)
                    .ToList();                                    
            }

            var model = new ProductListViewModel
            {
                ProductsByCategory = allProducts,
                CurrentCategory = currentCategory,
            };

            ViewBag.Title = "EShop";                                            
            return View(model);
        }
    }
}
