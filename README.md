POOI T2 – Gestión de Alumnos

Descripción
Proyecto académico de la Segunda Evaluación T2 del curso Programación Orientada a Objetos I. Aplicación web desarrollada en ASP.NET MVC con C# para gestionar alumnos mediante serialización y deserialización de datos en formato JSON.

Tecnologías
C#, ASP.NET MVC 5, .NET Framework, Visual Studio y Newtonsoft.Json.

Funcionalidades

Listado de alumnos.

Registro de alumnos con validación de DNI duplicado.

Consulta de detalles.

Actualización de datos con validación de DNI.

Eliminación de alumnos por DNI.

Serialización y deserialización mediante Newtonsoft.Json.

Estructura principal
Models/Alumno.cs
Controllers/AlumnoController.cs
Views/Alumno/Index.cshtml
Views/Alumno/Agregar.cshtml
Views/Alumno/Detalles.cshtml
Views/Alumno/Actualizar.cshtml

Almacenamiento
La colección se inicializa como un string JSON dentro de AlumnoController mediante static string lista = @"[]". La información se deserializa temporalmente para realizar las operaciones y luego se vuelve a serializar.

Ejecución
Abrir la solución en Visual Studio, compilar el proyecto y ejecutar la aplicación. El controlador principal se encuentra en /Alumno.

Autor
Josue Torres Venero
