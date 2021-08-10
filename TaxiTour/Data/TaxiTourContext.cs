using Microsoft.EntityFrameworkCore;

namespace TaxiTour.Data
{
    public class TaxiTourContext : DbContext
    {
        public TaxiTourContext (DbContextOptions<TaxiTourContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Taxi> Taxi { get; set; }

        public DbSet<Models.BookedTaxis> BookedTaxis { get; set; }

        public DbSet<Models.ContactUs> ContactUs { get; set; }
    }
}
