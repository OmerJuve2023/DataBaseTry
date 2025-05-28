using System.ComponentModel.DataAnnotations;

namespace DataBaseTry.Models
{
    public class Seccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; }       // p.ej. “Sección ABC-1”  

        [Required]
        public int CursoId { get; set; }

        [Required]
        public Curso Curso { get; set; }

        // Relación con Profesor
        [Required]
        public int ProfesorId { get; set; }
        public Usuario Profesor { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; }

        public ICollection<Material> Materiales { get; set; }
    }
}
