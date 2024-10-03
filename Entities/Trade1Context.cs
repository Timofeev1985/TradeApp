using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TradeApp.Entities;

public partial class Trade1Context : DbContext
{
    public Trade1Context()
    {
    }

    public Trade1Context(DbContextOptions<Trade1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<MeasureUnit> MeasureUnits { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<PickupPoint> PickupPoints { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=trade1;Username=postgres;Password=Student");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("manufacturer_pkey");

            entity.ToTable("manufacturer");

            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(100)
                .HasColumnName("manufacturer_name");
        });

        modelBuilder.Entity<MeasureUnit>(entity =>
        {
            entity.HasKey(e => e.MeasureUnitId).HasName("measure_unit_pkey");

            entity.ToTable("measure_unit");

            entity.Property(e => e.MeasureUnitId).HasColumnName("measure_unit_id");
            entity.Property(e => e.MeasureUnitName)
                .HasMaxLength(100)
                .HasColumnName("measure_unit_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("order_pkey");

            entity.ToTable("order");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderClient).HasColumnName("order_client");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderDeliveryDate).HasColumnName("order_delivery_date");
            entity.Property(e => e.OrderPickupPoint).HasColumnName("order_pickup_point");
            entity.Property(e => e.OrderSecretKey)
                .HasMaxLength(10)
                .HasColumnName("order_secret_key");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");

            entity.HasOne(d => d.OrderClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderClient)
                .HasConstraintName("order_order_client_fkey");

            entity.HasOne(d => d.OrderPickupPointNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderPickupPoint)
                .HasConstraintName("order_order_pickup_point_fkey");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => e.OrderProduct1).HasName("order_product_pkey");

            entity.ToTable("order_product");

            entity.Property(e => e.OrderProduct1).HasColumnName("order_product");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderProductCount)
                .HasDefaultValue(0)
                .HasColumnName("order_product_count");
            entity.Property(e => e.ProductArticleNumber)
                .HasMaxLength(100)
                .HasColumnName("product_article_number");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_product_order_id_fkey");

            entity.HasOne(d => d.ProductArticleNumberNavigation).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductArticleNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_product_product_article_number_fkey");
        });

        modelBuilder.Entity<PickupPoint>(entity =>
        {
            entity.HasKey(e => e.PickupPointId).HasName("pickup_point_pkey");

            entity.ToTable("pickup_point");

            entity.Property(e => e.PickupPointId).HasColumnName("pickup_point_id");
            entity.Property(e => e.PickupPointAddress)
                .HasMaxLength(100)
                .HasColumnName("pickup_point_address");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductArticleNumber).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.ProductArticleNumber)
                .HasMaxLength(100)
                .HasColumnName("product_article_number");
            entity.Property(e => e.ProductCategory).HasColumnName("product_category");
            entity.Property(e => e.ProductCost)
                .HasPrecision(19, 4)
                .HasColumnName("product_cost");
            entity.Property(e => e.ProductDescription).HasColumnName("product_description");
            entity.Property(e => e.ProductDiscountAmount).HasColumnName("product_discount_amount");
            entity.Property(e => e.ProductManufacturer).HasColumnName("product_manufacturer");
            entity.Property(e => e.ProductMaxDiscountAmount).HasColumnName("product_max_discount_amount");
            entity.Property(e => e.ProductMeasureUnit).HasColumnName("product_measure_unit");
            entity.Property(e => e.ProductName).HasColumnName("product_name");
            entity.Property(e => e.ProductPhoto).HasColumnName("product_photo");
            entity.Property(e => e.ProductProvider).HasColumnName("product_provider");
            entity.Property(e => e.ProductQuantityInStock).HasColumnName("product_quantity_in_stock");
            entity.Property(e => e.ProductStatus).HasColumnName("product_status");

            entity.HasOne(d => d.ProductCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategory)
                .HasConstraintName("product_product_category_fkey");

            entity.HasOne(d => d.ProductManufacturerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductManufacturer)
                .HasConstraintName("product_product_manufacturer_fkey");

            entity.HasOne(d => d.ProductMeasureUnitNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductMeasureUnit)
                .HasConstraintName("product_product_measure_unit_fkey");

            entity.HasOne(d => d.ProductProviderNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductProvider)
                .HasConstraintName("product_product_provider_fkey");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.ProviderId).HasName("provider_pkey");

            entity.ToTable("provider");

            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.ProviderName)
                .HasMaxLength(100)
                .HasColumnName("provider_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserLogin).HasColumnName("user_login");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword).HasColumnName("user_password");
            entity.Property(e => e.UserPatronymic)
                .HasMaxLength(100)
                .HasColumnName("user_patronymic");
            entity.Property(e => e.UserRole).HasColumnName("user_role");
            entity.Property(e => e.UserSurname)
                .HasMaxLength(100)
                .HasColumnName("user_surname");

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_user_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
