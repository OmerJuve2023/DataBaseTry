using DataBaseTry.Models;
using System.ComponentModel.DataAnnotations;

public class Curso {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public string CodigoInstitucion { get; set; }  // p.ej. “86878”, para la multitenancy

    [Required]
    public int InstitucionId { get; set; } // FK a Institucion
    public Institucion Institucion { get; set; }

    public ICollection<Seccion> Secciones { get; set; }
}
