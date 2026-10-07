using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POOI_T2_TORRES_VENERO.Models
{
    public class Alumno
    {
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string carrera { get; set; }
        public int ciclo { get; set; }

        public Alumno()
        { }

        public Alumno(string dni, string nombre, string apellido, string carrera, int ciclo)
        {
            this.dni = dni;
            this.nombres = nombre;
            this.apellidos = apellido;
            this.carrera = carrera;
            this.ciclo = ciclo;
        }
    }
}