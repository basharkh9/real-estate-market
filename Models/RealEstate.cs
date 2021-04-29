using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace real_estate_market.Models
{
    [Table("RealEstates")]
    public class RealEstate
    {
        public int Id { get; set; }
        public float Area { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        public Cladding Cladding { get; set; }
        public int CladdingId { get; set; }
        public float Price { get; set; }
    }
}