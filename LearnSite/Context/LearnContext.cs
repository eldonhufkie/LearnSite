using LearnSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnSite.Context
{
    public class LearnContext : IdentityDbContext<ApplicationUser>
    {
        public LearnContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<MyCourse> MyCourses { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}