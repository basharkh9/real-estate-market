using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using real_estate_market.Controllers.Resources;
using real_estate_market.Models;
using real_estate_market.Persistence;

namespace real_estate_market.Controllers
{
    [Route("/api/realestates")]
    public class RealEstatesController : Controller
    {
        private readonly IMapper mapper;
        private readonly RealEstateDbContext context;
        public RealEstatesController(RealEstateDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }
        [HttpPost]
        public async Task<IActionResult> CreateRealEstate([FromBody] RealEstateResource realEstateResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var realEstate = mapper.Map<RealEstateResource, RealEstate>(realEstateResource);

            context.RealEstates.Add(realEstate);
            await context.SaveChangesAsync();

            var result = mapper.Map<RealEstate, RealEstateResource>(realEstate);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRealEstate(int id, [FromBody] RealEstateResource realEstateResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var realEstate = await context.RealEstates.FindAsync(id);

            if (realEstate == null)
                return NotFound();

            mapper.Map<RealEstateResource, RealEstate>(realEstateResource, realEstate);

            await context.SaveChangesAsync();

            var result = mapper.Map<RealEstate, RealEstateResource>(realEstate);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealEstate(int id)
        {
            var realEstate = await context.RealEstates.FindAsync(id);

            if (realEstate == null)
                return NotFound();

            context.Remove(realEstate);
            await context.SaveChangesAsync();

            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRealEstate(int id)
        {
            var realEstate = await context.RealEstates.Include(r => r.Cladding).SingleOrDefaultAsync(r => r.Id == id);

            if (realEstate == null)
                return NotFound();

            var realEstateResource = mapper.Map<RealEstate, RealEstateResource>(realEstate);

            return Ok(realEstateResource);
        }
    }
}