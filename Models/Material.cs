using System.ComponentModel.DataAnnotations;

namespace DataBaseTry.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string FilePath { get; set; }       // ruta en wwwroot/materiales/…

        [Required]
        public DateTime FechaSubida { get; set; }

        [Required]
        public int SeccionId { get; set; }
        public Seccion Seccion { get; set; }

        [Required]
        public int UploadedById { get; set; }   // FK a Usuario (profesor)
        public Usuario UploadedBy { get; set; }
    }
}
