using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaAPEC.Models
{
    public class AsientoContable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Empleado")]
        public int EmpleadoId { get; set; }

        // Relación con el modelo Empleado
        [ForeignKey("EmpleadoId")]
        public Empleado Empleado { get; set; }

        [Required]
        public string Cuenta { get; set; }

        [Required]
        [Display(Name = "Tipo de Movimiento")]
        public string TipoMovimiento { get; set; } // Ej: "DB" (Débito) o "CR" (Crédito)

        [Required]
        [Display(Name = "Fecha del Asiento")]
        public DateTime FechaAsiento { get; set; }

        [Required]
        [Display(Name = "Monto del Asiento")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un número positivo.")]
        public decimal MontoAsiento { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
