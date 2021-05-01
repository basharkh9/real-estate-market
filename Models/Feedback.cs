using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace real_estate_market.Models
{
    [Table("Feedbacks")]
    public class Feedback
    {
        public int Id { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public float Rate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}