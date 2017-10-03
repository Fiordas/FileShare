using Microsoft.EntityFrameworkCore;

namespace FileShare.Models
{
    public class SharedFileContext : DbContext
    {
        public SharedFileContext(DbContextOptions<SharedFileContext> options)
            : base(options)
        {
        }

        public DbSet<SharedFile> SharedFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SharedFile>().ToTable("SharedFile");
        }
    }
}