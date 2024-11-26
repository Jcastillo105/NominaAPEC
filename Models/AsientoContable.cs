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
    }
}
