namespace ClothingStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFavorite { get; set; }
        public decimal Price { get; set; } = 0;
        public string Available { get; set; } //наличие товара
        public string Description { get; set; }

        public Category Category { get; set; }
    }
}
