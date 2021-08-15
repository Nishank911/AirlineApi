using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirlineManagementAPI.Models;

namespace AirlineManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketDetailsController : ControllerBase
    {
        private readonly AirlineManagementContext _context;

        public TicketDetailsController(AirlineManagementContext context)
        {
            _context = context;
        }

        // GET: api/TicketDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDetails>>> GetTicketDetails()
        {
            return await _context.TicketDetails.ToListAsync();
        }

        // GET: api/TicketDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDetails>> GetTicketDetails(string id)
        {
            var ticketDetails = await _context.TicketDetails.FindAsync(id);

            if (ticketDetails == null)
            {
                return NotFound();
            }

            return ticketDetails;
        }

        // PUT: api/TicketDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketDetails(string id, TicketDetails ticketDetails)
        {
            if (id != ticketDetails.TicketNo)
            {
                return BadRequest();
            }

            _context.Entry(ticketDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketDetailsExists(id))
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

        // POST: api/TicketDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TicketDetails>> PostTicketDetails(TicketDetails ticketDetails)
        {
            _context.TicketDetails.Add(ticketDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TicketDetailsExists(ticketDetails.TicketNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTicketDetails", new { id = ticketDetails.TicketNo }, ticketDetails);
        }

        // DELETE: api/TicketDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketDetails>> DeleteTicketDetails(string id)
        {
            var ticketDetails = await _context.TicketDetails.FindAsync(id);
            if (ticketDetails == null)
            {
                return NotFound();
            }

            _context.TicketDetails.Remove(ticketDetails);
            await _context.SaveChangesAsync();

            return ticketDetails;
        }


    

        private bool TicketDetailsExists(string id)
        {
            return _context.TicketDetails.Any(e => e.TicketNo == id);
        }
    }
}
