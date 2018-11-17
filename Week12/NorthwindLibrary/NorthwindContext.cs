using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NorthwindLibrary
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Filename=..\\NorthwindLibrary\\Northwind.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.HasIndex(e => e.City)
                    .HasName("City");

                entity.HasIndex(e => e.CompanyName)
                    .HasName("CompanyNameCustomers");

                entity.HasIndex(e => e.PostalCode)
                    .HasName("PostalCodeCustomers");

                entity.HasIndex(e => e.Region)
                    .HasName("Region");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasColumnType("nchar (5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("nvarchar (60)");

                entity.Property(e => e.City).HasColumnType("nvarchar (15)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("nvarchar (40)");

                entity.Property(e => e.ContactName).HasColumnType("nvarchar (30)");

                entity.Property(e => e.ContactTitle).HasColumnType("nvarchar (30)");

                entity.Property(e => e.Country).HasColumnType("nvarchar (15)");

                entity.Property(e => e.Fax).HasColumnType("nvarchar (24)");

                entity.Property(e => e.Phone).HasColumnType("nvarchar (24)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar (10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar (15)");
            });
        }
    }
}
