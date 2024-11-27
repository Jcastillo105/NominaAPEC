using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NominaAPEC.Models
{
    public class Empleado
    {
        [Key]
        [Column("id")] // Mapeo explícito a 'id' en PostgreSQL
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cédula")]
        [CedulaValidation(ErrorMessage = "La cédula ingresada no es válida.")]
        [Column("cedula", TypeName = "text")] // 'cedula' en PostgreSQL
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [Column("nombre", TypeName = "text")] // 'nombre' en PostgreSQL
        public string Nombre { get; set; } = string.Empty;

        [Column("departamento", TypeName = "text")] // 'departamento' en PostgreSQL
        public string Departamento { get; set; } = string.Empty;

        [Column("puesto", TypeName = "text")] // 'puesto' en PostgreSQL
        public string Puesto { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Salario Mensual")]
        [Column("salariomensual", TypeName = "numeric")] // 'salariomensual' en PostgreSQL
        [Range(0, double.MaxValue, ErrorMessage = "El salario mensual debe ser un número positivo.")]
        public decimal SalarioMensual { get; set; }

        [Required]
        [Column("nominaid")] // 'nominaid' en PostgreSQL
        public int NominaId { get; set; }
    }

    // Validación personalizada de la cédula
    public class CedulaValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && ValidaCedula(value.ToString()!))
            {
                return ValidationResult.Success!;
            }
            return new ValidationResult(ErrorMessage);
        }

        private bool ValidaCedula(string pCedula)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed != 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) +
                               Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            return vnTotal % 10 == 0;
        }
    }
}
