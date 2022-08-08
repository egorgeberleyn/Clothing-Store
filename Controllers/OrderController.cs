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
            ViewBag.CartPrice = _shopCart.ComputeCartPrice();
            return View();
        }
            
        [HttpPost]
        public IActionResult Checkout(Order order)
        {            
            if (ModelState.IsValid)
            {                
                _orderRepository.CreateOrder(order);                
                return RedirectToAction("Complete");
            }
            
            ViewBag.CartPrice = _shopCart.ComputeCartPrice();
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Order is complete";
            ViewBag.CartPrice = _shopCart.ComputeCartPrice();
            return View();
        }

        public IActionResult Error()
        {
            ViewBag.Message = "Shopping cart is empty";
            ViewBag.CartPrice = _shopCart.ComputeCartPrice();
            return View();
        }
    }
}
