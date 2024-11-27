using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaAPEC.Models
{
    public class TipoDeduccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "text")] // PostgreSQL usa 'text' para cadenas largas
        public string Nombre { get; set; } = string.Empty;

        public bool DependeDeSalario { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
