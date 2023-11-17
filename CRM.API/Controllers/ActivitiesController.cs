using CRM.API.Data;
using CRM.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("/api/activities")]
    public class ActivitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Activities.ToListAsync());
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var activity = await _context.Activities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Activity activity)
        {
            try
            {
                Activity newActivity = new()
                {
                    Name = activity.Name,
                    StartDate = activity.StartDate,
                    FinishDate = activity.FinishDate,
                    Observations = activity.Observations,
                    OportunityId = activity.OportunityId,
                    Type = activity.Type
                };


                _context.Add(newActivity);
                await _context.SaveChangesAsync();
                return Ok(activity);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Activity activity)
        {
            try
            {
                _context.Update(activity);
                await _context.SaveChangesAsync();
                return Ok(activity);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            _context.Remove(activity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
