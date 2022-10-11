using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GK.PhoneBook.Infrastructure.Migrations
{
    public partial class intialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "EmployeeCount", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1242), 50, "Blue Company", new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1255) });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "EmployeeCount", "Name", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1256), 30, "Green Company", new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1257) });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedDate", "EmployeeCount", "Name", "UpdatedDate" },
                values: new object[] { 3, new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1258), 10, "Red Company", new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1259) });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "CompanyId", "CreatedDate", "FullName", "PhoneNumber", "UpdatedDate" },
                values: new object[] { 1, "Izmir/Turkey", 1, new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1343), "Gizem Kgizem", "+905073452312", new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1344) });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "CompanyId", "CreatedDate", "FullName", "PhoneNumber", "UpdatedDate" },
                values: new object[] { 2, "Ankara/Turkey", 2, new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1346), "Rose KRose", "+905073455512", new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1346) });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "CompanyId", "CreatedDate", "FullName", "PhoneNumber", "UpdatedDate" },
                values: new object[] { 3, "Istanbul/Turkey", 3, new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1347), "Melinda GMelindaGates", "+905073455512", new DateTime(2022, 10, 11, 16, 28, 7, 503, DateTimeKind.Local).AddTicks(1347) });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CompanyId",
                table: "Persons",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
