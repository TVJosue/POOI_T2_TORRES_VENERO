using Newtonsoft.Json;
using POOI_T2_TORRES_VENERO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POOI_T2_TORRES_VENERO.Controllers
{
    public class AlumnoController : Controller
    {
        static string lista = @"[]";

        public ActionResult Index()
        {
            try
            {
                List<Alumno> temporal = JsonConvert.DeserializeObject<List<Alumno>>(lista);
                return View(temporal);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Alumno alumno)
        {
            try
            {
                // 1. Deserializar el string JSON
                List<Alumno> temporal =
                    JsonConvert.DeserializeObject<List<Alumno>>(lista);

                // 2. Verificar si el DNI ya existe
                Alumno alumnoEncontrado =
                    temporal.Find(a => a.dni == alumno.dni);

                // 3. Si el DNI ya existe, no se agrega
                if (alumnoEncontrado != null)
                {
                    ViewBag.Mensaje = "El DNI ya existe en la colección.";
                    return View(alumno);
                }

                // 4. Agregar el nuevo alumno
                temporal.Add(alumno);

                // 5. Serializar nuevamente la colección
                lista = JsonConvert.SerializeObject(temporal);

                ViewBag.Mensaje = "Alumno agregado correctamente.";

                return View(alumno);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(alumno);
            }
        }

        public ActionResult Eliminar(string dni)
        {
            try
            {
                // 1. Deserializar el string JSON
                List<Alumno> temporal =
                    JsonConvert.DeserializeObject<List<Alumno>>(lista);

                // 2. Buscar al alumno por DNI
                Alumno alumnoEncontrado =
                    temporal.Find(a => a.dni == dni);

                // 3. Verificar si existe
                if (alumnoEncontrado != null)
                {
                    // 4. Eliminar
                    temporal.Remove(alumnoEncontrado);

                    // 5. Serializar nuevamente
                    lista = JsonConvert.SerializeObject(temporal);
                }

                // 6. Regresar al Index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult Detalles(string dni)
        {
            try
            {
                // 1. Deserializar
                List<Alumno> temporal =
                    JsonConvert.DeserializeObject<List<Alumno>>(lista);

                // 2. Buscar por DNI
                Alumno alumnoEncontrado =
                    temporal.Find(a => a.dni == dni);

                // 3. Si no existe
                if (alumnoEncontrado == null)
                {
                    ViewBag.Mensaje = "Alumno no encontrado.";
                    return View();
                }

                // 4. Enviar el alumno a la vista
                return View(alumnoEncontrado);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }
        public ActionResult Actualizar(string dni)
        {
            try
            {
                // 1. Deserializar
                List<Alumno> temporal =
                    JsonConvert.DeserializeObject<List<Alumno>>(lista);

                // 2. Buscar alumno
                Alumno alumnoEncontrado =
                    temporal.Find(a => a.dni == dni);

                // 3. Verificar existencia
                if (alumnoEncontrado == null)
                {
                    ViewBag.Mensaje = "Alumno no encontrado.";
                    return View();
                }

                // 4. Enviar alumno a la vista
                return View(alumnoEncontrado);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Actualizar(string dniOriginal, Alumno alumno)
        {
            try
            {
                // 1. Deserializar el string JSON
                List<Alumno> temporal =
                    JsonConvert.DeserializeObject<List<Alumno>>(lista);

                // 2. Buscar el alumno original
                Alumno alumnoOriginal =
                    temporal.Find(a => a.dni == dniOriginal);

                // 3. Verificar que el alumno exista
                if (alumnoOriginal == null)
                {
                    ViewBag.Mensaje = "El alumno no existe.";
                    return View(alumno);
                }

                // 4. Verificar si el nuevo DNI pertenece
                //    a otro alumno
                Alumno dniRepetido =
                    temporal.Find(a => a.dni == alumno.dni &&
                                      a.dni != dniOriginal);

                if (dniRepetido != null)
                {
                    ViewBag.Mensaje =
                        "El nuevo DNI ya pertenece a otro alumno.";

                    return View(alumno);
                }

                // 5. Buscar la posición del alumno
                int posicion =
                    temporal.FindIndex(a => a.dni == dniOriginal);

                // 6. Actualizar el objeto
                temporal[posicion] = alumno;

                // 7. Serializar nuevamente
                lista = JsonConvert.SerializeObject(temporal);

                ViewBag.Mensaje =
                    "Alumno actualizado correctamente.";

                return View(alumno);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(alumno);
            }
        }
    }
}