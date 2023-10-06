using System.ComponentModel.DataAnnotations;

namespace MyStore.Helpers.Models
{
    public class CustomerModel
    {

        public int Custid { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Companyname { get; set; } = null!;

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Contactname { get; set; } = null!;

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Contacttitle { get; set; } = null!;

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Address { get; set; } = null!;

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string City { get; set; } = null!;

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Region { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Postalcode { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Country { get; set; } = null!;


        [Required]
        [Phone]
        public string Phone { get; set; } = null!;

        public string? Fax { get; set; }
    
    }
}
