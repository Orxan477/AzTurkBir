using Aztobir.Core.Models;
using Aztobir.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aztobir.Data.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<FAQ> FAQs{ get; set; }
        public DbSet<Feedback> Feedbacks{ get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team>Teams { get; set; }
        public DbSet<University>Universities{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AboutConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new ExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new FAQConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new GoalConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new UniversityConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}
