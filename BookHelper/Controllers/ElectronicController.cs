using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAPI.Data;
using BookAPI.Models;
using BookAPI.DTO;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronicController : ControllerBase
    {
        private readonly BookDbContext _context;

        public ElectronicController(BookDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectronicDTO>>> GetElectronics()
        {
            var electronics = await _context.Electronics
                .Select(e => new ElectronicDTO
                {
                    ElectronicID = e.ElectronicID,
                    Name = e.Name,
                    Stock = e.Stock
                })
                .ToListAsync();

            return Ok(electronics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ElectronicDTO>> GetElectronic(int id)
        {
            var electronic = await _context.Electronics
                .Where(e => e.ElectronicID == id)
                .Select(e => new ElectronicDTO
                {
                    ElectronicID = e.ElectronicID,
                    Name = e.Name,
                    Stock = e.Stock
                })
                .FirstOrDefaultAsync();

            if (electronic == null)
            {
                return NotFound();
            }

            return Ok(electronic);
        }

        [HttpPost]
        public async Task<ActionResult<Electronic>> CreateElectronic(Electronic electronic)
        {
            _context.Electronics.Add(electronic);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetElectronic), new { id = electronic.ElectronicID }, electronic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateElectronic(int id, Electronic electronic)
        {
            if (id != electronic.ElectronicID)
            {
                return BadRequest();
            }

            _context.Entry(electronic).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElectronic(int id)
        {
            var electronic = await _context.Electronics.FindAsync(id);
            if (electronic == null)
            {
                return NotFound();
            }

            _context.Electronics.Remove(electronic);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
