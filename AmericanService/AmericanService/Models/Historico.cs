using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Historico
    {
        public String cedula { get; set; }
        public String primer_nombre { get; set; }
        public String segundo_nombre { get; set; }
        public String primer_apellido { get; set; }
        public String segundo_apellido { get; set; }
        public String descripcion { get; set; }
        public DateTime fecha { get; set; }
        public String cantidad { get; set; }

        public Historico(String cedula, String primer_nombre, String segundo_nombre, String primer_apellido, String segundo_apellido, String descripcion, DateTime fecha, String cantidad) {
            this.cedula = cedula;
            this.primer_nombre = primer_nombre;
            this.segundo_nombre = segundo_nombre;
            this.primer_apellido = primer_apellido;
            this.segundo_apellido = segundo_apellido;
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.cantidad = cantidad;
        }
        public Historico()
        {
        }
    }
}