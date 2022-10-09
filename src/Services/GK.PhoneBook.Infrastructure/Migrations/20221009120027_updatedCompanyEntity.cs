using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GK.PhoneBook.Infrastructure.Migrations
{
    public partial class updatedCompanyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeesCount",
                schema: "pb",
                table: "Companies",
                newName: "EmployeeCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeCount",
                schema: "pb",
                table: "Companies",
                newName: "EmployeesCount");
        }
    }
}
