using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DataBaseTry.Models
{
    public class Horario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DiaSemana { get; set; } // Ej: "Lunes"

        [Required]
        public string HoraInicio { get; set; } // Ej: "08:00"

        [Required]
        public string HoraFin { get; set; } // Ej: "10:00"

        // Relación muchos a muchos con Seccion
        public ICollection<SeccionHorario> SeccionesHorario { get; set; }
    }

    public class SeccionHorario
    {
        public int SeccionId { get; set; }
        public Seccion Seccion { get; set; }

        public int HorarioId { get; set; }
        public Horario Horario { get; set; }
    }
}
