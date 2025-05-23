using System;
using System.Collections.Generic; //to use List
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
    public class LogBookDBController : ControllerBase
    {
        private readonly LogBooksDB _context;

        public LogBookDBController(LogBooksDB context)
        {
            _context = context;
        }

        // GET: api/LogBookDB
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogBook>>> GetLogBook()
        {
            return await _context.LogBook.ToListAsync();
        }

        // GET: api/LogBookDB/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogBook>> GetLogBook(string id)
        {
            var logBook = await _context.LogBook.FindAsync(id);

            if (logBook == null)
            {
                return NotFound();
            }

            return logBook;
        }

        // PUT: api/LogBookDB/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogBook(string id, [FromBody] LogBook updatedLogBook)
        {
            if (id != updatedLogBook.UserId)
            {
                return BadRequest();
            }

            var existingLogBook = await _context.LogBook.FindAsync(id);

            if (existingLogBook == null)
            {
                return NotFound();
            }

            existingLogBook.Playlist = updatedLogBook.Playlist;
            existingLogBook.Route = updatedLogBook.Route;
            existingLogBook.Activity = updatedLogBook.Activity;
            existingLogBook.RouteId = updatedLogBook.RouteId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogBookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingLogBook);
        }


        // POST: api/LogBookDB
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogBook>> PostLogBook([FromBody] LogBook logBook)
        {
            _context.LogBook.Add(logBook);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LogBookExists(logBook.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLogBook", new { id = logBook.UserId }, logBook);
        }

        // DELETE: api/LogBookDB/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogBook(string id)
        {
            var logBook = await _context.LogBook.FindAsync(id);
            if (logBook == null)
            {
                return NotFound();
            }

            _context.LogBook.Remove(logBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogBookExists(string id)
        {
            return _context.LogBook.Any(e => e.UserId == id);
        }
    }
}