using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaAPEC.Models
{
    public class RegistroTransaccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Empleado")]
        public int EmpleadoId { get; set; }

        [ForeignKey("EmpleadoId")]
        public Empleado? Empleado { get; set; } // Se marca como anulable

        // Relación con TipoIngreso
        public int? TipoIngresoId { get; set; } // Se marca como anulable
        [ForeignKey("TipoIngresoId")]
        public TipoIngreso? TipoIngreso { get; set; } // Se marca como anulable

        // Relación con TipoDeduccion
        public int? TipoDeduccionId { get; set; } // Se marca como anulable
        [ForeignKey("TipoDeduccionId")]
        public TipoDeduccion? TipoDeduccion { get; set; } // Se marca como anulable

        [Required]
        [Display(Name = "Tipo de Transacción")]
        public string TipoTransaccion { get; set; } = string.Empty; // Se inicializa como vacío

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
