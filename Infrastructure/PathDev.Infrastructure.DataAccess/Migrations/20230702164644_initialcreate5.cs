using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PathDev.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDiscount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderSubTotalDiscountExclTax",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderSubTotalDiscountInclTax",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "CustomerPasswords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "CustomerPasswords",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateOfBirth", "LastLoginDate" },
                values: new object[] { new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6109), new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6119), new DateTime(2023, 7, 2, 16, 46, 44, 367, DateTimeKind.Utc).AddTicks(6103) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateOfBirth", "LastLoginDate" },
                values: new object[] { new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6126), new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6126), new DateTime(2023, 7, 2, 16, 46, 44, 367, DateTimeKind.Utc).AddTicks(6125) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 2, 19, 46, 44, 367, DateTimeKind.Local).AddTicks(6318));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderDiscount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderSubTotalDiscountExclTax",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderSubTotalDiscountInclTax",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "CustomerPasswords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "CustomerPasswords",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1041));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateOfBirth", "LastLoginDate" },
                values: new object[] { new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(858), new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(869), new DateTime(2023, 7, 1, 20, 54, 44, 72, DateTimeKind.Utc).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateOfBirth", "LastLoginDate" },
                values: new object[] { new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(876), new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(877), new DateTime(2023, 7, 1, 20, 54, 44, 72, DateTimeKind.Utc).AddTicks(875) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1125));
        }
    }
}
