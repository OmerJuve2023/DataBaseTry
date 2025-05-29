```markdown
## Ejemplos de INSERT en SQLite para cada tabla

A continuación se muestran ejemplos de inserción de datos para las tablas principales del esquema actual, basados en las propiedades de los modelos C#.

---

### Tabla: Usuario

**Columnas:** Id, Correo, Contraseña, Institucion, Rol, Nombre, Apellido, Activo, FechaRegistro

- **Institucion:** Código numérico que identifica la institución a la que pertenece el usuario. Por ejemplo, `86878` corresponde a una institución específica (puedes consultar la tabla de instituciones para más detalles).
- **Rol:** Valor numérico que representa el tipo de usuario:
    - `0`: Alumno
    - `1`: Profesor
    - `2`: Administrador
- **Relaciones de navegación:**
    - Un usuario puede estar relacionado como profesor en varias secciones (`SeccionesComoProfesor`).
    - Un usuario puede tener varias inscripciones como alumno (`InscripcionesComoAlumno`).
    - Un usuario puede haber subido varios materiales (`MaterialesSubidos`).

Estos valores permiten distinguir el perfil y los permisos de cada usuario en el sistema.

```sql
INSERT INTO Usuario (Id, Correo, Contraseña, Institucion, Rol, Nombre, Apellido, Activo, FechaRegistro) VALUES
  (1, 'profesor1@uni.edu', 'hashedpass1', 86878, 1, 'Ana', 'García', 1, '2024-05-01 10:00:00'),
  (2, 'admin@uni.edu', 'hashedpass2', 86878, 2, 'Luis', 'Pérez', 1, '2024-05-02 09:30:00'),
  (3, 'alumno1@uni.edu', 'hashedpass3', 86878, 0, 'Carlos', 'López', 1, '2024-05-03 08:45:00');
```

---

### Tabla: Alumno

**Columnas:** Dni, Nombre, Apellido, FechaNacimiento, Correo, Direccion, NumeroContacto

```sql
INSERT INTO Alumno (Dni, Nombre, Apellido, FechaNacimiento, Correo, Direccion, NumeroContacto) VALUES
  (12345678, 'Carlos', 'López', '2002-04-15', 'alumno1@uni.edu', 'Calle 123', '555-1234'),
  (87654321, 'María', 'Fernández', '2001-09-22', 'alumno2@uni.edu', 'Av. Central 456', '555-5678');
```

---

### Tabla: Curso

**Columnas:** Id, Nombre, CodigoInstitucion

```sql
INSERT INTO Curso (Id, Nombre, CodigoInstitucion) VALUES
  (1, 'Matemática I', '86878'),
  (2, 'Programación', '86878');
```

---

### Tabla: Seccion

**Columnas:** Id, Nombre, CursoId, ProfesorId

- **ProfesorId** referencia a un usuario con rol profesor (relación de navegación `SeccionesComoProfesor`).

```sql
INSERT INTO Seccion (Id, Nombre, CursoId, ProfesorId) VALUES
  (1, 'Sección A', 1, 1),
  (2, 'Sección B', 2, 1);
```

---

### Tabla: Inscripcion

**Columnas:** Id, AlumnoId, SeccionId

- **AlumnoId** referencia a un usuario con rol alumno (relación de navegación `InscripcionesComoAlumno`).

```sql
INSERT INTO Inscripcion (Id, AlumnoId, SeccionId) VALUES
  (1, 3, 1),
  (2, 3, 2);
```

---

### Tabla: Material

**Columnas:** Id, Titulo, Descripcion, FilePath, FechaSubida, SeccionId, UploadedById

- **UploadedById** referencia a un usuario (relación de navegación `MaterialesSubidos`).

```sql
INSERT INTO Material (Id, Titulo, Descripcion, FilePath, FechaSubida, SeccionId, UploadedById) VALUES
  (1, 'Guía de ejercicios', 'Ejercicios semana 1', 'materiales/1/guia1.pdf', '2024-05-10 12:00:00', 1, 1),
  (2, 'Apuntes', 'Resumen de la clase', 'materiales/2/apuntes.pdf', '2024-05-11 14:30:00', 2, 1);
```

---

## Script SQL para listar tablas y contar registros

```sql
-- Listar todas las tablas
SELECT name FROM sqlite_master WHERE type='table';

-- Contar registros por tabla (ejemplo para varias tablas)
SELECT 'Usuario' AS tabla, COUNT(*) AS row_count FROM Usuario
UNION ALL
SELECT 'Alumno', COUNT(*) FROM Alumno
UNION ALL
SELECT 'Curso', COUNT(*) FROM Curso
UNION ALL
SELECT 'Seccion', COUNT(*) FROM Seccion
UNION ALL
SELECT 'Inscripcion', COUNT(*) FROM Inscripcion
UNION ALL
SELECT 'Material', COUNT(*) FROM Material;
```

---

## Guía paso a paso

1. **Identificar tablas vacías**
   - Ejecuta el script anterior para ver el número de registros por tabla.
   - Si `row_count` es 0, la tabla está vacía.

2. **Rellenar datos de ejemplo**
   - Usa los comandos `INSERT` anteriores para poblar las tablas vacías.
   - Puedes ejecutar estos scripts desde herramientas como **DB Browser for SQLite** o la **CLI de SQLite**.

3. **Automatizar generación de INSERTs**
   - Para tablas nuevas, sigue la convención de nombres y tipos de columnas de los modelos C#.
   - Puedes generar scripts automáticamente usando herramientas como:
     - **DB Browser for SQLite**: Exporta plantillas de datos.
     - **dotnet ef dbcontext scaffold**: Refresca el modelo si cambian las tablas.
     - **DBeaver**: Permite generar y ejecutar scripts SQL fácilmente.

---

## Herramientas recomendadas

- **DB Browser for SQLite**: Visualiza, edita y ejecuta SQL sobre `database.db`.
- **SQLite CLI**: Ejecuta scripts SQL desde la terminal.
- **DBeaver**: Cliente universal para bases de datos, útil para SQLite.
- **dotnet ef dbcontext scaffold**: Refresca los modelos C# si cambian las tablas en la base de datos.

---
```