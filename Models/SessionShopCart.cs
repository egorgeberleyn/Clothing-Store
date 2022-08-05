using Newtonsoft.Json;

namespace ClothingStore.Models
{
    public class SessionShopCart : ShopCart
    {
        [JsonIgnore]
        public ISession Session { get; set; }
        
        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionShopCart cart = session?.GetJson<SessionShopCart>("Cart")
            ?? new SessionShopCart();
            cart.Session = session;
            return cart;
        }        

        public override void AddItem(Product item, int quantity)
        {
            base.AddItem(item, quantity);
            Session.SetJson("Cart", this);
        }

        public override void DeleteItem(int id)
        {
            base.DeleteItem(id);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
