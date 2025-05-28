using Microsoft.AspNetCore.Mvc;
using DataBaseTry.Models;
using System.Linq;

namespace DataBaseTry.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Correo, string Contraseña)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo.ToLower() == Correo.Trim().ToLower()
                                  && u.Contraseña == Contraseña);

            if (usuario == null || !usuario.Activo)
            {
                ViewBag.Error = "Correo o contraseña inválidos.";
                return View();
            }

            // Guarda el UserId en la sesión
            HttpContext.Session.SetInt32("UserId", usuario.Id);
            HttpContext.Session.SetString("Nombre", usuario.Nombre);
            HttpContext.Session.SetString("Apellido", usuario.Apellido);
            HttpContext.Session.SetInt32("Rol", usuario.Rol);

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        public IActionResult Integrantes()
        {
            return View();
        }

        public IActionResult Index()
        {
            int? rol = HttpContext.Session.GetInt32("Rol");

            if (rol == null)
                return RedirectToAction("Login");

            if (rol < 0 || rol > 2)
                return Forbid();

            var alumnos = _context.Alumnos.ToList();
            return View(alumnos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumno);
        }
        [HttpPost]
        public IActionResult Eliminar(int dni)
        {
            var alumno = _context.Alumnos.Find(dni);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            var alumno = _context.Alumnos.Find(id);
            if (alumno == null) return NotFound();
            return View(alumno);
        }

        [HttpPost]
        public IActionResult Editar(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Alumnos.Update(alumno);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

    }
}
