using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        

        [Display(Name = "Enter name")]
        [StringLength(20)]
        [Required(ErrorMessage = "Name must match the format")]
        public string CustomerName { get; set; }

                
        [Display(Name = "Surname")]
        [StringLength(20)]
        [Required(ErrorMessage = "Surname must match the format")] 
        public string CustomerSurname { get; set; }


        [Display(Name = "Adress")]
        [StringLength(70)]
        [Required(ErrorMessage = "Adress must match the format")]
        public string Adress { get; set; }

        
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(13)]        
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(40)]
        [Required(ErrorMessage = "Email adress must match the format")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }       
        
        public List<Product> Products { get; set; }
    }
}
