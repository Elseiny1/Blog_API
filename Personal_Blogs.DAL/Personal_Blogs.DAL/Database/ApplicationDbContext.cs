

namespace Personal_Blogs.DAL.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region Fluent API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>()
                .HasIndex(u => u.Titel)
                .IsUnique();
        }
        #endregion

        #region Models
        public DbSet<Blog> Blogs { set; get; }
        #endregion

    }
}
