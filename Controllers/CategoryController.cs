using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
               
        public CategoryController(IProductRepository productRepository, 
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;            
            _categoryRepository = categoryRepository;
        }

        [Route("Category/ProductList")]
        [Route("Category/ProductList/{category}")]
        public async Task<IActionResult> ProductList(string category)
        {
            List<Product> allProducts;            
            Category currentCategory = _categoryRepository.GetCategoryByName(category);
            if (string.IsNullOrEmpty(category))
            {
                allProducts = await _productRepository.GetAllProductsAsync();
                currentCategory = new Category { Name = "All Products"};
            }
            else            
                allProducts = await _productRepository
                    .GetProductsByCategoryAsync(currentCategory);
                                                                   
            var model = new ProductListViewModel
            {
                ProductsByCategory = allProducts,
                CurrentCategory = currentCategory,
            };

            
            ViewBag.CartPrice = GetCart().ComputeCartPrice();
            return View(model);            
        }
        
        public ShopCart GetCart()
        {
            ShopCart cart = HttpContext.Session.GetJson<ShopCart>("Cart")
                ?? new ShopCart();
            return cart;
        }
    }
}
