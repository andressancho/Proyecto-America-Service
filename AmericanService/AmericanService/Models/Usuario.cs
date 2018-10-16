using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Usuario
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public string estado { get; set; }
        public string desempeno { get; set; }
        public string supervisor { get; set; }
        public string usuario { get; set; }

        public Usuario(string cedula, string nombre, string apellidos, DateTime fecha_nacimiento, DateTime fecha_ingreso, string estado, string desempeno, string supervisor)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fecha_nacimiento = fecha_nacimiento;
            this.fecha_ingreso = fecha_ingreso;
            this.estado = estado;
            this.desempeno = desempeno;
            this.supervisor = supervisor;
        }

        public Usuario() {
        }
        public Usuario(string cedula, string nombre, string apellidos, DateTime fecha_nacimiento, DateTime fecha_ingreso, string estado, string usuario)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fecha_nacimiento = fecha_nacimiento;
            this.fecha_ingreso = fecha_ingreso;
            this.estado = estado;
            this.usuario = usuario;
        }
    }
}