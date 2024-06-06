using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_QLNH.Models;

public partial class SqlMvcQlnhContext : DbContext
{
    public SqlMvcQlnhContext()
    {
    }

    public SqlMvcQlnhContext(DbContextOptions<SqlMvcQlnhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAccount> TbAccounts { get; set; }

    public virtual DbSet<TbBillDetail> TbBillDetails { get; set; }

    public virtual DbSet<TbBillHistory> TbBillHistories { get; set; }

    public virtual DbSet<TbDmfood> TbDmfoods { get; set; }

    public virtual DbSet<TbDstable> TbDstables { get; set; }

    public virtual DbSet<TbFood> TbFoods { get; set; }

    public virtual DbSet<TbRevenu> TbRevenus { get; set; }

    public virtual DbSet<TbUserInfo> TbUserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-5RGHKJ2R\\SQLEXPRESS01;Initial Catalog=SqlMvcQLNH;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__tbAccoun__349DA5866156C6F6");

            entity.ToTable("tbAccount");

            entity.HasIndex(e => e.Username, "UQ__tbAccoun__536C85E4FE2731E8").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.AccountType).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<TbBillDetail>(entity =>
        {
            entity.HasKey(e => e.BillDetailId).HasName("PK__tbBillDe__793CAF7502B233DD");

            entity.ToTable("tbBillDetails");

            entity.Property(e => e.BillDetailId).HasColumnName("BillDetailID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Bill).WithMany(p => p.TbBillDetails)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__tbBillDet__BillI__48CFD27E");

            entity.HasOne(d => d.Food).WithMany(p => p.TbBillDetails)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__tbBillDet__FoodI__49C3F6B7");
        });

        modelBuilder.Entity<TbBillHistory>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__tbBillHi__11F2FC4AA847134B");

            entity.ToTable("tbBillHistory");

            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.TableName).HasMaxLength(50);
            entity.Property(e => e.UserInfoId).HasColumnName("UserInfoID");

            entity.HasOne(d => d.Table).WithMany(p => p.TbBillHistories)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__tbBillHis__Table__44FF419A");

            entity.HasOne(d => d.UserInfo).WithMany(p => p.TbBillHistories)
                .HasForeignKey(d => d.UserInfoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__tbBillHis__UserI__45F365D3");
        });

        modelBuilder.Entity<TbDmfood>(entity =>
        {
            entity.HasKey(e => e.DmfoodId).HasName("PK__tbDMFood__3DFF7D6BAB377BAE");

            entity.ToTable("tbDMFood");

            entity.Property(e => e.DmfoodId).HasColumnName("DMFoodID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<TbDstable>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__tbDSTabl__7D5F018EBC217030");

            entity.ToTable("tbDSTable");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TableName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbFood>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__tbFood__856DB3CBEA0CED21");

            entity.ToTable("tbFood");

            entity.Property(e => e.FoodId).HasColumnName("FoodID");
            entity.Property(e => e.DmfoodId).HasColumnName("DMFoodID");
            entity.Property(e => e.FoodName).HasMaxLength(100);

            entity.HasOne(d => d.Dmfood).WithMany(p => p.TbFoods)
                .HasForeignKey(d => d.DmfoodId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__tbFood__DMFoodID__3F466844");
        });

        modelBuilder.Entity<TbRevenu>(entity =>
        {
            entity.HasKey(e => e.RevenuId).HasName("PK__tbRevenu__FBB5DE1DA94B9537");

            entity.ToTable("tbRevenu");

            entity.Property(e => e.RevenuId).HasColumnName("RevenuID");
            entity.Property(e => e.BillId).HasColumnName("BillID");

            entity.HasOne(d => d.Bill).WithMany(p => p.TbRevenus)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__tbRevenu__BillID__4CA06362");
        });

        modelBuilder.Entity<TbUserInfo>(entity =>
        {
            entity.HasKey(e => e.UserInfoId).HasName("PK__tbUserIn__D07EF2C4412A9AE6");

            entity.ToTable("tbUserInfo");

            entity.Property(e => e.UserInfoId).HasColumnName("UserInfoID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.Account).WithMany(p => p.TbUserInfos)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__tbUserInf__Accou__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
