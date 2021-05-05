using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace real_estate_market.Core.Models
{
    [Table("Feedbacks")]
    public class Feedback
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Rate { get; set; }
    }
}