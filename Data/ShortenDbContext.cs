using Microsoft.EntityFrameworkCore;
using shortit.models;

namespace shortit.Data 
{
    public class ShortenDbContext : DbContext
    {
        public ShortenDbContext(DbContextOptions<ShortenDbContext> options) : base (options)
        {
            
        }
        public DbSet<OriginalUrl> originalUrls {get; set;}
    }
}