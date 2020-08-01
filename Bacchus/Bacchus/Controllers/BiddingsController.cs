using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bacchus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiddingsController : ControllerBase
    {
        private readonly BiddingContext _context;

        public BiddingsController(BiddingContext context)
        {
            _context = context;
        }

        // GET: api/Biddings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bidding>>> GetBiddings()
        {
            return await _context.Biddings.ToListAsync();
        }

        // GET: api/Biddings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bidding>> GetBidding(long id)
        {
            var bidding = await _context.Biddings.FindAsync(id);

            if (bidding == null)
            {
                return NotFound();
            }

            return bidding;
        }

        // PUT: api/Biddings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBidding(long id, Bidding bidding)
        {
            if (id != bidding.Id)
            {
                return BadRequest();
            }

            _context.Entry(bidding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiddingExists(id))
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

        // POST: api/Biddings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bidding>> PostBidding(Bidding bidding)
        {
            _context.Biddings.Add(bidding);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBidding", new { id = bidding.Id }, bidding);
        }

        // DELETE: api/Biddings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bidding>> DeleteBidding(long id)
        {
            var bidding = await _context.Biddings.FindAsync(id);
            if (bidding == null)
            {
                return NotFound();
            }

            _context.Biddings.Remove(bidding);
            await _context.SaveChangesAsync();

            return bidding;
        }

        private bool BiddingExists(long id)
        {
            return _context.Biddings.Any(e => e.Id == id);
        }
    }
}
