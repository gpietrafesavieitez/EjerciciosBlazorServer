using Microsoft.EntityFrameworkCore.Migrations;

namespace EjerciciosBlazorServer.Migrations
{
    public partial class organizador4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Completada",
                table: "Tareas",
                newName: "Estado");

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Tareas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Pasos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Pasos");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Tareas",
                newName: "Completada");

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Tareas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
