using System.Collections.Generic;
using System.Threading.Tasks;
using real_estate_market.Core.Models;

namespace real_estate_market.Core
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetPhotos(int realEstateId);
    }
}