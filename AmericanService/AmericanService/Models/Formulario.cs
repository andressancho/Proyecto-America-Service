using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Formulario
    {
        private int id_form { get; set; }
        private int id_usuario { get; set; }
        private string jornada { get; set; }
        private string porque { get; set; }
        private int horario { get; set; }
        private DateTime fecha { get; set; }
        private double salario { get; set; }
        private DateTime fecha_nacimiento { get; set; }
        private string domicilio { get; set; }
        private bool exp_call_center { get; set; }
        private string detalle_exp_call_center { get; set; }
        private bool exp_cobro_judicial { get; set; }
        private string detalle_exp_cobro_judicial { get; set; }
        private bool excel { get; set; }
        private bool bachillerato { get; set; }
        private List<String> valores { get; set; }
        private List<String> competencias { get; set; }
        private string visto_bueno { get; set; }
        private Roleplay roleplay { get; set; }
        private Mecanografia meca { get; set; }

        public Formulario(int id_form, int id_usuario, string jornada, string porque, int horario, DateTime fecha, double salario, DateTime fecha_nacimiento, string domicilio, bool exp_call_center, string detalle_exp_call_center, bool exp_cobro_judicial, string detalle_exp_cobro_judicial, bool excel, bool bachillerato, List<string> valores, List<string> competencias, string visto_bueno, Roleplay roleplay, Mecanografia meca)
        {
            this.id_form = id_form;
            this.id_usuario = id_usuario;
            this.jornada = jornada;
            this.porque = porque;
            this.horario = horario;
            this.fecha = fecha;
            this.salario = salario;
            this.fecha_nacimiento = fecha_nacimiento;
            this.domicilio = domicilio;
            this.exp_call_center = exp_call_center;
            this.detalle_exp_call_center = detalle_exp_call_center;
            this.exp_cobro_judicial = exp_cobro_judicial;
            this.detalle_exp_cobro_judicial = detalle_exp_cobro_judicial;
            this.excel = excel;
            this.bachillerato = bachillerato;
            this.valores = valores;
            this.competencias = competencias;
            this.visto_bueno = visto_bueno;
            this.roleplay = roleplay;
            this.meca = meca;
        }
    }
}