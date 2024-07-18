using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EtiqAssessment.model;

public partial class CdndbContext : DbContext
{
    public CdndbContext()
    {
    }

    public CdndbContext(DbContextOptions<CdndbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Freelancers> Freelancers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=CDNDB;User ID=sa;Password=Inthedoor@1;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;MultiSubnetFailover=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Freelancers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0758EE927B");

            entity.Property(e => e.Hobby).HasMaxLength(200);
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Skillsets).HasMaxLength(500);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
