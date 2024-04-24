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
        public decimal Nota { get; set; }
    }
}
