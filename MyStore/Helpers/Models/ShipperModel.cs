using System.ComponentModel.DataAnnotations;

namespace MyStore.Helpers.Models
{
    public class ShipperModel
    {

        public int Shipperid { get; set; }

        [Required]
        public string Companyname { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }

}
