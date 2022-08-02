namespace ClothingStore.ViewModels
{
    public class ProductListViewModel
    {
        public Category CurrentCategory { get; set; }
        public List<Product> ProductsByCategory { get; set; }
    }
}
