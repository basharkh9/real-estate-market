using System.ComponentModel.DataAnnotations;

namespace real_estate_market.Core.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        public int RealEstateId { get; set; }
    }
}