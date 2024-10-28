using System;
using System.ComponentModel.DataAnnotations;

namespace NominaAPEC.Models
{
    public class RegistroTransaccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        [Required]
        public int IngresoODeduccionId { get; set; }

        [Required]
        public string TipoTransaccion { get; set; } // Ej: "Ingreso" o "Deducción"

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
