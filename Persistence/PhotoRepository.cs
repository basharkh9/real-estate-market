using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using real_estate_market.Core;
using real_estate_market.Core.Models;

namespace real_estate_market.Persistence
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly RealEstateDbContext context;
        public PhotoRepository(RealEstateDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Photo>> GetPhotos(int realEstateId)
        {
            return await context.Photos
              .Where(p => p.RealEstateId == realEstateId)
              .ToListAsync();
        }
    }
}