namespace ClothingStore.ViewModels
{
    public class SearchListViewModel
    {
        public List<Product> SearchProducts{ get; set; }
        public PageInfo PageInfo { get; set; }
        public string SearchKey { get; set; }
    }
}
