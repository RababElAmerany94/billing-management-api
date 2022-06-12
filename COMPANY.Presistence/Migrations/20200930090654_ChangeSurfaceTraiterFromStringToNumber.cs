using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class ChangeSurfaceTraiterFromStringToNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SurfaceTraiter",
                table: "Dossiers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SurfaceTraiter",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SurfaceTraiter",
                table: "Dossiers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SurfaceTraiter",
                table: "Clients",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
