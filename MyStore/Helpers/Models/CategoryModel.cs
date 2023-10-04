using System.ComponentModel.DataAnnotations;

namespace MyStore.Helpers.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Trebuie sa fie o valoare data!")]
        [MaxLength(20)]
        public string Description { get; set; }
    }
}
