using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Historico
    {
        public int cedula { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public DateTime fecha { get; set; }
        public int cantidad { get; set; }

        public Historico(int cedula, String nombre, String descripcion, DateTime fecha, int cantidad) {
            this.cedula = cedula;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.cantidad = cantidad;
        }
    }
}