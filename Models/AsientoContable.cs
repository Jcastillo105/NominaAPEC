using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaAPEC.Models
{
    public class AsientoContable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El empleado es obligatorio.")]
        [Display(Name = "Empleado")]
        public int EmpleadoId { get; set; }

        // Relación con el modelo Empleado
        [ForeignKey("EmpleadoId")]
        public Empleado? Empleado { get; set; }

        [Required(ErrorMessage = "La cuenta es obligatoria.")]
        public string Cuenta { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de movimiento es obligatorio.")]
        [Display(Name = "Tipo de Movimiento")]
        public string TipoMovimiento { get; set; } = string.Empty; // Ej: "DB" (Débito) o "CR" (Crédito)

        [Required(ErrorMessage = "La fecha del asiento es obligatoria.")]
        [Display(Name = "Fecha del Asiento")]
        public DateTime FechaAsiento { get; set; }

        [Required(ErrorMessage = "El monto del asiento es obligatorio.")]
        [Display(Name = "Monto del Asiento")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un número positivo.")]
        public decimal MontoAsiento { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool Estado { get; set; }
    }
}
