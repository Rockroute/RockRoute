using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RockRoute.Models;

namespace RockRouteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimbsDBController : ControllerBase
    {
        private readonly ClimbsDB _context;

        public ClimbsDBController(ClimbsDB context)
        {
            _context = context;
        }

        // GET: api/ClimbsDB
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Climb>>> GetEntries()
        {
            return await _context.Entries.ToListAsync();
        }

        // GET: api/ClimbsDB/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Climb>> GetClimb(string id)
        {
            var climb = await _context.Entries.FindAsync(id);

            if (climb == null)
            {
                return NotFound();
            }

            return climb;
        }

        // PUT: api/ClimbsDB/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClimb(string id, Climb climb)
        {
            if (id != climb.RouteId)
            {
                return BadRequest();
            }

            _context.Entry(climb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClimbExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClimbsDB
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Climb>> PostClimb(Climb climb)
        {
            _context.Entries.Add(climb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClimbExists(climb.RouteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClimb", new { id = climb.RouteId }, climb);
        }

        // DELETE: api/ClimbsDB/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClimb(string id)
        {
            var climb = await _context.Entries.FindAsync(id);
            if (climb == null)
            {
                return NotFound();
            }

            _context.Entries.Remove(climb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClimbExists(string id)
        {
            return _context.Entries.Any(e => e.RouteId == id);
        }
    }
}
