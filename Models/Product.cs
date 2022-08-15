namespace ClothingStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }
        
        public string ImageUrl { get; set; }
        
        public bool IsFavorite { get; set; }
        
        [Required(ErrorMessage = "Please enter product's price")]
        [Range(0.01, double.MaxValue,ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; } = 0;
        
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number or null")]
        public int Available { get; set; } = 0; //наличие товара
        
        public string Description { get; set; }

        public Category Category { get; set; }
    }
}
