using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAPI.Data;
using BookAPI.Models;
using BookAPI.DTO;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly BookDbContext _context;

        public PurchaseController(BookDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetPurchases()
        {
            var purchases = await _context.Purchases
                .Include(p => p.Book)
                .Include(p => p.Electronic)
                .Select(p => new PurchaseDTO
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    BookID = p.BookID,
                    ElectronicID = p.ElectronicID,
                    Email = p.Email,
                    PurchaseNumber = p.PurchaseNumber,
                    PurchaseDate = p.PurchaseDate
                })
                .ToListAsync();

            return Ok(purchases);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDTO>> GetPurchase(int id)
        {
            var purchase = await _context.Purchases
                .Include(p => p.Book)
                .Include(p => p.Electronic)
                .Where(p => p.PurchaseNumber == id)
                .Select(p => new PurchaseDTO
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    BookID = p.BookID,
                    ElectronicID = p.ElectronicID,
                    Email = p.Email,
                    PurchaseNumber = p.PurchaseNumber,
                    PurchaseDate = p.PurchaseDate
                })
                .FirstOrDefaultAsync();

            if (purchase == null)
            {
                return NotFound();
            }

            return Ok(purchase);
        }

        [HttpPost]
        public async Task<ActionResult<Purchase>> CreatePurchase(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPurchase), new { id = purchase.PurchaseNumber }, purchase);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchase(int id, Purchase purchase)
        {
            if (id != purchase.PurchaseNumber)
            {
                return BadRequest();
            }

            _context.Entry(purchase).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
