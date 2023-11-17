using CRM.API.Data;
using CRM.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/oportunities")]
    public class OportunitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public OportunitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Oportunities.ToListAsync());
        }
        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.Oportunities.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var product = await _context.Oportunities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Oportunity oportunity)
        {
            try
            {
                Oportunity newOportunity = new()
                {
                    Name = oportunity.Name,
                    CreatedDate = oportunity.CreatedDate,
                    FinishDate = oportunity.FinishDate,
                    Value = oportunity.Value,
                    ClientId = oportunity.ClientId,
                };


                _context.Add(newOportunity);
                await _context.SaveChangesAsync();
                return Ok(oportunity);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una oportunidad con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Oportunity oportunity)
        {
            try
            {
                _context.Update(oportunity);
                await _context.SaveChangesAsync();
                return Ok(oportunity);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una oportunidad con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var oportunity = await _context.Oportunities.FirstOrDefaultAsync(x => x.Id == id);
            if (oportunity == null)
            {
                return NotFound();
            }

            _context.Remove(oportunity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
