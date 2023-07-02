using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PathDev.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTaxExempt",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "Products",
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
                columns: new[] { "CreatedOn", "Tax" },
                values: new object[] { new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1101), 18m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Tax" },
                values: new object[] { new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1111), 18m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Tax" },
                values: new object[] { new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1116), 18m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Tax" },
                values: new object[] { new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1120), 18m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Tax" },
                values: new object[] { new DateTime(2023, 7, 1, 23, 54, 44, 72, DateTimeKind.Local).AddTicks(1125), 18m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsTaxExempt",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "CustomerPasswords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "CustomerPasswords",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(198));

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "IsTaxExempt" },
                values: new object[] { new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(255), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "IsTaxExempt" },
                values: new object[] { new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(262), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "IsTaxExempt" },
                values: new object[] { new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(266), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "IsTaxExempt" },
                values: new object[] { new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(270), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "IsTaxExempt" },
                values: new object[] { new DateTime(2023, 7, 1, 14, 46, 55, 257, DateTimeKind.Local).AddTicks(279), false });
        }
    }
}
