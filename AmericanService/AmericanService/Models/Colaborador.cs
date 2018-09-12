using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Colaborador : Usuario
    {
        public Colaborador(int cedula, string nombre, string apellidos, DateTime fecha_nacimiento) : base(cedula, nombre, apellidos, fecha_nacimiento)
        {
        }

        public Usuario supervisor { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public char estado { get; set; }
        public string proyecto { get; set; }
        public double desempeño_prueba { get; set; }
        public double desempeño { get; set; }


    }
}