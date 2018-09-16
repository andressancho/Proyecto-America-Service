using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Colaborador : Usuario
    {


        public Colaborador(Usuario supervisor, DateTime fecha_ingreso, char estado, string proyecto, double desempeño_prueba, double desempeño , int cedula, string nombre, string apellidos, DateTime fecha_nacimiento) : base(cedula, nombre, apellidos, fecha_nacimiento)
        {
            this.supervisor = supervisor;
            this.fecha_ingreso = fecha_ingreso;
            this.estado = estado;
            this.proyecto = proyecto;
            this.desempeño_prueba = desempeño_prueba;
            this.desempeño = desempeño;
        }

        private Usuario supervisor { get; set; }
        private DateTime fecha_ingreso { get; set; }
        private char estado { get; set; }
        private string proyecto { get; set; }
        private double desempeño_prueba { get; set; }
        private double desempeño { get; set; }


    }
}