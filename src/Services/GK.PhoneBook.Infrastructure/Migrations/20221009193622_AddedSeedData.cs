using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GK.PhoneBook.Infrastructure.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "pb",
                table: "Persons",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "pb",
                table: "Companies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                schema: "pb",
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "EmployeeCount", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2734), 50, "Blue Company", new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2748) });

            migrationBuilder.InsertData(
                schema: "pb",
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "EmployeeCount", "Name", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2751), 30, "Green Company", new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2752) });

            migrationBuilder.InsertData(
                schema: "pb",
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "EmployeeCount", "Name", "UpdatedDate" },
                values: new object[] { 3, new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2753), 10, "Red Company", new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2753) });

            migrationBuilder.InsertData(
                schema: "pb",
                table: "Persons",
                columns: new[] { "Id", "Address", "CompanyId", "CreatedDate", "FullName", "PhoneNumber", "UpdatedDate" },
                values: new object[] { 1, "Izmir/Turkey", 1, new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2844), "Gizem Kgizem", "+905073452312", new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2845) });

            migrationBuilder.InsertData(
                schema: "pb",
                table: "Persons",
                columns: new[] { "Id", "Address", "CompanyId", "CreatedDate", "FullName", "PhoneNumber", "UpdatedDate" },
                values: new object[] { 2, "Ankara/Turkey", 2, new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2846), "Rose KRose", "+905073455512", new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2846) });

            migrationBuilder.InsertData(
                schema: "pb",
                table: "Persons",
                columns: new[] { "Id", "Address", "CompanyId", "CreatedDate", "FullName", "PhoneNumber", "UpdatedDate" },
                values: new object[] { 3, "Istanbul/Turkey", 3, new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2848), "Melinda GMelindaGates", "+905073455512", new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2848) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "pb",
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "pb",
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "pb",
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "pb",
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "pb",
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "pb",
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "pb",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "pb",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
