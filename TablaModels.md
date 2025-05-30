# Modelado de Tablas y Relaciones (Actualizado 2025)

Este documento describe las tablas principales del sistema (modelos en la carpeta `Models/`), sus relaciones y el uso de cada una en el contexto de una intranet educativa.

## 1. Usuario
- **Descripción:** Usuarios del sistema (alumnos, profesores y administradores).
- **Campos principales:** Correo, Contraseña, Institución, Rol, Nombre, Apellido, Activo, FechaRegistro.
- **Relaciones:**
    - Un usuario puede ser profesor (relación 1 a 1 con `Profesor` si Rol=1).
    - Un usuario puede ser alumno (relación 1 a 1 con `Alumno` si Rol=0).
    - Un usuario puede subir materiales (`MaterialesSubidos`).
    - Un usuario puede estar inscrito en secciones (`InscripcionesComoAlumno`).
- **Uso:** Control de acceso, autenticación y gestión de roles.

## 2. Profesor
- **Descripción:** Información adicional de los profesores.
- **Campos principales:** UsuarioId (FK a Usuario), Id (PK).
- **Relaciones:**
    - Relación uno a uno con `Usuario` (solo para usuarios con Rol=1).
    - Un profesor puede estar asignado a varias secciones.
- **Uso:** Permite almacenar datos exclusivos de profesores y distinguirlos explícitamente.

## 3. Alumno
- **Descripción:** Información adicional de los alumnos.
- **Campos principales:** Dni, Nombre, Apellido, FechaNacimiento, Correo, Direccion, NumeroContacto.
- **Relaciones:**
    - Relación uno a uno con `Usuario` (solo para usuarios con Rol=0).
    - Un alumno puede estar inscrito en varias secciones.
- **Uso:** Permite almacenar datos exclusivos de alumnos.

## 4. Curso
- **Descripción:** Representa un curso académico general.
- **Campos principales:** Nombre, CodigoInstitucion, InstitucionId.
- **Relaciones:**
    - Un curso puede tener varias secciones (`Secciones`).
- **Uso:** Agrupación de secciones bajo un mismo curso.

## 5. Seccion
- **Descripción:** Sección específica de un curso.
- **Campos principales:** Nombre, CursoId, ProfesorId.
- **Relaciones:**
    - Pertenece a un curso (`Curso`).
    - Tiene un profesor asignado (`Profesor`).
    - Puede tener varias inscripciones de alumnos (`Inscripciones`).
    - Puede tener varios materiales asociados (`Materiales`).
    - Puede tener varios horarios asociados (relación muchos a muchos con `Horario` a través de `SeccionHorario`).
- **Uso:** Organización de clases y asignación de profesores, alumnos y horarios.

## 6. Horario
- **Descripción:** Representa un bloque horario disponible para secciones.
- **Campos principales:** DiaSemana, HoraInicio, HoraFin.
- **Relaciones:**
    - Relación muchos a muchos con `Seccion` a través de `SeccionHorario`.
- **Uso:** Definir los horarios de las clases.

## 7. SeccionHorario
- **Descripción:** Tabla intermedia para la relación muchos a muchos entre `Seccion` y `Horario`.
- **Campos principales:** SeccionId, HorarioId.
- **Relaciones:**
    - FK a `Seccion` y a `Horario`.
- **Uso:** Permite asignar múltiples horarios a una sección y viceversa.

## 8. Inscripcion
- **Descripción:** Relaciona a los alumnos con las secciones en las que están inscritos.
- **Campos principales:** AlumnoId, SeccionId.
- **Relaciones:**
    - Relaciona un usuario (alumno) con una sección.
- **Uso:** Control de matrícula y acceso a materiales/secciones.

## 9. Material
- **Descripción:** Materiales educativos subidos al sistema.
- **Campos principales:** Título, Descripción, FilePath, FechaSubida, SeccionId, UploadedById.
- **Relaciones:**
    - Pertenece a una sección (`Seccion`).
    - Subido por un usuario (`UploadedBy`).
- **Uso:** Compartir recursos y materiales educativos con los alumnos.

## 10. Asistencia
- **Descripción:** Registra la asistencia de los alumnos a las secciones.
- **Campos principales:** Id, AlumnoId, SeccionId, Fecha, Estado.
- **Relaciones:**
    - Relaciona un alumno con una sección y una fecha específica.
- **Uso:** Control de asistencia de los alumnos.

---

### Resumen de Relaciones

- **Usuario** ←→ **Profesor** (1 a 1, si Rol=1)
- **Usuario** ←→ **Alumno** (1 a 1, si Rol=0)
- **Profesor** ←→ **Seccion** (1 a muchos)
- **Alumno** ←→ **Inscripcion** ←→ **Seccion** (muchos a muchos)
- **Seccion** ←→ **Curso** (muchos a 1)
- **Seccion** ←→ **Material** (1 a muchos)
- **Seccion** ←→ **SeccionHorario** ←→ **Horario** (muchos a muchos)
- **Asistencia**: une Alumno, Seccion y Fecha

Este modelado permite gestionar usuarios, profesores, alumnos, cursos, secciones, horarios, materiales, inscripciones y asistencia en un entorno educativo moderno.
