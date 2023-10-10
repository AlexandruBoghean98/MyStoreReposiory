using System.ComponentModel.DataAnnotations;

namespace MyStore.Helpers.Models
{
    public class EmployeeModel
    {

        public int Empid { get; set; }

        [Required]
        public string Lastname { get; set; } = null!;

        [Required]
        public string Firstname { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Titleofcourtesy { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Hiredate { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string City { get; set; } = null!;

        [StringLength(50)]
        public string? Region { get; set; }

        [DataType(DataType.PostalCode)]
        public string? Postalcode { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; } = null!;

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = null!;

        public int? Mgrid { get; set; }
    }
}
