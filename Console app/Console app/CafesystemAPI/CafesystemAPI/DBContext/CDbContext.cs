using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CafesystemAPI.DBContext;

public partial class CDbContext : DbContext
{
    public CDbContext()
    {
    }

    public CDbContext(DbContextOptions<CDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Detail> Details { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=mssql-157124-0.cloudclusters.net,10041;Initial Catalog=\"console database\";User ID=admin;Password=Admin123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Detail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__detail__3213E83F9BB9F03F");

            entity.ToTable("detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.Product)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Size)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("size");
            entity.Property(e => e.Total).HasColumnName("total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
