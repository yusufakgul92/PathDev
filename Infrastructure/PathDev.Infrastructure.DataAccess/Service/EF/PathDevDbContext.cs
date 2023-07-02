using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PathDev.Core.Model.EFModel.Customer;
using PathDev.Core.Model.EFModel.Order;
using PathDev.Core.Model.EFModel.Product;

namespace PathDev.Infrastructure.DataAccess.Service.EF
{
    public class PathDevDbContextFactory : IDesignTimeDbContextFactory<PathDevDbContext>
    {
        public PathDevDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PathDevDbContext>();
            optionsBuilder.UseSqlServer(@"Server=EBILGI-YAKGUL\MSSQLSERVER01;Database=PathDev;User Id=sa;Password=crysis_92;MultipleActiveResultSets=True;TrustServerCertificate=True;");

            return new PathDevDbContext(optionsBuilder.Options);
        }
    }

    public class PathDevDbContext : DbContext
    {
        public PathDevDbContext(DbContextOptions<PathDevDbContext> options)
            : base(options)
        {
        }

        public DbSet<Core.Model.EFModel.Customer.Customer> Customers { get; set; }
        public DbSet<Core.Model.EFModel.Customer.Address> Addresses { get; set; }
        public DbSet<CustomerPassword> CustomerPasswords { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Core.Model.EFModel.Order.Order> Orders { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //    @"Server=EBILGI-YAKGUL\MSSQLSERVER01;Database=PathDev;User Id=sa;Password=crysis_92;MultipleActiveResultSets=True;TrustServerCertificate=True;",
            //    b => b.MigrationsAssembly("PathDev.Services.LoginService")
            //); 

            optionsBuilder.UseSqlServer(@"Server=EBILGI-YAKGUL\MSSQLSERVER01;Database=PathDev;User Id=sa;Password=crysis_92;MultipleActiveResultSets=True;TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Core.Model.EFModel.Customer.Customer>()
                .HasMany(c => c.Addresses)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Core.Model.EFModel.Customer.Customer>()
      .HasOne(c => c.CustomerPassword)
      .WithOne(cp => cp.Customer)
      .HasForeignKey<CustomerPassword>(cp => cp.CustomerId);

            modelBuilder.Entity<Core.Model.EFModel.Order.Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            #region seed

            #region Customer

            modelBuilder.Entity<Core.Model.EFModel.Customer.Customer>().HasData(
                new Core.Model.EFModel.Customer.Customer
                {
                    Id = 1,
                    Username = "customer1",
                    Email = "customer1@example.com",
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = "Male",
                    Phone = "123456789",
                    LastIpAddress = "127.0.0.1",
                    LastLoginDate = DateTime.UtcNow,
                    Active = true,
                    CreatedOn = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    Deleted = false,
                    IsSystemRole = true
                },
                new Core.Model.EFModel.Customer.Customer
                {
                    Id = 2,
                    Username = "customer2",
                    Email = "customer2@example.com",
                    FirstName = "Jane",
                    LastName = "Smith",
                    Gender = "Female",
                    Phone = "987654321",
                    LastIpAddress = "192.168.0.1",
                    LastLoginDate = DateTime.UtcNow,
                    Active = true,
                    CreatedOn = DateTime.Now,
                    DateOfBirth = DateTime.Now,
                    Deleted = false,
                    IsSystemRole = false
                }
            );

            #endregion Customer

            #region Customer Password

            modelBuilder.Entity<Core.Model.EFModel.Customer.CustomerPassword>().HasData(
                new Core.Model.EFModel.Customer.CustomerPassword
                {
                    Id = 1,
                    Active = true,
                    CreatedOn = DateTime.Now,
                    Deleted = false,
                    CustomerId = 1,
                    Password = "123456"
                },
                new Core.Model.EFModel.Customer.CustomerPassword
                {
                    Id = 2,
                    Active = true,
                    CreatedOn = DateTime.Now,
                    Deleted = false,
                    CustomerId = 2,
                    Password = "123456"
                }
            );

            #endregion Customer Password


            #region Address

            modelBuilder.Entity<Core.Model.EFModel.Customer.Address>().HasData(
               new Core.Model.EFModel.Customer.Address
               {
                   Id = 1,
                   FirstName = "John",
                   LastName = "Doe",
                   Email = "john.doe@example.com",
                   Company = "ABC Company",
                   County = "County 1",
                   City = "New York",
                   Address1 = "123 Main St",
                   Address2 = "Apt 4",
                   ZipPostalCode = "12345",
                   PhoneNumber = "555-1234",
                   FaxNumber = "555-5678",
                   CustomerId = 1,
                   Active = true,
                   CreatedOn = DateTime.Now,
                   Deleted = false,
               },
               new Core.Model.EFModel.Customer.Address
               {
                   Id = 2,
                   FirstName = "Jane",
                   LastName = "Smith",
                   Email = "jane.smith@example.com",
                   Company = "XYZ Company",
                   County = "County 2",
                   City = "Los Angeles",
                   Address1 = "456 Oak St",
                   Address2 = "Unit 7",
                   ZipPostalCode = "67890",
                   PhoneNumber = "555-4321",
                   FaxNumber = "555-8765",
                   CustomerId = 1,
                   Active = true,
                   CreatedOn = DateTime.Now,
                   Deleted = false,
               },
               new Core.Model.EFModel.Customer.Address
               {
                   Id = 3,
                   FirstName = "Jane",
                   LastName = "Smith",
                   Email = "jane.smith@example.com",
                   Company = "XYZ Company",
                   County = "County 2",
                   City = "Los Angeles",
                   Address1 = "456 Oak St",
                   Address2 = "Unit 7",
                   ZipPostalCode = "67890",
                   PhoneNumber = "555-4321",
                   FaxNumber = "555-8765",
                   CustomerId = 2,
                   Active = true,
                   CreatedOn = DateTime.Now,
                   Deleted = false,
               },
               new Core.Model.EFModel.Customer.Address
               {
                   Id = 4,
                   FirstName = "John",
                   LastName = "Doe",
                   Email = "john.doe@example.com",
                   Company = "ABC Company",
                   County = "County 1",
                   City = "New York",
                   Address1 = "123 Main St",
                   Address2 = "Apt 4",
                   ZipPostalCode = "12345",
                   PhoneNumber = "555-1234",
                   FaxNumber = "555-5678",
                   CustomerId = 2,
                   Active = true,
                   CreatedOn = DateTime.Now,
                   Deleted = false,
               }
           );


            #endregion Address

            #region Product

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Gtin = "GTIN-1",
                    ShortDescription = "Short description for Product 1",
                    FullDescription = "Full description for Product 1",
                    IsShipEnabled = true,
                    IsFreeShipping = false,
                    AdditionalShippingCharge = 5.99m,
                    StockQuantity = 100,
                    OrderMinimumQuantity = 1,
                    OrderMaximumQuantity = 10,
                    NotReturnable = false,
                    Price = 19.99m,
                    OldPrice = 24.99m,
                    Weight = 2.5m,
                    Length = 10.5m,
                    Width = 5.5m,
                    Height = 3.5m,
                    OrderCount = 50,
                    Active = true,
                    CreatedOn = DateTime.Now,
                    Deleted = false,
                    Tax = 18
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Gtin = "GTIN-2",
                    ShortDescription = "Short description for Product 2",
                    FullDescription = "Full description for Product 2",
                    IsShipEnabled = true,
                    IsFreeShipping = true,
                    AdditionalShippingCharge = 0.00m,
                    Tax = 18,
                    StockQuantity = 50,
                    OrderMinimumQuantity = 1,
                    OrderMaximumQuantity = 5,
                    NotReturnable = true,
                    Price = 9.99m,
                    OldPrice = 14.99m,
                    Weight = 1.5m,
                    Length = 8.5m,
                    Width = 4.5m,
                    Height = 2.5m,
                    OrderCount = 25,
                    Active = true,
                    CreatedOn = DateTime.Now,
                    Deleted = false,
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    Gtin = "GTIN-3",
                    ShortDescription = "Short description for Product 3",
                    FullDescription = "Full description for Product 3",
                    IsShipEnabled = true,
                    IsFreeShipping = false,
                    AdditionalShippingCharge = 3.99m,
                    Tax = 18,
                    StockQuantity = 200,
                    OrderMinimumQuantity = 1,
                    OrderMaximumQuantity = 20,
                    NotReturnable = false,
                    Price = 14.99m,
                    OldPrice = 19.99m,
                    Weight = 1.8m,
                    Length = 9.8m,
                    Width = 4.8m,
                    Height = 3.8m,
                    OrderCount = 75,
                    Active = true,
                    CreatedOn = DateTime.Now,
                    Deleted = false,
                },
                new Product
                {
                    Id = 4,
                    Name = "Product 4",
                    Gtin = "GTIN-4",
                    ShortDescription = "Short description for Product 4",
                    FullDescription = "Full description for Product 4",
                    IsShipEnabled = true,
                    IsFreeShipping = true,
                    AdditionalShippingCharge = 0.00m,
                    Tax = 18,
                    StockQuantity = 75,
                    OrderMinimumQuantity = 1,
                    OrderMaximumQuantity = 10,
                    NotReturnable = true,
                    Price = 7.99m,
                    OldPrice = 12.99m,
                    Weight = 1.2m,
                    Length = 7.2m,
                    Width = 3.2m,
                    Height = 2.2m,
                    OrderCount = 40,
                    Active = true,
                    CreatedOn = DateTime.Now,
                    Deleted = false,
                },
                new Product
                {
                    Id = 5,
                    Name = "Product 5",
                    Gtin = "GTIN-5",
                    ShortDescription = "Short description for Product 5",
                    FullDescription = "Full description for Product 5",
                    IsShipEnabled = true,
                    IsFreeShipping = false,
                    AdditionalShippingCharge = 4.99m,
                    Tax = 18,
                    StockQuantity = 150,
                    OrderMinimumQuantity = 1,
                    OrderMaximumQuantity = 15,
                    NotReturnable = false,
                    Price = 29.99m,
                    OldPrice = 34.99m,
                    Weight = 3.0m,
                    Length = 12.0m,
                    Width = 6.0m,
                    Height = 4.0m,
                    OrderCount = 60,
                    Active = true,
                    CreatedOn = DateTime.Now,
                    Deleted = false,
                }
            );

            #endregion

            #endregion seed


            base.OnModelCreating(modelBuilder);

        }

    }
}
