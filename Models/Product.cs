namespace ClothingStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFavorite { get; set; }
        [Required]
        public decimal Price { get; set; } = 0;
        public int Available { get; set; } = 0; //наличие товара
        public string Description { get; set; }

        public Category Category { get; set; }
    }
}
