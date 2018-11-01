using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Formulario
    {
        public String primer_nombre { get; set; }
        public String segundo_nombre { get; set; }
        public String primer_apellido { get; set; }
        public String segundo_apellido { get; set; }
        public String cedula;
        public DateTime fecha;

        public Formulario(String primer_nombre, String segundo_nombre, String primer_apellido, String segundo_apellido, String cedula, DateTime fecha)
        {
            this.primer_nombre = primer_nombre;
            this.segundo_nombre = segundo_nombre;
            this.primer_apellido = primer_apellido;
            this.segundo_apellido = segundo_apellido;
            this.cedula = cedula;
            this.fecha = fecha;
        }
    }
}