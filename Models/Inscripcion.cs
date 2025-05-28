using DataBaseTry.Models;
using System.ComponentModel.DataAnnotations;

public class Inscripcion {
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int AlumnoId { get; set; }

    public Usuario Alumno { get; set; }
    
    [Required]
    public int SeccionId { get; set; }
    public Seccion Seccion { get; set; }
}
