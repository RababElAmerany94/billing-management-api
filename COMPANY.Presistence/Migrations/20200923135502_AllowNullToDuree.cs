using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class AllowNullToDuree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duree",
                table: "EchangeCommercials",
                nullable: true,
                oldClrType: typeof(TimeSpan));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duree",
                table: "EchangeCommercials",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);
        }
    }
}
