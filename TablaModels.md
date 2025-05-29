# Modelado de Tablas y Relaciones

Este documento describe las tablas principales del sistema (modelos en la carpeta `Models/`), sus relaciones y el uso de
cada una en el contexto de una intranet educativa.

## 1. Usuario

- **Descripción:** Representa a los usuarios del sistema (alumnos, profesores y administradores).
- **Campos principales:** Correo, Contraseña, Institución, Rol, Nombre, Apellido, Activo, FechaRegistro.
- **Relaciones:**
    - Un usuario puede ser profesor de varias secciones (`SeccionesComoProfesor`).
    - Un usuario puede subir varios materiales (`MaterialesSubidos`).
- **Uso:** Control de acceso, autenticación y gestión de roles.

## 2. Seccion

- **Descripción:** Representa una sección específica de un curso.
- **Campos principales:** Nombre, CursoId, ProfesorId.
- **Relaciones:**
    - Pertenece a un curso (`Curso`).
    - Tiene un profesor asignado (`Profesor`, que es un `Usuario`).
    - Puede tener varias inscripciones de alumnos (`Inscripciones`).
    - Puede tener varios materiales asociados (`Materiales`).
- **Uso:** Organización de clases y asignación de profesores y alumnos.

## 3. Curso

- **Descripción:** Representa un curso académico general.
- **Campos principales:** Nombre, CodigoInstitucion.
- **Relaciones:**
    - Un curso puede tener varias secciones (`Secciones`).
- **Uso:** Agrupación de secciones bajo un mismo curso.

## 4. Material

- **Descripción:** Representa materiales educativos subidos al sistema.
- **Campos principales:** Título, Descripción, FilePath, FechaSubida, SeccionId, UploadedById.
- **Relaciones:**
    - Pertenece a una sección (`Seccion`).
    - Subido por un usuario (`UploadedBy`).
- **Uso:** Compartir recursos y materiales educativos con los alumnos.

## 5. Inscripcion

- **Descripción:** Relaciona a los alumnos con las secciones en las que están inscritos.
- **Relaciones:**
    - Relaciona un usuario (alumno) con una sección.
- **Uso:** Control de matrícula y acceso a materiales/secciones.

---

### Resumen de Relaciones

- **Usuario** ←→ **Seccion** (como profesor)
- **Usuario** ←→ **Material** (como autor)
- **Seccion** ←→ **Curso**
- **Seccion** ←→ **Material**
- **Seccion** ←→ **Inscripcion** ←→ **Usuario** (como alumno)

Este modelado permite gestionar usuarios, cursos, secciones, materiales y la inscripción de alumnos en un entorno tipo
intranet educativa.
