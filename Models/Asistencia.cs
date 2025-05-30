using System;
using System.ComponentModel.DataAnnotations;

namespace DataBaseTry.Models
{
    public class Asistencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int InscripcionId { get; set; }
        public Inscripcion Inscripcion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public bool Presente { get; set; }
    }
}
