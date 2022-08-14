namespace ClothingStore.Controllers
{
    public class OrderController:Controller
    {
        private readonly IOrderRepository _orderRepository;
        private ShopCart _shopCart;
        public OrderController(IOrderRepository orderRepository, ShopCart shopCart)
        {
            _orderRepository = orderRepository;
            _shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            if (_shopCart.ShopCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Shop cart is empty");                
                return RedirectToAction("Error");
            }            
            return View();
        }
            
        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {            
            if (ModelState.IsValid)
            {                
                await _orderRepository.CreateOrderAsync(order);                
                return RedirectToAction("Complete");
            }                       
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Order is complete";            
            return View();
        }

        public IActionResult Error()
        {
            ViewBag.Message = "Shopping cart is empty";            
            return View();
        }
    }
}
