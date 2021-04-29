using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace real_estate_market.Models
{
    public class Cladding
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public ICollection<RealEstate> RealEstates { get; set; }
        public Cladding()
        {
            RealEstates = new Collection<RealEstate>();
        }
    }
}