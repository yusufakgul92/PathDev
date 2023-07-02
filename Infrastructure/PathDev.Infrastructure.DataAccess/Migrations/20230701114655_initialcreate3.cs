using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PathDev.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Product_ProductId",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "CustomerPasswords");

            migrationBuilder.DropColumn(
                name: "OrderGuid",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingStatusId",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameColumn(
                name: "UpdatedOnUtc",
                table: "OrderItem",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOnUtc",
                table: "Customers",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "LastLoginDateUtc",
                table: "Customers",
                newName: "LastLoginDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedOnUtc",
                table: "CustomerPasswords",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOnUtc",
                table: "Addresses",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOnUtc",
                table: "Products",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "UpdatedOnUtc",
                table: "Orders",
                newName: "UpdatedOn");

            migrationBuilder.RenameColumn(
                name: "PaidDateUtc",
                table: "Orders",
                newName: "PaidDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Active", "Address1", "Address2", "City", "Company", "County", "CreatedOn", "CustomerId", "Deleted", "Email", "FaxNumber", "FirstName", "LastName", "PhoneNumber", "UpdatedOn", "ZipPostalCode" },
                values: new object[,]
                {
                    { 1, true, "123 Main St", "Apt 4", "New York", "ABC Company", "County 1", new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(220), 1, false, "john.doe@example.com", "555-5678", "John", "Doe", "555-1234", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345" },
                    { 2, true, "456 Oak St", "Unit 7", "Los Angeles", "XYZ Company", "County 2", new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(225), 1, false, "jane.smith@example.com", "555-8765", "Jane", "Smith", "555-4321", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "67890" },
                    { 3, true, "456 Oak St", "Unit 7", "Los Angeles", "XYZ Company", "County 2", new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(227), 2, false, "jane.smith@example.com", "555-8765", "Jane", "Smith", "555-4321", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "67890" },
                    { 4, true, "123 Main St", "Apt 4", "New York", "ABC Company", "County 1", new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(230), 2, false, "john.doe@example.com", "555-5678", "John", "Doe", "555-1234", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345" }
                });

            migrationBuilder.InsertData(
                table: "CustomerPasswords",
                columns: new[] { "Id", "Active", "CreatedOn", "CustomerId", "Deleted", "Password", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(191), 1, false, "123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(198), 2, false, "123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateOfBirth", "LastLoginDate" },
                values: new object[] { new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(46), new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(57), new DateTime(2023, 7, 1, 11, 46, 55, 257, DateTimeKind.Utc).AddTicks(35) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateOfBirth", "LastLoginDate" },
                values: new object[] { new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(64), new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(64), new DateTime(2023, 7, 1, 11, 46, 55, 257, DateTimeKind.Utc).AddTicks(63) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "AdditionalShippingCharge", "CreatedOn", "Deleted", "FullDescription", "Gtin", "Height", "IsFreeShipping", "IsShipEnabled", "IsTaxExempt", "Length", "Name", "NotReturnable", "OldPrice", "OrderCount", "OrderMaximumQuantity", "OrderMinimumQuantity", "Price", "ShortDescription", "StockQuantity", "UpdatedOn", "Weight", "Width" },
                values: new object[,]
                {
                    { 1, true, 5.99m, new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(255), false, "Full description for Product 1", "GTIN-1", 3.5m, false, true, false, 10.5m, "Product 1", false, 24.99m, 50, 10, 1, 19.99m, "Short description for Product 1", 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5m, 5.5m },
                    { 2, true, 0.00m, new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(262), false, "Full description for Product 2", "GTIN-2", 2.5m, true, true, true, 8.5m, "Product 2", true, 14.99m, 25, 5, 1, 9.99m, "Short description for Product 2", 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.5m, 4.5m },
                    { 3, true, 3.99m, new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(266), false, "Full description for Product 3", "GTIN-3", 3.8m, false, true, false, 9.8m, "Product 3", false, 19.99m, 75, 20, 1, 14.99m, "Short description for Product 3", 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.8m, 4.8m },
                    { 4, true, 0.00m, new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(270), false, "Full description for Product 4", "GTIN-4", 2.2m, true, true, true, 7.2m, "Product 4", true, 12.99m, 40, 10, 1, 7.99m, "Short description for Product 4", 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.2m, 3.2m },
                    { 5, true, 4.99m, new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(279), false, "Full description for Product 5", "GTIN-5", 4.0m, false, true, false, 12.0m, "Product 5", false, 34.99m, 60, 15, 1, 29.99m, "Short description for Product 5", 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0m, 6.0m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Products_ProductId",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Products_ProductId",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CustomerPasswords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerPasswords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "OrderItem",
                newName: "UpdatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Customers",
                newName: "UpdatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastLoginDate",
                table: "Customers",
                newName: "LastLoginDateUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "CustomerPasswords",
                newName: "UpdatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Addresses",
                newName: "UpdatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Product",
                newName: "UpdatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Order",
                newName: "UpdatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "PaidDate",
                table: "Order",
                newName: "PaidDateUtc");

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "CustomerPasswords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderGuid",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ShippingStatusId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateOfBirth", "LastLoginDateUtc" },
                values: new object[] { new DateTime(2023, 6, 28, 2, 18, 29, 272, DateTimeKind.Local).AddTicks(5856), new DateTime(2023, 6, 28, 2, 18, 29, 272, DateTimeKind.Local).AddTicks(5866), new DateTime(2023, 6, 27, 23, 18, 29, 272, DateTimeKind.Utc).AddTicks(5849) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateOfBirth", "LastLoginDateUtc" },
                values: new object[] { new DateTime(2023, 6, 28, 2, 18, 29, 272, DateTimeKind.Local).AddTicks(5869), new DateTime(2023, 6, 28, 2, 18, 29, 272, DateTimeKind.Local).AddTicks(5870), new DateTime(2023, 6, 27, 23, 18, 29, 272, DateTimeKind.Utc).AddTicks(5869) });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Product_ProductId",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
