namespace ClothingStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShopCart _shopCart;
        public OrderController(IOrderRepository orderRepository, ShopCart shopCart)
        {
            _orderRepository = orderRepository;
            _shopCart = shopCart;
        }

        [Authorize]
        public async Task<IActionResult> OrderList()
        {
            var orders = await _orderRepository.Orders.Where(о => !о.Shipped).ToListAsync();
            return View(orders);
        }
            
        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderId)
        {
            Order order = _orderRepository.Orders.FirstOrDefault(o => o.Id == orderId);

            if (order != null)
            {
                order.Shipped = true;
                _orderRepository.SaveAsync();                                    
            }
            return RedirectToAction("OrderList");
        }

        [HttpGet]
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
                order.Items = _shopCart.ShopCartItems;
                await _orderRepository.CreateOrderAsync(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            _shopCart.Clear();
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
