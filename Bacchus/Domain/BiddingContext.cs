using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class BiddingContext : DbContext
    {
        public BiddingContext(DbContextOptions<BiddingContext> options)
            : base(options)
        {
            
        }
        public DbSet<Bidding> Biddings { get; set; }
        
    }
}