using System.ComponentModel.DataAnnotations;
using System;

namespace DataBaseTry.Models
{
    public class ComentarioMaterial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [Required]
        public string Texto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
