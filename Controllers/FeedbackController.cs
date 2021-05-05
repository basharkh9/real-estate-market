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
    [Route("/api/feedbacks")]
    public class FeedbackController : Controller
    {
        private readonly RealEstateDbContext context;
        private readonly IMapper mapper;
        public FeedbackController(RealEstateDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<FeedbackResource>> GetFeedbacks()
        {
            var feedbacks = await context.Feedbacks.ToListAsync();
            return mapper.Map<List<Feedback>, List<FeedbackResource>>(feedbacks);
        }

        public async Task<IActionResult> CreateRealEstate([FromBody] FeedbackResource feedbackResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var feedback = mapper.Map<FeedbackResource, Feedback>(feedbackResource);

            await this.context.Feedbacks.AddAsync(feedback);
            await this.context.SaveChangesAsync();

            var result = mapper.Map<Feedback, FeedbackResource>(feedback);

            return Ok(result);
        }
    }
}