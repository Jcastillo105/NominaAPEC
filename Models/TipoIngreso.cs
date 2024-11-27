using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaAPEC.Models
{
    public class TipoIngreso
    {
        [Key]
        [Column("id")] // Mapeo explícito para la columna en PostgreSQL
        public int Id { get; set; }

        [Required]
        [Column("nombre", TypeName = "text")] // Mapeo explícito para 'nombre'
        public string Nombre { get; set; } = string.Empty;

        [Column("dependedesalario", TypeName = "smallint")] // Mapeo explícito para 'dependedesalario'
        public bool DependeDeSalario { get; set; }

        [Required]
        [Column("estado", TypeName = "smallint")] // Mapeo explícito para 'estado'
        public bool Estado { get; set; }

        // Se ignora "trial710" si no es usado en el modelo
        [Column("trial710", TypeName = "character")] // Mapeo explícito para 'trial710'
        public string? Trial710 { get; set; } = string.Empty; // Propiedad opcional
    }
}
