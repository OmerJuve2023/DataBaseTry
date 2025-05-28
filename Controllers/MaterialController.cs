using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBaseTry.Models;
using System.Security.Claims;

public class MaterialController : Controller
{
    private readonly AppDbContext _ctx;
    private readonly IWebHostEnvironment _env;

    public MaterialController(AppDbContext ctx, IWebHostEnvironment env)
    {
        _ctx = ctx;
        _env = env;
    }

    // GET: Material/Create/{seccionId}
    public IActionResult Create(int seccionId)
    {
        return View(seccionId); // Pasa el id como modelo
    }

    // POST: Material/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int seccionId, string titulo, string descripcion, IFormFile archivo)
    {
        // Validar que el usuario sea profesor/admin usando la sesión
        int? rol = HttpContext.Session.GetInt32("Rol");
        if (rol != 1 && rol != 2)
        {
            // Redirige a una vista de acceso denegado o al inicio
            return RedirectToAction("Index", "Home");
        }

        if (archivo == null || archivo.Length == 0)
        {
            ModelState.AddModelError("archivo", "Debes seleccionar un archivo.");
            return View(seccionId);
        }

        var extensionesPermitidas = new[] { ".pdf", ".docx", ".pptx", ".xlsx", ".png", ".jpg" };
        var extension = Path.GetExtension(archivo.FileName).ToLowerInvariant();
        if (!extensionesPermitidas.Contains(extension))
        {
            ModelState.AddModelError("archivo", "Tipo de archivo no permitido.");
            return View(seccionId);
        }

        if (archivo.Length > 50 * 1024 * 1024)
        {
            ModelState.AddModelError("archivo", "El archivo excede el tamaño máximo permitido (50 MB).");
            return View(seccionId);
        }

        var carpeta = Path.Combine(_env.WebRootPath, "materiales", seccionId.ToString());
        Directory.CreateDirectory(carpeta);
        var fileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(carpeta, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await archivo.CopyToAsync(stream);
        }

        // Obtener el ID del usuario desde la sesión
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            // Redirige a una vista de acceso denegado o al inicio
            return RedirectToAction("Index", "Home");
        }

        var material = new Material
        {
            Titulo = titulo,
            Descripcion = descripcion,
            FilePath = $"/materiales/{seccionId}/{fileName}",
            FechaSubida = DateTime.UtcNow,
            SeccionId = seccionId,
            UploadedById = userId.Value
        };
        _ctx.Materiales.Add(material);
        await _ctx.SaveChangesAsync();
        return RedirectToAction("Index", new { seccionId });
    }

    // GET: Material/Index/{seccionId}
    public async Task<IActionResult> Index(int seccionId)
    {
        // Validar acceso: profesor/admin o alumno inscrito usando la sesión
        int? rol = HttpContext.Session.GetInt32("Rol");
        int? userId = HttpContext.Session.GetInt32("UserId");
        bool isProfesor = rol == 1 || rol == 2;
        bool acceso = isProfesor
            || await _ctx.Inscripciones.AnyAsync(i => i.SeccionId == seccionId && i.AlumnoId == userId);

        if (!acceso)
        {
            return RedirectToAction("Login", "Home");
        }

        var materiales = await _ctx.Materiales
            .Where(m => m.SeccionId == seccionId)
            .OrderByDescending(m => m.FechaSubida)
            .ToListAsync();

        ViewBag.SeccionId = seccionId;
        return View(materiales);
    }
}
