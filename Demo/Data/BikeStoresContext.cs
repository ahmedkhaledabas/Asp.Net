using System;
using System.Collections.Generic;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data;

public partial class BikeStoresContext : DbContext
{
    public BikeStoresContext()
    {
    }

    public BikeStoresContext(DbContextOptions<BikeStoresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //    var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build().GetConnectionString("DefaultConnection");
    //    optionsBuilder.UseSqlServer(builder);
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>optionsBuilder
        .UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build().GetConnectionString("DefaultConnection"));
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__brands__5E5A8E272BB67A2E");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B4CB2D9D8C");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB852E18F23D");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF5D5380DDE");

            entity.ToTable("products", "production", tb => tb.HasTrigger("trg_product_audit"));

            entity.HasOne(d => d.Brand).WithMany(p => p.Products).HasConstraintName("FK__products__brand___3C69FB99");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK__products__catego__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
