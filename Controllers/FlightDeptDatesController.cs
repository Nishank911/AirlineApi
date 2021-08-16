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
    public class FlightDeptDatesController : ControllerBase
    {
        private readonly AirlineManagementContext _context;

        public FlightDeptDatesController(AirlineManagementContext context)
        {
            _context = context;
        }

        // GET: api/FlightDeptDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDeptDate>>> GetFlightDeptDate()
        {
            return await _context.FlightDeptDate.ToListAsync();
        }

        // GET: api/FlightDeptDates/5
        [HttpGet("{id},{date}")]
        public async Task<ActionResult<FlightDeptDate>> GetFlightDeptDate(string id,string date)
        {
            var flightDeptDate = await _context.FlightDeptDate.FindAsync(id,date);

            if (flightDeptDate == null)
            {
                return NotFound();
            }

            return flightDeptDate;
        }

        // PUT: api/FlightDeptDates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightDeptDate(string id, FlightDeptDate flightDeptDate)
        {
            if (id != flightDeptDate.FlightNo)
            {
                return BadRequest();
            }

            _context.Entry(flightDeptDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightDeptDateExists(id))
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

        // POST: api/FlightDeptDates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FlightDeptDate>> PostFlightDeptDate(FlightDeptDate flightDeptDate)
        {
            _context.FlightDeptDate.Add(flightDeptDate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlightDeptDateExists(flightDeptDate.FlightNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlightDeptDate", new { id = flightDeptDate.FlightNo }, flightDeptDate);
        }

        // DELETE: api/FlightDeptDates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FlightDeptDate>> DeleteFlightDeptDate(string id)
        {
            var flightDeptDate = await _context.FlightDeptDate.FindAsync(id);
            if (flightDeptDate == null)
            {
                return NotFound();
            }

            _context.FlightDeptDate.Remove(flightDeptDate);
            await _context.SaveChangesAsync();

            return flightDeptDate;
        }

        private bool FlightDeptDateExists(string id)
        {
            return _context.FlightDeptDate.Any(e => e.FlightNo == id);
        }
    }
}
