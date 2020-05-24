using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacation.Models;

namespace Vacation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeInHotelsController : ControllerBase
    {
        private readonly VacationDBContext _context;

        public RoomTypeInHotelsController(VacationDBContext context)
        {
            _context = context;
        }

        // GET: api/RoomTypeInHotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTypeInHotel>>> GetRoomTypeInHotels()
        {
            return await _context.RoomTypeInHotels.ToListAsync();
        }

        // GET: api/RoomTypeInHotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomTypeInHotel>> GetRoomTypeInHotel(int id)
        {
            var roomTypeInHotel = await _context.RoomTypeInHotels.FindAsync(id);

            if (roomTypeInHotel == null)
            {
                return NotFound();
            }

            return roomTypeInHotel;
        }

        // PUT: api/RoomTypeInHotels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomTypeInHotel(int id, RoomTypeInHotel roomTypeInHotel)
        {
            if (id != roomTypeInHotel.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomTypeInHotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTypeInHotelExists(id))
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

        // POST: api/RoomTypeInHotels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RoomTypeInHotel>> PostRoomTypeInHotel(RoomTypeInHotel roomTypeInHotel)
        {
            _context.RoomTypeInHotels.Add(roomTypeInHotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomTypeInHotel", new { id = roomTypeInHotel.Id }, roomTypeInHotel);
        }

        // DELETE: api/RoomTypeInHotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomTypeInHotel>> DeleteRoomTypeInHotel(int id)
        {
            var roomTypeInHotel = await _context.RoomTypeInHotels.FindAsync(id);
            if (roomTypeInHotel == null)
            {
                return NotFound();
            }

            _context.RoomTypeInHotels.Remove(roomTypeInHotel);
            await _context.SaveChangesAsync();

            return roomTypeInHotel;
        }

        private bool RoomTypeInHotelExists(int id)
        {
            return _context.RoomTypeInHotels.Any(e => e.Id == id);
        }
    }
}
