using Microsoft.EntityFrameworkCore;
using Ivanchenko.Model;

namespace Ivanchenko.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<IssueBook> IssueBooks { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Ivanchenko;Username=postgres;Password=BigGuardian");
        }
    }
}
