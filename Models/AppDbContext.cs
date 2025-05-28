using Microsoft.EntityFrameworkCore;

namespace DataBaseTry.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<ComentarioMaterial> ComentariosMaterial { get; set; }
        public DbSet<HistorialAccesoMaterial> HistorialesAccesoMaterial { get; set; }


    }
}
