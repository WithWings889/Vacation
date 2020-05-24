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
    public class NutritionTypeInHotelsController : ControllerBase
    {
        private readonly VacationDBContext _context;

        public NutritionTypeInHotelsController(VacationDBContext context)
        {
            _context = context;
        }

        // GET: api/NutritionTypeInHotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NutritionTypeInHotel>>> GetNutritionTypeInHotels()
        {
            return await _context.NutritionTypeInHotels.ToListAsync();
        }

        // GET: api/NutritionTypeInHotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NutritionTypeInHotel>> GetNutritionTypeInHotel(int id)
        {
            var nutritionTypeInHotel = await _context.NutritionTypeInHotels.FindAsync(id);

            if (nutritionTypeInHotel == null)
            {
                return NotFound();
            }

            return nutritionTypeInHotel;
        }

        // PUT: api/NutritionTypeInHotels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNutritionTypeInHotel(int id, NutritionTypeInHotel nutritionTypeInHotel)
        {
            if (id != nutritionTypeInHotel.Id)
            {
                return BadRequest();
            }

            _context.Entry(nutritionTypeInHotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutritionTypeInHotelExists(id))
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

        // POST: api/NutritionTypeInHotels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NutritionTypeInHotel>> PostNutritionTypeInHotel(NutritionTypeInHotel nutritionTypeInHotel)
        {
            _context.NutritionTypeInHotels.Add(nutritionTypeInHotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNutritionTypeInHotel", new { id = nutritionTypeInHotel.Id }, nutritionTypeInHotel);
        }

        // DELETE: api/NutritionTypeInHotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NutritionTypeInHotel>> DeleteNutritionTypeInHotel(int id)
        {
            var nutritionTypeInHotel = await _context.NutritionTypeInHotels.FindAsync(id);
            if (nutritionTypeInHotel == null)
            {
                return NotFound();
            }

            _context.NutritionTypeInHotels.Remove(nutritionTypeInHotel);
            await _context.SaveChangesAsync();

            return nutritionTypeInHotel;
        }

        private bool NutritionTypeInHotelExists(int id)
        {
            return _context.NutritionTypeInHotels.Any(e => e.Id == id);
        }
    }
}
