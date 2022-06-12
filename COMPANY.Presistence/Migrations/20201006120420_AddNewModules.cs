using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class AddNewModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { "DashboardCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dashboard Commercial", null });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { "DashboardProduction", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dashboard Production", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "DashboardCommercial");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "DashboardProduction");
        }
    }
}
