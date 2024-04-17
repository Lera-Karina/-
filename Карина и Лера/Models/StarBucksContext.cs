using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Карина_и_Лера.Models;

public partial class StarBucksContext : DbContext
{
    public StarBucksContext()
    {
    }

    public StarBucksContext(DbContextOptions<StarBucksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngredientFromInvoice> IngredientFromInvoices { get; set; }

    public virtual DbSet<IngredientFromTheApplication> IngredientFromTheApplications { get; set; }

    public virtual DbSet<IngredientRequest> IngredientRequests { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsFromOrder> ProductsFromOrders { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<TheIngredientsOfTheGood> TheIngredientsOfTheGoods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;uid=root;Database=StarBucks");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("buyers", "StarBucks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .HasColumnName("address");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category", "StarBucks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employee", "StarBucks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("date")
                .HasColumnName("data");
            entity.Property(e => e.FullName)
                .HasMaxLength(45)
                .HasColumnName("full_name");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(45)
                .HasColumnName("job_title");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.PlaceOfWork)
                .HasMaxLength(45)
                .HasColumnName("place_of_work");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ingredient", "StarBucks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Compound)
                .HasMaxLength(45)
                .HasColumnName("compound");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<IngredientFromInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ingredient_from_invoice", "StarBucks");

            entity.HasIndex(e => e.IngredientId, "fk_ingredient_from_invoice_idx");

            entity.HasIndex(e => e.InvoiceId, "fk_ingredient_from_invoice_idx1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.IngredientFromInvoices)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ingredient_from_invoice");

            entity.HasOne(d => d.Invoice).WithMany(p => p.IngredientFromInvoices)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ingredient_from_invoice66");
        });

        modelBuilder.Entity<IngredientFromTheApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ingredient_from_the_application", "StarBucks");

            entity.HasIndex(e => e.ApplicationId, "fk__idx");

            entity.HasIndex(e => e.IngredienId, "fk_ingredient_from_the_application_idx");

            entity.HasIndex(e => e.EmployeeId, "fk_ingredient_from_the_application_idx1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.IngredienId).HasColumnName("ingredien_id");

            entity.HasOne(d => d.Application).WithMany(p => p.IngredientFromTheApplications)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_87998978");

            entity.HasOne(d => d.Employee).WithMany(p => p.IngredientFromTheApplications)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ingredient_from_the_application777");

            entity.HasOne(d => d.Ingredien).WithMany(p => p.IngredientFromTheApplications)
                .HasForeignKey(d => d.IngredienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ingredient_from_the_application");
        });

        modelBuilder.Entity<IngredientRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ingredient_request", "StarBucks");

            entity.HasIndex(e => e.EmployeeId, "fk_ingredient_request_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("date")
                .HasColumnName("data");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Employee).WithMany(p => p.IngredientRequests)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ingredient_request");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("invoice", "StarBucks");

            entity.HasIndex(e => e.ApplicationId, "fk__idx");

            entity.HasIndex(e => e.ProviderId, "fk_invoice_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.DateOfDelivery)
                .HasColumnType("date")
                .HasColumnName("date_of_delivery");
            entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");

            entity.HasOne(d => d.Application).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_888989778987789");

            entity.HasOne(d => d.Provider).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_invoice");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders", "StarBucks");

            entity.HasIndex(e => e.BuyerId, "fk_buyers_idx");

            entity.HasIndex(e => e.EmployeeId, "fk_employee_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyerId).HasColumnName("buyer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("status");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BuyerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buyers");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products", "StarBucks");

            entity.HasIndex(e => e.CategoryId, "fk_products_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products");
        });

        modelBuilder.Entity<ProductsFromOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products_from_orders", "StarBucks");

            entity.HasIndex(e => e.OrderId, "fk_products_from_orders_idx");

            entity.HasIndex(e => e.ProductId, "fk_products_from_orders_idx1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductsFromOrders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products_from_orders");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsFromOrders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products_from_orders2");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("provider", "StarBucks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.Tin).HasColumnName("TIN");
        });

        modelBuilder.Entity<TheIngredientsOfTheGood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("the_ingredients_of_the_goods", "StarBucks");

            entity.HasIndex(e => e.IngredientId, "fk__idx");

            entity.HasIndex(e => e.ProductId, "fk_the_ingredients_of_the_goods_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.TheIngredientsOfTheGoods)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_");

            entity.HasOne(d => d.Product).WithMany(p => p.TheIngredientsOfTheGoods)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_the_ingredients_of_the_goods");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
