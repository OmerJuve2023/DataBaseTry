using DataBaseTry.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Features; // filepath: d:\DataBaseTry\Program.cs

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar el límite de tamaño de archivos subidos
builder.Services.Configure<FormOptions>(options => {
    options.MultipartBodyLengthLimit = 50 * 1024 * 1024; // 50 MB
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");


// Seed de datos iniciales
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();

    // Institución
    if (!context.Instituciones.Any())
    {
        var institucion = new Institucion
        {
            Nombre = "Instituto Demo",
            CodigoInstitucion = "86878",
            Direccion = "Av. Principal 123",
            Telefono = "555-1234",
            Email = "info@demo.edu"
        };
        context.Instituciones.Add(institucion);
        context.SaveChanges();
    }
    var inst = context.Instituciones.First();

    // Usuarios
    if (!context.Usuarios.Any())
    {
        var admin = new Usuario
        {
            Correo = "admin@demo.com",
            Contraseña = "admin123",
            InstitucionId = inst.Id,
            Rol = 2,
            Nombre = "Admin",
            Apellido = "Demo",
            Activo = true
        };
        var profesor = new Usuario
        {
            Correo = "profesor@demo.com",
            Contraseña = "prof123",
            InstitucionId = inst.Id,
            Rol = 1,
            Nombre = "Ana",
            Apellido = "García",
            Activo = true
        };
        var alumno = new Usuario
        {
            Correo = "alumno@demo.com",
            Contraseña = "alum123",
            InstitucionId = inst.Id,
            Rol = 0,
            Nombre = "Carlos",
            Apellido = "López",
            Activo = true
        };
        context.Usuarios.AddRange(admin, profesor, alumno);
        context.SaveChanges();
    }
    var prof = context.Usuarios.FirstOrDefault(u => u.Rol == 1);
    var alum = context.Usuarios.FirstOrDefault(u => u.Rol == 0);

    // Curso
    if (!context.Cursos.Any())
    {
        var curso = new Curso
        {
            Nombre = "Matemática I",
            CodigoInstitucion = inst.CodigoInstitucion,
            InstitucionId = inst.Id
        };
        context.Cursos.Add(curso);
        context.SaveChanges();
    }
    var curso1 = context.Cursos.First();

    // Sección
    if (!context.Secciones.Any())
    {
        var seccion = new Seccion
        {
            Nombre = "Sección A",
            CursoId = curso1.Id,
            ProfesorId = prof.Id
        };
        context.Secciones.Add(seccion);
        context.SaveChanges();
    }
    var seccion1 = context.Secciones.First();

    // Material
    if (!context.Materiales.Any())
    {
        var material = new Material
        {
            Titulo = "Guía de ejercicios 1",
            Descripcion = "Ejercicios introductorios",
            FilePath = "materiales/1/guia1.pdf",
            FechaSubida = DateTime.Now,
            SeccionId = seccion1.Id,
            UploadedById = prof.Id
        };
        context.Materiales.Add(material);
        context.SaveChanges();
    }
    var material1 = context.Materiales.First();

    // Inscripción
    if (!context.Inscripciones.Any())
    {
        var insc = new Inscripcion
        {
            AlumnoId = alum.Id,
            SeccionId = seccion1.Id
        };
        context.Inscripciones.Add(insc);
        context.SaveChanges();
    }

    // Notificación
    if (!context.Notificaciones.Any())
    {
        var notif = new Notificacion
        {
            UsuarioId = alum.Id,
            Titulo = "Bienvenido",
            Mensaje = "Te has inscrito en Matemática I",
            Fecha = DateTime.Now,
            Leido = false
        };
        context.Notificaciones.Add(notif);
        context.SaveChanges();
    }

    // ComentarioMaterial
    if (!context.ComentariosMaterial.Any())
    {
        var comentario = new ComentarioMaterial
        {
            MaterialId = material1.Id,
            UsuarioId = alum.Id,
            Texto = "¡Gracias por el material!",
            Fecha = DateTime.Now
        };
        context.ComentariosMaterial.Add(comentario);
        context.SaveChanges();
    }

    // HistorialAccesoMaterial
    if (!context.HistorialesAccesoMaterial.Any())
    {
        var acceso = new HistorialAccesoMaterial
        {
            MaterialId = material1.Id,
            UsuarioId = alum.Id,
            FechaAcceso = DateTime.Now
        };
        context.HistorialesAccesoMaterial.Add(acceso);
        context.SaveChanges();
    }
}

app.Run();
