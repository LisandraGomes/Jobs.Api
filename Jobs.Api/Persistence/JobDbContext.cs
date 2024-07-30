using Jobs.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Api.Persistence
{
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>(o => 
            { 
                o.HasKey(j => j.Id); 
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
