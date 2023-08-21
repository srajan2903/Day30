using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExerciseDay30.Models;

public partial class ProductsDbContext : DbContext
{
    public ProductsDbContext()
    {
    }

    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompanyInfo> CompanyInfos { get; set; }

    public virtual DbSet<ProductInfo> ProductInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MFEN465;database=ProductsDb;trusted_connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyInfo>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__CompanyI__C1FFD861E30E1469");

            entity.ToTable("CompanyInfo");

            entity.Property(e => e.Cid).ValueGeneratedNever();
            entity.Property(e => e.Cname).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductInfo>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__ProductI__C57059380C8C1E31");

            entity.ToTable("ProductInfo");

            entity.Property(e => e.Pid).ValueGeneratedNever();
            entity.Property(e => e.Pmdate).HasColumnType("datetime");
            entity.Property(e => e.Pname).HasMaxLength(50);
            entity.Property(e => e.Pprice).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.ProductInfos)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__ProductInfo__Cid__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
