using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NominaAPEC.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoIngresoIdAndTipoDeduccionIdToRegistroTransaccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngresoODeduccionId",
                table: "RegistroTransacciones");

            migrationBuilder.AddColumn<int>(
                name: "TipoDeduccionId",
                table: "RegistroTransacciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoIngresoId",
                table: "RegistroTransacciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTransacciones_EmpleadoId",
                table: "RegistroTransacciones",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTransacciones_TipoDeduccionId",
                table: "RegistroTransacciones",
                column: "TipoDeduccionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroTransacciones_TipoIngresoId",
                table: "RegistroTransacciones",
                column: "TipoIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_AsientosContables_EmpleadoId",
                table: "AsientosContables",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsientosContables_Empleados_EmpleadoId",
                table: "AsientosContables",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroTransacciones_Empleados_EmpleadoId",
                table: "RegistroTransacciones",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroTransacciones_TiposDeduccion_TipoDeduccionId",
                table: "RegistroTransacciones",
                column: "TipoDeduccionId",
                principalTable: "TiposDeduccion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroTransacciones_TiposIngreso_TipoIngresoId",
                table: "RegistroTransacciones",
                column: "TipoIngresoId",
                principalTable: "TiposIngreso",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsientosContables_Empleados_EmpleadoId",
                table: "AsientosContables");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroTransacciones_Empleados_EmpleadoId",
                table: "RegistroTransacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroTransacciones_TiposDeduccion_TipoDeduccionId",
                table: "RegistroTransacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroTransacciones_TiposIngreso_TipoIngresoId",
                table: "RegistroTransacciones");

            migrationBuilder.DropIndex(
                name: "IX_RegistroTransacciones_EmpleadoId",
                table: "RegistroTransacciones");

            migrationBuilder.DropIndex(
                name: "IX_RegistroTransacciones_TipoDeduccionId",
                table: "RegistroTransacciones");

            migrationBuilder.DropIndex(
                name: "IX_RegistroTransacciones_TipoIngresoId",
                table: "RegistroTransacciones");

            migrationBuilder.DropIndex(
                name: "IX_AsientosContables_EmpleadoId",
                table: "AsientosContables");

            migrationBuilder.DropColumn(
                name: "TipoDeduccionId",
                table: "RegistroTransacciones");

            migrationBuilder.DropColumn(
                name: "TipoIngresoId",
                table: "RegistroTransacciones");

            migrationBuilder.AddColumn<int>(
                name: "IngresoODeduccionId",
                table: "RegistroTransacciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
