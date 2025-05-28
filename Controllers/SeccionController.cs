using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBaseTry.Models;
using System.Security.Claims;

public class SeccionController : Controller
{
    private readonly AppDbContext _ctx;
    public SeccionController(AppDbContext ctx) => _ctx = ctx;

    public async Task<IActionResult> Index()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            // Redirige a Login si no hay usuario en sesión
            return RedirectToAction("Login", "Home");
        }

        // Si es alumno, solo sus secciones; si es profesor/admin, todas
        int rol = HttpContext.Session.GetInt32("Rol") ?? -1;
        IQueryable<Seccion> query = _ctx.Secciones.Include(s => s.Curso);

        if (rol == 0) // Alumno
        {
            query = query.Where(s => s.Inscripciones.Any(i => i.AlumnoId == userId));
        }
        else if (rol == 1) // Profesor
        {
            // Filtrar por secciones donde el profesor dicta
            query = query.Where(s => s.ProfesorId == userId);
        }

        var secciones = await query.ToListAsync();
        return View(secciones);
    }
}