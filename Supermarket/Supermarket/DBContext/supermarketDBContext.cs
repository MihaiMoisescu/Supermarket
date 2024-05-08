using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Supermarket.Models;

namespace Supermarket.DBContext
{
    public partial class supermarketDBContext : DbContext
    {
        public supermarketDBContext()
        {
        }

        public supermarketDBContext(DbContextOptions<supermarketDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<ReceiptItems> ReceiptItems { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
        /*To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.*/
                optionsBuilder.UseSqlServer("Server=DESKTOP-SNAS93A\\SQLEXPRESS;Database=supermarketDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.Property(e => e.ProducerId).HasColumnName("producer_id");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.InStock).HasColumnName("in_stock");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProducerId).HasColumnName("producer_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_CATEGORY");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTS_PRODUCERS");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECEIPT_ACCOUNT");
            });

            modelBuilder.Entity<ReceiptItems>(entity =>
            {
                entity.HasKey(e => new { e.ReceiptId, e.ProductId });

                entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ReceiptItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECEIPTITEMS_PRODUCT");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.ReceiptItems)
                    .HasForeignKey(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECEIPTITEMS_RECEIPT");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.StockId).HasColumnName("stock_id");

                entity.Property(e => e.DateOfSupply)
                    .HasColumnName("date_of_supply")
                    .HasColumnType("date");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("expiration_date")
                    .HasColumnType("date");

                entity.Property(e => e.InStock).HasColumnName("in_stock");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.PurchasePrice)
                    .HasColumnName("purchase_price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SelllingPrice)
                    .HasColumnName("sellling_price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
