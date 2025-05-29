using System.ComponentModel.DataAnnotations;
using System;

namespace DataBaseTry.Models
{
    public class HistorialAccesoMaterial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaAcceso { get; set; } = DateTime.Now;
    }
}
