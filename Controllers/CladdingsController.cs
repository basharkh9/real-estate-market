using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using real_estate_market.Controllers.Resources;
using real_estate_market.Core.Models;
using real_estate_market.Persistence;

namespace real_estate_market.Controllers
{
    [Route("/api/claddings")]
    public class CladdingsController : Controller
    {
        private readonly RealEstateDbContext context;
        private readonly IMapper mapper;
        public CladdingsController(RealEstateDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<CladdingResource>> GetCladdings()
        {
            var claddings = await context.Claddings.Include(r => r.RealEstates).ToListAsync();
            return mapper.Map<List<Cladding>, List<CladdingResource>>(claddings);
        }
    }
}