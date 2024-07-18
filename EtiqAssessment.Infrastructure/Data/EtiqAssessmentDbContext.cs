using Microsoft.EntityFrameworkCore;
using EtiqAssessment.Domain.Entities;

namespace EtiqAssessment.Infrastructure.Data
{
    public class EtiqAssessmentDbContext : DbContext
    {
        public EtiqAssessmentDbContext(DbContextOptions<EtiqAssessmentDbContext> options) : base(options) { }

        public DbSet<Freelancer> Freelancers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Freelancer>(entity =>
            {
                entity.Property(e => e.Username)
                    .IsRequired();

                entity.Property(e => e.Mail)
                    .IsRequired();
            });
        }
    }
}
