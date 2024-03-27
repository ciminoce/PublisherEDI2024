using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PublisherEDI2024.Domain;

namespace PublisherEDI2024.Data
{
    public class PublisherDbContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.; Initial Catalog=PublisherEDI;
                    Trusted_Connection=true; TrustServerCertificate=True;")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }
    }
}
