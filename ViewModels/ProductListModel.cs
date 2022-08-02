namespace ClothingStore.ViewModels
{
    public class ProductListModel
    {
        public Category CurrentCategory { get; set; }
        public List<Product> ProductsByCategory { get; set; }
    }
}
