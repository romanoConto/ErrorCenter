using Codenation.ErrorCenter.Models;
using Codenation.ErrorCenter.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.ErrorCenter.Models
{
    public class ErrorCenterContext : DbContext
    {        // this constructor is for enable testing with in-memory data
        public ErrorCenterContext(DbContextOptions<ErrorCenterContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=errorLog;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
