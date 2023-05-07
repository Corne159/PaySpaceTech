using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PaySpaceTech.DataLayer.Models;

public partial class PaySpaceDBContext : DbContext
{
    public PaySpaceDBContext()
    {
    }

    public PaySpaceDBContext(DbContextOptions<PaySpaceDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bracket> Brackets { get; set; }

    public virtual DbSet<Calculation> Calculations { get; set; }

    public virtual DbSet<Postalcode> Postalcodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("user id=payspace;pwd=P@yspace123;host=localhost;database=payspacedb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.22-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Bracket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("brackets");
        });

        modelBuilder.Entity<Calculation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("calculations");

            entity.HasIndex(e => e.PostalCodeId, "fk_calculations_postalcodes_idx");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.MonthlyIncome).HasPrecision(10, 2);

            entity.HasOne(d => d.PostalCode).WithMany(p => p.Calculations)
                .HasForeignKey(d => d.PostalCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_calculations_postalcodes");
        });

        modelBuilder.Entity<Postalcode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("postalcodes");

            entity.Property(e => e.CalculationType).HasMaxLength(255);
            entity.Property(e => e.Code).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
