using System;
using System.Linq;
using DataBaseTry.Models;

namespace DataBaseTry.Models
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Crear Institución de ejemplo si no existe
            if (!context.Instituciones.Any())
            {
                context.Instituciones.Add(new Institucion
                {
                    Id = 1,
                    Nombre = "Universidad de Prueba",
                    Direccion = "Calle Falsa 123",
                    Telefono = "555-0000",
                    Email = "info@uni.edu",
                    CodigoInstitucion = "86878"
                });
                context.SaveChanges();
            }

            // Obtener el Id de la institución creada
            var institucionId = context.Instituciones.First().Id;

            if (!context.Usuarios.Any())
            {
                var usuario1 = new Usuario
                {
                    Correo = "profesor1@uni.edu",
                    Contraseña = "hashedpass1",
                    InstitucionId = institucionId,
                    Rol = 1,
                    Nombre = "Ana",
                    Apellido = "García",
                    Activo = true,
                    FechaRegistro = new DateTime(2024, 5, 1, 10, 0, 0)
                };
                var usuario2 = new Usuario
                {
                    Correo = "admin@uni.edu",
                    Contraseña = "hashedpass2",
                    InstitucionId = institucionId,
                    Rol = 2,
                    Nombre = "Luis",
                    Apellido = "Pérez",
                    Activo = true,
                    FechaRegistro = new DateTime(2024, 5, 2, 9, 30, 0)
                };
                var usuario3 = new Usuario
                {
                    Correo = "alumno1@uni.edu",
                    Contraseña = "hashedpass3",
                    InstitucionId = institucionId,
                    Rol = 0,
                    Nombre = "Carlos",
                    Apellido = "López",
                    Activo = true,
                    FechaRegistro = new DateTime(2024, 5, 3, 8, 45, 0)
                };
                context.Usuarios.AddRange(usuario1, usuario2, usuario3);
                context.SaveChanges();
            }

            // Datos de ejemplo para Alumno
            if (!context.Alumnos.Any())
            {
                context.Alumnos.AddRange(
                    new Alumno
                    {
                        Dni = 12345678,
                        Nombre = "Carlos",
                        Apellido = "López",
                        FechaNacimiento = new DateTime(2002, 4, 15),
                        Correo = "alumno1@uni.edu",
                        Direccion = "Calle 123",
                        NumeroContacto = "555-1234"
                    },
                    new Alumno
                    {
                        Dni = 87654321,
                        Nombre = "María",
                        Apellido = "Fernández",
                        FechaNacimiento = new DateTime(2001, 9, 22),
                        Correo = "alumno2@uni.edu",
                        Direccion = "Av. Central 456",
                        NumeroContacto = "555-5678"
                    }
                );
                context.SaveChanges();
            }

            // Datos de ejemplo para Curso
            if (!context.Cursos.Any())
            {
                context.Cursos.AddRange(
                    new Curso { Id = 1, Nombre = "Matemática I", CodigoInstitucion = "86878" },
                    new Curso { Id = 2, Nombre = "Programación", CodigoInstitucion = "86878" }
                );
                context.SaveChanges();
            }

            // Datos de ejemplo para Seccion
            if (!context.Secciones.Any())
            {
                context.Secciones.AddRange(
                    new Seccion { Id = 1, Nombre = "Sección A", CursoId = 1, ProfesorId = 1 },
                    new Seccion { Id = 2, Nombre = "Sección B", CursoId = 2, ProfesorId = 1 }
                );
                context.SaveChanges();
            }

            // Datos de ejemplo para Inscripcion
            if (!context.Inscripciones.Any())
            {
                context.Inscripciones.AddRange(
                    new Inscripcion { Id = 1, AlumnoId = 3, SeccionId = 1 },
                    new Inscripcion { Id = 2, AlumnoId = 3, SeccionId = 2 }
                );
                context.SaveChanges();
            }

            // Datos de ejemplo para Material
            if (!context.Materiales.Any())
            {
                context.Materiales.AddRange(
                    new Material
                    {
                        Id = 1,
                        Titulo = "Guía de ejercicios",
                        Descripcion = "Ejercicios semana 1",
                        FilePath = "materiales/1/guia1.pdf",
                        FechaSubida = new DateTime(2024, 5, 10, 12, 0, 0),
                        SeccionId = 1,
                        UploadedById = 1
                    },
                    new Material
                    {
                        Id = 2,
                        Titulo = "Apuntes",
                        Descripcion = "Resumen de la clase",
                        FilePath = "materiales/2/apuntes.pdf",
                        FechaSubida = new DateTime(2024, 5, 11, 14, 30, 0),
                        SeccionId = 2,
                        UploadedById = 1
                    }
                );
                context.SaveChanges();
            }
            // Puedes agregar aquí datos de ejemplo para otras tablas si lo deseas
        }
    }
}
