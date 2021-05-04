using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using real_estate_market.Core;
using real_estate_market.Core.Models;
using real_estate_market.Extensions;

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

            return await context.RealEstates.Include(r => r.Cladding).Include(r => r.Photos).SingleOrDefaultAsync(r => r.Id == id);
        }
        public void Add(RealEstate realEstate)
        {
            context.RealEstates.Add(realEstate);
        }
        public void Remove(RealEstate realEstate)
        {
            context.RealEstates.Remove(realEstate);
        }

        public async Task<QueryResult<RealEstate>> GetRealEstates(RealEstateQuery queryObj, bool includeRelated = true)
        {
            var result = new QueryResult<RealEstate>();
            var query = context.RealEstates
                .Include(r => r.Cladding)
                .AsQueryable();

            if (queryObj.CladdingId.HasValue)
                query = query.Where(r => r.Cladding.Id == queryObj.CladdingId.Value);

            var columnsMap = new Dictionary<string, Expression<Func<RealEstate, object>>>()
            {
                ["address"] = v => v.Address,
                ["area"] = v => v.Area,
                ["level"] = v => v.Level
            };

            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }
    }
}