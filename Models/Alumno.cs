using System;
using System.ComponentModel.DataAnnotations;

namespace DataBaseTry.Models
{
    public class Alumno
    {
        [Key]
        public int Dni { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string NumeroContacto { get; set; } = string.Empty;
    }
}
