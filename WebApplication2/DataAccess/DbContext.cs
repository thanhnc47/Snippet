
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.DataAccess
{
    public class SnippetContext : DbContext
    {
        public SnippetContext(DbContextOptions<SnippetContext> options) : base(options)
        {
        }
        public DbSet<SnippetEntity> Snippets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SnippetEntity>().ToTable("Snippet");
            base.OnModelCreating(modelBuilder);

        }
    }
}