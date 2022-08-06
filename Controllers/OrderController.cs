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
                return RedirectToAction("Complete");
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
            if(ModelState.MaxAllowedErrors > 0)
                ViewBag.Message = "Order is not complete";
            else
                ViewBag.Message = "Order is complete";
            ViewBag.CartPrice = _shopCart.ComputeCartPrice();
            return View();
        }
    }
}
