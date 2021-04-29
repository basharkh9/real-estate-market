using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using real_estate_market.Models;
using real_estate_market.Persistence;

namespace real_estate_market.Controllers
{
    public class CladdingsController : Controller
    {
        private readonly RealEstateDbContext context;
        public CladdingsController(RealEstateDbContext context)
        {
            this.context = context;
        }
        [HttpGet("/api/claddings")]
        public async Task<IEnumerable<Cladding>> GetCladdings()
        {
            return await context.Claddings.Include(r => r.RealEstates).ToListAsync();
        }
    }
}