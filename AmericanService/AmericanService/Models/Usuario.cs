using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Usuario
    {
        public int cedula { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fecha_nacimiento { get; set; }

        public Usuario(int cedula, string nombre, string apellidos, DateTime fecha_nacimiento)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fecha_nacimiento = fecha_nacimiento;
        }
    }
}