using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController(AppDbContext _context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var activities = await _context.Activities.ToListAsync();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetails(String id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null) return NotFound();
            return Ok(activity);
        }
    }
}
