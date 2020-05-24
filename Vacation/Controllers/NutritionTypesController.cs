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
    public class NutritionTypesController : ControllerBase
    {
        private readonly VacationDBContext _context;

        public NutritionTypesController(VacationDBContext context)
        {
            _context = context;
        }

        // GET: api/NutritionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NutritionType>>> GetNutritionTypes()
        {
            return await _context.NutritionTypes.ToListAsync();
        }

        // GET: api/NutritionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NutritionType>> GetNutritionType(int id)
        {
            var nutritionType = await _context.NutritionTypes.FindAsync(id);

            if (nutritionType == null)
            {
                return NotFound();
            }

            return nutritionType;
        }

        // PUT: api/NutritionTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNutritionType(int id, NutritionType nutritionType)
        {
            if (id != nutritionType.Id)
            {
                return BadRequest();
            }

            _context.Entry(nutritionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutritionTypeExists(id))
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

        // POST: api/NutritionTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NutritionType>> PostNutritionType(NutritionType nutritionType)
        {
            _context.NutritionTypes.Add(nutritionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNutritionType", new { id = nutritionType.Id }, nutritionType);
        }

        // DELETE: api/NutritionTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NutritionType>> DeleteNutritionType(int id)
        {
            var nutritionType = await _context.NutritionTypes.FindAsync(id);
            if (nutritionType == null)
            {
                return NotFound();
            }

            _context.NutritionTypes.Remove(nutritionType);
            await _context.SaveChangesAsync();

            return nutritionType;
        }

        private bool NutritionTypeExists(int id)
        {
            return _context.NutritionTypes.Any(e => e.Id == id);
        }
    }
}
