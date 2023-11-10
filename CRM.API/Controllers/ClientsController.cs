﻿using CRM.API.Data;
using CRM.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("/api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client is null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Client client)
        {
            _context.Update(client);
            await _context.SaveChangesAsync();
            return Ok(client);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Clients
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
            return Ok(await _context.Clients.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return Ok(client);
        }
    }

}
