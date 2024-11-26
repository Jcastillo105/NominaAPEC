using System.ComponentModel.DataAnnotations;

namespace NominaAPEC.Models
{
    public class TipoDeduccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public bool DependeDeSalario { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
