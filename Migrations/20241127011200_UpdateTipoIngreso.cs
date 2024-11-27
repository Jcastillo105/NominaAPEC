using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NominaAPEC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTipoIngreso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asientoscontables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    IdAuxiliar = table.Column<int>(type: "integer", nullable: false),
                    CuentaDB = table.Column<int>(type: "integer", nullable: false),
                    CuentaCR = table.Column<int>(type: "integer", nullable: false),
                    FechaAsiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Monto = table.Column<decimal>(type: "numeric", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asientoscontables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cedula = table.Column<string>(type: "text", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    departamento = table.Column<string>(type: "text", nullable: false),
                    puesto = table.Column<string>(type: "text", nullable: false),
                    salariomensual = table.Column<decimal>(type: "numeric", nullable: false),
                    nominaid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tiposdeduccion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    dependedesalario = table.Column<short>(type: "smallint", nullable: false),
                    estado = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposdeduccion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tiposingreso",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    dependedesalario = table.Column<short>(type: "smallint", nullable: false),
                    estado = table.Column<short>(type: "smallint", nullable: false),
                    trial710 = table.Column<string>(type: "character(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposingreso", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "registrotransacciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    empleadoid = table.Column<int>(type: "integer", nullable: false),
                    tipoingresoid = table.Column<int>(type: "integer", nullable: true),
                    tipodeduccionid = table.Column<int>(type: "integer", nullable: true),
                    tipotransaccion = table.Column<string>(type: "text", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    monto = table.Column<decimal>(type: "numeric", nullable: false),
                    estado = table.Column<short>(type: "smallint", nullable: false),
                    idasiento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrotransacciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_registrotransacciones_empleados_empleadoid",
                        column: x => x.empleadoid,
                        principalTable: "empleados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_registrotransacciones_tiposdeduccion_tipodeduccionid",
                        column: x => x.tipodeduccionid,
                        principalTable: "tiposdeduccion",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_registrotransacciones_tiposingreso_tipoingresoid",
                        column: x => x.tipoingresoid,
                        principalTable: "tiposingreso",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_registrotransacciones_empleadoid",
                table: "registrotransacciones",
                column: "empleadoid");

            migrationBuilder.CreateIndex(
                name: "IX_registrotransacciones_tipodeduccionid",
                table: "registrotransacciones",
                column: "tipodeduccionid");

            migrationBuilder.CreateIndex(
                name: "IX_registrotransacciones_tipoingresoid",
                table: "registrotransacciones",
                column: "tipoingresoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asientoscontables");

            migrationBuilder.DropTable(
                name: "registrotransacciones");

            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "tiposdeduccion");

            migrationBuilder.DropTable(
                name: "tiposingreso");
        }
    }
}
