using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominaAPEC.Migrations
{
    /// <inheritdoc />
    public partial class AddEmpleadoIdAndTipoTransaccionToAsientoContable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "asientoscontables",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TipoTransaccion",
                table: "asientoscontables",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "asientoscontables");

            migrationBuilder.DropColumn(
                name: "TipoTransaccion",
                table: "asientoscontables");
        }
    }
}
