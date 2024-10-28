using System.ComponentModel.DataAnnotations;

namespace NominaAPEC.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Departamento { get; set; }

        public string Puesto { get; set; }

        [Required]
        public decimal SalarioMensual { get; set; }

        public int NominaId { get; set; }
    }
}
