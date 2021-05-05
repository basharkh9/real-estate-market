using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace real_estate_market.Controllers.Resources
{
    public class SaveRealEstateResource
    {
        public int Id { get; set; }
        public int CladdingId { get; set; }
        public float Area { get; set; }
        public bool isBooked { get; set; }
        public int Level { get; set; }
        public int NumberOfRooms { get; set; }
        public string Address { get; set; }
        public ICollection<PhotoResource> Photos { get; set; }
        public float Price { get; set; }

        public SaveRealEstateResource()
        {
            Photos = new Collection<PhotoResource>();
        }
    }
}