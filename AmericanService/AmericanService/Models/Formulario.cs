using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Formulario
    {
        public String nombre;
        public String cedula;
        public DateTime fecha;

        public Formulario(string nombre, string cedula, DateTime fecha)
        {
            this.nombre = nombre;
            this.cedula = cedula;
            this.fecha = fecha;
        }
    }
}