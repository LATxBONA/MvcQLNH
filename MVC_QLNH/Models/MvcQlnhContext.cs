using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_QLNH.Models;

public partial class MvcQlnhContext : DbContext
{
    public MvcQlnhContext()
    {
    }

    public MvcQlnhContext(DbContextOptions<MvcQlnhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAccount> TbAccounts { get; set; }

    public virtual DbSet<TbUserInfo> TbUserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-5RGHKJ2R\\SQLEXPRESS01;Initial Catalog=MvcQLNH;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAccount>(entity =>
        {
            entity.HasKey(e => e.Taikhoan);

            entity.ToTable("TbAccount");

            entity.Property(e => e.Taikhoan)
                .HasMaxLength(50)
                .HasColumnName("taikhoan");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(50)
                .HasColumnName("matkhau");
            entity.Property(e => e.TypeAccount)
                .HasMaxLength(50)
                .HasColumnName("typeAccount");
        });

        modelBuilder.Entity<TbUserInfo>(entity =>
        {
            entity.HasKey(e => e.MaUser);

            entity.ToTable("TbUserInfo");

            entity.Property(e => e.MaUser)
                .ValueGeneratedNever()
                .HasColumnName("maUser");
            entity.Property(e => e.AvtUser)
                .HasColumnType("image")
                .HasColumnName("avtUser");
            entity.Property(e => e.GioitinhUser).HasColumnName("gioitinhUser");
            entity.Property(e => e.NgaysinhUser)
                .HasColumnType("datetime")
                .HasColumnName("ngaysinhUser");
            entity.Property(e => e.SdtUser).HasColumnName("sdtUser");
            entity.Property(e => e.Taikhoan)
                .HasMaxLength(50)
                .HasColumnName("taikhoan");
            entity.Property(e => e.TenUser)
                .HasMaxLength(50)
                .HasColumnName("tenUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
