using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalProjectService.Models
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

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CurrentConditions> CurrentConditions { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<ThreeDayForecast> ThreeDayForecast { get; set; }

        // Unable to generate entity type for table 'Territories'. Please see the warning messages.
        // Unable to generate entity type for table 'EmployeeTerritories'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Filename=Northwind.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.HasIndex(e => e.CategoryName)
                    .HasName("CategoryName");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnType("nvarchar (15)");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Picture).HasColumnType("image");
            });

            modelBuilder.Entity<CurrentConditions>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.Lastcheck)
                    .IsRequired()
                    .HasColumnName("lastcheck")
                    .HasColumnType("datetime");

                entity.Property(e => e.ObservationTime)
                    .IsRequired()
                    .HasColumnName("observation_time")
                    .HasColumnType("nvarchar");

                entity.Property(e => e.RelativeHumidity)
                    .IsRequired()
                    .HasColumnName("relative_humidity")
                    .HasColumnType("nvarchar");

                entity.Property(e => e.TempF)
                    .HasColumnName("temp_f")
                    .HasColumnType("float");

                entity.Property(e => e.Weather)
                    .IsRequired()
                    .HasColumnName("weather")
                    .HasColumnType("nvarchar");

                entity.Property(e => e.WindDir)
                    .IsRequired()
                    .HasColumnName("wind_dir")
                    .HasColumnType("nvarchar");

                entity.Property(e => e.WindMph)
                    .HasColumnName("wind_mph")
                    .HasColumnType("float");
            });

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

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.HasIndex(e => e.LastName)
                    .HasName("LastName");

                entity.HasIndex(e => e.PostalCode)
                    .HasName("PostalCodeEmployees");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("nvarchar (60)");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasColumnType("nvarchar (15)");

                entity.Property(e => e.Country).HasColumnType("nvarchar (15)");

                entity.Property(e => e.Extension).HasColumnType("nvarchar (4)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("nvarchar (10)");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.HomePhone).HasColumnType("nvarchar (24)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("nvarchar (20)");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PhotoPath).HasColumnType("nvarchar (255)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar (10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar (15)");

                entity.Property(e => e.ReportsTo).HasColumnType("int");

                entity.Property(e => e.Title).HasColumnType("nvarchar (30)");

                entity.Property(e => e.TitleOfCourtesy).HasColumnType("nvarchar (25)");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("Order Details");

                entity.HasIndex(e => e.OrderId)
                    .HasName("OrderID");

                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductID");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .HasColumnType("int");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("int");

                entity.Property(e => e.Quantity)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UnitPrice)
                    .IsRequired()
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomerID");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("EmployeeID");

                entity.HasIndex(e => e.OrderDate)
                    .HasName("OrderDate");

                entity.HasIndex(e => e.ShipPostalCode)
                    .HasName("ShipPostalCode");

                entity.HasIndex(e => e.ShipVia)
                    .HasName("ShippersOrders");

                entity.HasIndex(e => e.ShippedDate)
                    .HasName("ShippedDate");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasColumnType("nchar (5)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasColumnType("int");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.ShipAddress).HasColumnType("nvarchar (60)");

                entity.Property(e => e.ShipCity).HasColumnType("nvarchar (15)");

                entity.Property(e => e.ShipCountry).HasColumnType("nvarchar (15)");

                entity.Property(e => e.ShipName).HasColumnType("nvarchar (40)");

                entity.Property(e => e.ShipPostalCode).HasColumnType("nvarchar (10)");

                entity.Property(e => e.ShipRegion).HasColumnType("nvarchar (15)");

                entity.Property(e => e.ShipVia).HasColumnType("int");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.HasIndex(e => e.CategoryId)
                    .HasName("CategoriesProducts");

                entity.HasIndex(e => e.ProductName)
                    .HasName("ProductName");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("SupplierID");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .HasColumnType("int");

                entity.Property(e => e.Discontinued)
                    .IsRequired()
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnType("nvarchar (40)");

                entity.Property(e => e.QuantityPerUnit).HasColumnType("nvarchar (20)");

                entity.Property(e => e.ReorderLevel)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasColumnType("int");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnitsInStock)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnitsOnOrder)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<Shippers>(entity =>
            {
                entity.HasKey(e => e.ShipperId);

                entity.Property(e => e.ShipperId)
                    .HasColumnName("ShipperID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("nvarchar (40)");

                entity.Property(e => e.Phone).HasColumnType("nvarchar (24)");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.HasIndex(e => e.CompanyName)
                    .HasName("CompanyNameSuppliers");

                entity.HasIndex(e => e.PostalCode)
                    .HasName("PostalCodeSuppliers");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
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

                entity.Property(e => e.HomePage).HasColumnType("ntext");

                entity.Property(e => e.Phone).HasColumnType("nvarchar (24)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar (10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar (15)");
            });

            modelBuilder.Entity<ThreeDayForecast>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fcttext)
                    .IsRequired()
                    .HasColumnName("fcttext")
                    .HasColumnType("nvarchar");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnName("icon")
                    .HasColumnType("nvarchar");

                entity.Property(e => e.Lastcheck)
                    .IsRequired()
                    .HasColumnName("lastcheck")
                    .HasColumnType("datetime");

                entity.Property(e => e.Period)
                    .HasColumnName("period")
                    .HasColumnType("int");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("nvarchar");
            });
        }
    }
}
