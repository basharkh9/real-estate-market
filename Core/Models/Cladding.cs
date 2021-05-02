using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace real_estate_market.Core.Models
{
    [Table("Claddings")]
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