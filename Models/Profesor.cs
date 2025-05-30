using System.ComponentModel.DataAnnotations;

namespace DataBaseTry.Models
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; } // Igual al Id de Usuario

        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Puedes agregar aquí campos exclusivos de profesores, por ejemplo:
        // public string Especialidad { get; set; }
    }
}
