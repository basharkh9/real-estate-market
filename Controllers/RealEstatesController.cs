using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using real_estate_market.Controllers.Resources;
using real_estate_market.Core;
using real_estate_market.Core.Models;

namespace real_estate_market.Controllers
{
    [Route("/api/realestates")]
    public class RealEstatesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IRealEstateRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public RealEstatesController(IMapper mapper, IRealEstateRepository realEstateRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = realEstateRepository;
            this.mapper = mapper;

        }
        [HttpPost]
        public async Task<IActionResult> CreateRealEstate([FromBody] SaveRealEstateResource realEstateResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var realEstate = mapper.Map<SaveRealEstateResource, RealEstate>(realEstateResource);

            repository.Add(realEstate);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<RealEstate, RealEstateResource>(realEstate);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRealEstate(int id, [FromBody] SaveRealEstateResource realEstateResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var realEstate = await repository.GetRealEstate(id);

            if (realEstate == null)
                return NotFound();

            mapper.Map<SaveRealEstateResource, RealEstate>(realEstateResource, realEstate);

            await unitOfWork.CompleteAsync();

            realEstate = await repository.GetRealEstate(realEstate.Id);
            var result = mapper.Map<RealEstate, RealEstateResource>(realEstate);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealEstate(int id)
        {
            var realEstate = await repository.GetRealEstate(id, false);

            if (realEstate == null)
                return NotFound();

            repository.Remove(realEstate);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRealEstate(int id)
        {
            var realEstate = await repository.GetRealEstate(id);

            if (realEstate == null)
                return NotFound();

            var realEstateResource = mapper.Map<RealEstate, RealEstateResource>(realEstate);

            return Ok(realEstateResource);
        }
        [HttpGet]
        public async Task<IEnumerable<RealEstateResource>> GetRealEstates()
        {
            var realEstates = await repository.GetRealEstates();

            return mapper.Map<IEnumerable<RealEstate>, IEnumerable<RealEstateResource>>(realEstates);

        }
    }
}