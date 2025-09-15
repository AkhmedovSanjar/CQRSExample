using Microsoft.EntityFrameworkCore;

namespace CQRSExample
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Update connection string as needed
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CQRSExampleDb;Trusted_Connection=True;");
        }
    }
}
