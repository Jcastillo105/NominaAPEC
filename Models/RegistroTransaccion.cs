using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaAPEC.Models
{
    public class RegistroTransaccion
    {
        [Key]
        [Column("id")] // Mapeo explícito
        public int Id { get; set; }

        [Required]
        [Display(Name = "Empleado")]
        [Column("empleadoid")] // Mapeo explícito
        public int EmpleadoId { get; set; }

        [ForeignKey("EmpleadoId")]
        public Empleado? Empleado { get; set; } // Relación con la tabla Empleados

        [Column("tipoingresoid")]
        public int? TipoIngresoId { get; set; }

        [ForeignKey("TipoIngresoId")]
        public TipoIngreso? TipoIngreso { get; set; }

        [Column("tipodeduccionid")]
        public int? TipoDeduccionId { get; set; }

        [ForeignKey("TipoDeduccionId")]
        public TipoDeduccion? TipoDeduccion { get; set; }

        [Required]
        [Display(Name = "Tipo de Transacción")]
        [Column("tipotransaccion", TypeName = "text")]
        public string TipoTransaccion { get; set; } = string.Empty;

        [Required]
        [Column("fecha", TypeName = "timestamp without time zone")]
        public DateTime Fecha { get; set; }

        [Required]
        [Column("monto", TypeName = "numeric")]
        public decimal Monto { get; set; }

        [Required]
        [Column("estado", TypeName = "smallint")]
        public bool Estado { get; set; }

        // Aquí se almacena el ID del asiento contable que devuelva la API externa
        [Required]
        [Display(Name = "ID del Asiento Contable")]
        [Column("idasiento")]
        public int IdAsiento { get; set; }
    }
}
