using System.Collections.Generic;
using System.Threading.Tasks;
using real_estate_market.Core.Models;

namespace real_estate_market.Core
{
    public interface IRealEstateRepository
    {
        Task<RealEstate> GetRealEstate(int id, bool includeRelated = true);
        Task<IEnumerable<RealEstate>> GetRealEstates(bool includeRelated = true);
        void Add(RealEstate realEstate);
        void Remove(RealEstate realEstate);
    }
}