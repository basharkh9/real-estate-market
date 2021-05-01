using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace real_estate_market.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Booking> Bookings { get; set; }

        public User()
        {
            Feedbacks = new Collection<Feedback>();
            Bookings = new Collection<Booking>();
        }

    }
}