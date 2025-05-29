using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataBaseTry.Models
{
    [Index(nameof(Correo), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public string Contraseña { get; set; } = string.Empty;

        [Required]
        public int InstitucionId { get; set; } // FK a Institucion
        public Institucion Institucion { get; set; }

        [Required]
        [Range(0, 2)]
        public int Rol { get; set; } // 0 = Alumno, 1 = Profesor, 2 = Admin

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellido { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Relaciones de navegación
        public ICollection<Notificacion> Notificaciones { get; set; }
        public ICollection<ComentarioMaterial> ComentariosMaterial { get; set; }
        public ICollection<HistorialAccesoMaterial> HistorialesAccesoMaterial { get; set; }
        public ICollection<Seccion> SeccionesComoProfesor { get; set; } // Secciones donde es profesor
        public ICollection<Inscripcion> InscripcionesComoAlumno { get; set; } // Inscripciones donde es alumno
        public ICollection<Material> MaterialesSubidos { get; set; } // Materiales subidos por el usuario
    }
}