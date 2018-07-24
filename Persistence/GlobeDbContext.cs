using Microsoft.EntityFrameworkCore;
using bookglobe_backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace bookglobe_backend.Persistence
{
    public class GlobeDbContext : IdentityDbContext<BookAdmin>
    {
        public DbSet<Book> Books { get; set; }

        public GlobeDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}