using CRM.API.Data;
using CRM.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("/api/oportunities")]
    public class OportunitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public OportunitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var oportunity = await _context.Oportunities.FirstOrDefaultAsync(x => x.Id == id);
            if (oportunity is null)
            {
                return NotFound();
            }

            return Ok(oportunity);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Oportunity oportunity)
        {
            try
            {
                _context.Update(oportunity);
                await _context.SaveChangesAsync();
                return Ok(oportunity);
            }
            catch (DbUpdateException dbUpdateException)
            {
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Oportunities
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Oportunities
                .Include(x => x.Activities)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Oportunity oportunity)
        {
            _context.Add(oportunity);
            await _context.SaveChangesAsync();
            return Ok(oportunity);
        }
    }
}
