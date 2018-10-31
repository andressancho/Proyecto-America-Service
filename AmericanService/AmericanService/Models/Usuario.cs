using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Usuario
    {
        public string cedula { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public string estado { get; set; }
        public string desempeno { get; set; }
        public string supervisor { get; set; }
        public string usuario { get; set; }
        public string tipo { get; set; }

        public Usuario(string cedula, string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, DateTime fecha_nacimiento, DateTime fecha_ingreso, string estado, string desempeno, string supervisor, string tipo)
        {
            this.cedula = cedula;
            this.primer_nombre = primer_nombre;
            this.segundo_nombre = segundo_nombre;
            this.primer_apellido = primer_apellido;
            this.segundo_apellido = segundo_apellido;
            this.fecha_nacimiento = fecha_nacimiento;
            this.fecha_ingreso = fecha_ingreso;
            this.estado = estado;
            this.desempeno = desempeno;
            this.supervisor = supervisor;
            this.tipo = tipo;
        }

        public Usuario() {
        }
        public Usuario(string cedula, string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, DateTime fecha_nacimiento, string supervisor, DateTime fecha_ingreso, string estado, string tipo, string usuario)
        {
            this.cedula = cedula;
            this.primer_nombre = primer_nombre;
            this.segundo_nombre = segundo_nombre;
            this.primer_apellido = primer_apellido;
            this.segundo_apellido = segundo_apellido;
            this.fecha_nacimiento = fecha_nacimiento;
            this.fecha_ingreso = fecha_ingreso;
            this.estado = estado;
            this.tipo = tipo;
            this.usuario = usuario;
            this.supervisor = supervisor;
        }
    }
}