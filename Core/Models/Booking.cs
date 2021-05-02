using System.ComponentModel.DataAnnotations.Schema;

namespace real_estate_market.Core.Models
{
    [Table("Bookings")]
    public class Booking
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public RealEstate RealEstate { get; set; }
        public int RealEstateId { get; set; }
    }
}