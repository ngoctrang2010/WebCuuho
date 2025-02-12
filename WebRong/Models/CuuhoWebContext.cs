using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebRong.Models;

public partial class CuuhoWebContext : DbContext
{
    public CuuhoWebContext()
    {
    }

    public CuuhoWebContext(DbContextOptions<CuuhoWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiViet> BaiViets { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<LienHe> LienHes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("workstation id=Cuuho_Web.mssql.somee.com;packet size=4096;user id=ngosihoaduan_SQLLogin_1;pwd=hubj56oo2t;data source=Cuuho_Web.mssql.somee.com;persist security info=False;initial catalog=Cuuho_Web;TrustServerCertificate=True");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiViet>(entity =>
        {
            entity.HasKey(e => e.IdBaiviet);

            entity.ToTable("BaiViet");

            entity.Property(e => e.ImageIndex).HasColumnName("imageIndex");
            entity.Property(e => e.IsTintuc).HasColumnName("isTintuc");
            entity.Property(e => e.Ngaytao).HasColumnType("datetime");

            entity.HasOne(d => d.IdDichvuNavigation).WithMany(p => p.BaiViets)
                .HasForeignKey(d => d.IdDichvu)
                .HasConstraintName("FK_BaiViet_DichVu");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.IdDichvu);

            entity.ToTable("DichVu");
        });

        modelBuilder.Entity<LienHe>(entity =>
        {
            entity.HasKey(e => e.IdLienhe);

            entity.ToTable("LienHe");

            entity.Property(e => e.Diachi).HasMaxLength(250);
            entity.Property(e => e.Ngaytao).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.Ten).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
