using System;
using System.Collections.Generic;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Contexts;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeManufacturer> DeManufacturers { get; set; }

    public virtual DbSet<DeOrder> DeOrders { get; set; }

    public virtual DbSet<DeOrderList> DeOrderLists { get; set; }

    public virtual DbSet<DePickupPoint> DePickupPoints { get; set; }

    public virtual DbSet<DeProduct> DeProducts { get; set; }

    public virtual DbSet<DeRole> DeRoles { get; set; }

    public virtual DbSet<DeSupplier> DeSuppliers { get; set; }

    public virtual DbSet<DeUser> DeUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=mssql;Initial Catalog=ispp2109;User ID=ispp2109;Password=2109;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeManufacturer>(entity =>
        {
            entity.ToTable("DE_Manufacturer");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<DeOrder>(entity =>
        {
            entity.ToTable("DE_Order");

            entity.HasOne(d => d.PickupPoint).WithMany(p => p.DeOrders)
                .HasForeignKey(d => d.PickupPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DE_Order_DE_PickupPoint");

            entity.HasOne(d => d.User).WithMany(p => p.DeOrders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DE_Order_DE_User");
        });

        modelBuilder.Entity<DeOrderList>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            entity.ToTable("DE_OrderList");

            entity.Property(e => e.ProductId)
                .HasMaxLength(6)
                .IsFixedLength();

            entity.HasOne(d => d.Order).WithMany(p => p.DeOrderLists)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DE_OrderList_DE_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.DeOrderLists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DE_OrderList_DE_Product");
        });

        modelBuilder.Entity<DePickupPoint>(entity =>
        {
            entity.ToTable("DE_PickupPoint");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(100);
        });

        modelBuilder.Entity<DeProduct>(entity =>
        {
            entity.ToTable("DE_Product");

            entity.Property(e => e.Id)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Picture).HasMaxLength(500);

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.DeProducts)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DE_Product_DE_Manufacturer");

            entity.HasOne(d => d.Supplier).WithMany(p => p.DeProducts)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DE_Product_DE_Supplier");
        });

        modelBuilder.Entity<DeRole>(entity =>
        {
            entity.ToTable("DE_Role");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<DeSupplier>(entity =>
        {
            entity.ToTable("DE_Supplier");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<DeUser>(entity =>
        {
            entity.ToTable("DE_User");

            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(32);
            entity.Property(e => e.Patronymic).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.DeUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DE_User_DE_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
