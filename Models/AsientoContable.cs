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
        [Column(TypeName = "text")] // Cambia de longtext a text
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El auxiliar es obligatorio.")]
        [Display(Name = "ID Auxiliar")]
        public int IdAuxiliar { get; set; }

        [Required(ErrorMessage = "La cuenta DB es obligatoria.")]
        [Display(Name = "Cuenta DB")]
        public int CuentaDB { get; set; }

        [Required(ErrorMessage = "La cuenta CR es obligatoria.")]
        [Display(Name = "Cuenta CR")]
        public int CuentaCR { get; set; }

        [Required(ErrorMessage = "La fecha del asiento es obligatoria.")]
        [Display(Name = "Fecha del Asiento")]
        public DateTime FechaAsiento { get; set; }

        [Required(ErrorMessage = "El monto del asiento es obligatorio.")]
        [Display(Name = "Monto del Asiento")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un número positivo.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool Estado { get; set; }

        // Nuevas propiedades para integración con Registro de Transacciones
        [Required(ErrorMessage = "El ID del empleado es obligatorio.")]
        [Display(Name = "ID del Empleado")]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "El tipo de transacción es obligatorio.")]
        [Display(Name = "Tipo de Transacción")]
        public string TipoTransaccion { get; set; } = string.Empty;

        // Relación con TipoIngreso
        [Display(Name = "Tipo de Ingreso")]
        public int? TipoIngresoId { get; set; }

        [ForeignKey("TipoIngresoId")]
        public TipoIngreso? TipoIngreso { get; set; }

        // Relación con TipoDeduccion
        [Display(Name = "Tipo de Deducción")]
        public int? TipoDeduccionId { get; set; }

        [ForeignKey("TipoDeduccionId")]
        public TipoDeduccion? TipoDeduccion { get; set; }
    }
}
