using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using real_estate_market.Core;
using real_estate_market.Core.Models;

namespace real_estate_market.Persistence
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private readonly RealEstateDbContext context;
        public RealEstateRepository(RealEstateDbContext context)
        {
            this.context = context;
        }
        public async Task<RealEstate> GetRealEstate(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.RealEstates.FindAsync(id);

            return await context.RealEstates.Include(r => r.Cladding).SingleOrDefaultAsync(r => r.Id == id);
        }
        public async Task<IEnumerable<RealEstate>> GetRealEstates(bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.RealEstates.ToListAsync();

            return await context.RealEstates.Include(r => r.Cladding).ToListAsync();
        }
        public void Add(RealEstate realEstate)
        {
            context.RealEstates.Add(realEstate);
        }
        public void Remove(RealEstate realEstate)
        {
            context.RealEstates.Remove(realEstate);
        }
    }
}