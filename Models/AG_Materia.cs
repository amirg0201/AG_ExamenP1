using System.ComponentModel.DataAnnotations;

namespace AG_Examen.Models
{
    public class AG_Materia
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public bool Aprobado { get; set; }

        [Range(0.01, 9999.99)]
        [VerificarRango]
        public decimal Nota { get; set; }
    }
public class VerificarRango : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            decimal valor = (decimal)value;
            if (valor < 10)
            {
                return base.IsValid(value);
            }
            else { 
            return false;}
        }
    }
}
