namespace ClothingStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
