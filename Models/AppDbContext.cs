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
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<SeccionHorario> SeccionesHorario { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SeccionHorario>()
                .HasKey(sh => new { sh.SeccionId, sh.HorarioId });
            modelBuilder.Entity<SeccionHorario>()
                .HasOne(sh => sh.Seccion)
                .WithMany(s => s.SeccionesHorario)
                .HasForeignKey(sh => sh.SeccionId);
            modelBuilder.Entity<SeccionHorario>()
                .HasOne(sh => sh.Horario)
                .WithMany(h => h.SeccionesHorario)
                .HasForeignKey(sh => sh.HorarioId);
        }
    }
}
