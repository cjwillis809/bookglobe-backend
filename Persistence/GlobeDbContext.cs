using Microsoft.EntityFrameworkCore;
using bookglobe_backend.Models;

namespace bookglobe_backend.Persistence
{
    public class GlobeDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public GlobeDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}