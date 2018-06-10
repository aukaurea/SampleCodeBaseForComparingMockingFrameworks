using System.Data.Entity;

namespace SampleCodeBase.JustMockExamples
{
    public class NerdDinners : DbContext
    {
        public DbSet<Dinner> Dinners { get; set; }
        public DbSet<RSVP> RSVPs { get; set; }
    }
}