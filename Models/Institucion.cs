using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DataBaseTry.Models
{
    public class Institucion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        [Required]
        public string CodigoInstitucion { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Curso> Cursos { get; set; }
    }
}
