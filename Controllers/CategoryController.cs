using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShopDbContext _shopDbContext;
        public CategoryController(IProductRepository productRepository, ShopDbContext shopDbContext)
        {
            _productRepository = productRepository;
            _shopDbContext = shopDbContext;
        }

        public IActionResult ProductList(string category)
        {
            
            return View();
        }
    }
}
