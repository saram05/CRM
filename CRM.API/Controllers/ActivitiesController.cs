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

        //public ActivitiesController(DataContext context)
        //{
        //    _context = context;
        //}

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult> Get(int id)
        //{
        //    var activity = await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);
        //    if (activity is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(activity);
        //}

        //[HttpPut]
        //public async Task<ActionResult> Put(Activity activity)
        //{
        //    try
        //    {
        //        _context.Update(activity);
        //        await _context.SaveChangesAsync();
        //        return Ok(activity);
        //    }
        //    catch (DbUpdateException dbUpdateException)
        //    {
        //        return BadRequest(dbUpdateException.Message);
        //    }
        //    catch (Exception exception)
        //    {
        //        return BadRequest(exception.Message);
        //    }
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var afectedRows = await _context.Activities
        //        .Where(x => x.Id == id)
        //        .ExecuteDeleteAsync();

        //    if (afectedRows == 0)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        //[HttpGet]
        //public async Task<ActionResult> Get()
        //{
        //    return Ok(await _context.Oportunities
        //        .Include(x => x.Activities)
        //        .ToListAsync());
        //}

        //[HttpPost]
        //public async Task<ActionResult> Post(Activity activity)
        //{
        //    _context.Add(activity);
        //    await _context.SaveChangesAsync();
        //    return Ok(activity);
        //}
    }
}
