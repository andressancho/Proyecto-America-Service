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
        public int id_roleplay;
        public bool jornada_diurna;
        public bool jornada_mixta;
        public bool jornada_nocturna;
        public String justificacion_jornada;
        public DateTime fecha;
        public double salario;
        public int telefono;
        public String correo;
        public String domicilio;
        public bool exp_call_center;
        public bool exp_ventas;
        public bool exp_servicio_cliente;
        public String detalle_experiencias;
        public bool exp_cobros;
        public bool exp_mora30;
        public bool exp_mora60;
        public bool exp_mora90;
        public bool exp_cartera_separada;
        public bool exp_cobro_judicial;
        public String detalle_exp_cobros;
        public bool excel;
        public bool bachillerato;
        public int id_formulario;
        public Roleplay roleplay;


        public Formulario(String primer_nombre, String segundo_nombre, String primer_apellido, String segundo_apellido, String cedula, DateTime fecha, int id_formulario)
        {
            this.primer_nombre = primer_nombre;
            this.segundo_nombre = segundo_nombre;
            this.primer_apellido = primer_apellido;
            this.segundo_apellido = segundo_apellido;
            this.cedula = cedula;
            this.fecha = fecha;
            this.id_formulario = id_formulario;
        }

        public Formulario(int id_formulario, String cedula, String primer_nombre, String segundo_nombre, String primer_apellido, String segundo_apellido, int id_roleplay, bool jornada_diurna, bool jornada_mixta, bool jornada_nocturna, String justificacion_jornada, DateTime fecha, double salario, int telefono, String correo, String domicilio, bool exp_call_center, bool exp_ventas, bool exp_servicio_cliente, String detalle_experiencias, bool exp_cobros, bool exp_mora30, bool exp_mora60, bool exp_mora90, bool exp_cartera_separada,bool exp_cobro_judicial, String detalle_exp_cobros, bool excel, bool bachillerato, Roleplay roleplay) {
            this.id_formulario = id_formulario;
            this.cedula = cedula;
            this.primer_nombre = primer_nombre;
            this.segundo_nombre = segundo_nombre;
            this.primer_apellido = primer_apellido;
            this.segundo_apellido = segundo_apellido;
            this.id_roleplay = id_roleplay;
            this.jornada_diurna = jornada_diurna;
            this.jornada_mixta = jornada_mixta;
            this.jornada_nocturna = jornada_nocturna;
            this.justificacion_jornada = justificacion_jornada;
            this.fecha = fecha;
            this.salario = salario;
            this.telefono = telefono;
            this.correo = correo;
            this.domicilio = domicilio;
            this.exp_call_center = exp_call_center;
            this.exp_ventas = exp_ventas;
            this.exp_servicio_cliente = exp_servicio_cliente;
            this.detalle_experiencias = detalle_experiencias;
            this.exp_cobros = exp_cobros;
            this.exp_mora30 = exp_mora30;
            this.exp_mora60 = exp_mora60;
            this.exp_mora90 = exp_mora90;
            this.exp_cartera_separada = exp_cartera_separada;
            this.exp_cobro_judicial = exp_cobro_judicial;
            this.detalle_exp_cobros = detalle_exp_cobros;
            this.excel = excel;
            this.bachillerato = bachillerato;
            this.roleplay = roleplay;
        }

        public Formulario() {
        }
    }
}