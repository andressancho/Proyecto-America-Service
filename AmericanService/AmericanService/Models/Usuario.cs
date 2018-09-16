using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Usuario
    {
        private int cedula { get; set; }
        private string nombre { get; set; }
        private string apellidos { get; set; }
        private DateTime fecha_nacimiento { get; set; }

        public Usuario(int cedula, string nombre, string apellidos, DateTime fecha_nacimiento)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fecha_nacimiento = fecha_nacimiento;
        }
    }
}