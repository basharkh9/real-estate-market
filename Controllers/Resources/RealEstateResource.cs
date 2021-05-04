using System.Collections.Generic;
using System.Collections.ObjectModel;
using real_estate_market.Core.Models;

namespace real_estate_market.Controllers.Resources
{
    public class RealEstateResource
    {
        public int Id { get; set; }
        public float Area { get; set; }
        public int Level { get; set; }
        public int NumberOfRooms { get; set; }
        public string Address { get; set; }
        public CladdingResource Cladding { get; set; }
        public ICollection<PhotoResource> Photos { get; set; }
        public float Price { get; set; }
        public RealEstateResource()
        {
            Photos = new Collection<PhotoResource>();
        }
    }
}