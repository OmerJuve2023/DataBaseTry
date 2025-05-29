using System.ComponentModel.DataAnnotations;
using System;

namespace DataBaseTry.Models
{
    public class Notificacion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public bool Leido { get; set; } = false;
    }
}
