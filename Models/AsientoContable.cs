using System;
using System.ComponentModel.DataAnnotations;

namespace NominaAPEC.Models
{
    public class AsientoContable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        [Required]
        public string Cuenta { get; set; }

        [Required]
        public string TipoMovimiento { get; set; } // Ej: "DB" (Débito) o "CR" (Crédito)

        [Required]
        public DateTime FechaAsiento { get; set; }

        [Required]
        public decimal MontoAsiento { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
