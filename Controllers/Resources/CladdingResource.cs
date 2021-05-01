using System.Collections.Generic;
using System.Collections.ObjectModel;
using real_estate_market.Models;

namespace real_estate_market.Controllers.Resources
{
    public class CladdingResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RealEstateResource> RealEstates { get; set; }
        public CladdingResource()
        {
            RealEstates = new Collection<RealEstateResource>();
        }
    }
}