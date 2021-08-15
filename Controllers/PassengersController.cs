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
    public class PassengersController : ControllerBase
    {
        private readonly AirlineManagementContext _context;

        public PassengersController(AirlineManagementContext context)
        {
            _context = context;
            //_context.ChangeTracker.LazyLoadingEnabled = false;
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        // GET: api/Passengers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassenger()
        {
            return await _context.Passenger.ToListAsync();
        }

        // GET: api/Passengers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passenger>> GetPassenger(string id)
        {
            var passenger = await _context.Passenger.FindAsync(id);

            if (passenger == null)
            {
                return NotFound();
            }

            return passenger;
        }

        // PUT: api/Passengers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassenger(string id,string seat,Passenger passenger)
        {
            if (id != passenger.TicketNo)
            {
                return BadRequest();
            }

            _context.Entry(passenger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerExists(id,seat))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Passengers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Passenger>> PostPassenger(Passenger passenger)
        {
            _context.Passenger.Add(passenger);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PassengerExists(passenger.TicketNo,passenger.Seatno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPassenger", new { id = passenger.TicketNo }, passenger);
        }

        // DELETE: api/Passengers/5
        [HttpDelete("{id}/{seatno}")]
        public async Task<ActionResult<Passenger>> DeletePassenger(string id,string seatno)
        {
            var passenger = await _context.Passenger.Where(e => e.TicketNo == id && e.Seatno == seatno).FirstAsync();
            if (passenger == null)
            {
                return NotFound();
            }

            _context.Passenger.Remove(passenger);
            if (seatno.StartsWith("E"))
            {
                _context.TicketDetails.Where(tick => tick.TicketNo == id).Select(e => e.SeatsBookedE - 1);
            }
            else if(seatno.StartsWith("B"))
            {
                _context.TicketDetails.Where(tick => tick.TicketNo == id).Select(e => e.SeatsBookedB - 1);
            }
            await _context.SaveChangesAsync();

            return passenger;
        }
        //UPDATED FOR COMPOSITE KEY
        private bool PassengerExists(string id,string seat)
        {
            return _context.Passenger.Any(e=>(e.TicketNo+e.Seatno).Equals(id+seat));
        }
    }
}
