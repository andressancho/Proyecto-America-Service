using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Examen
    {
        private int id_examen { get; set; }
        private List<Pregunta> preguntas { get; set; }
        private double nota { get; set; }
        private int id_usuario { get; set; }
        private int tiempo { get; set; }

        public Examen(int id_examen, List<Pregunta> preguntas, double nota, int id_usuario, int tiempo)
        {
            this.id_examen = id_examen;
            this.preguntas = preguntas;
            this.nota = nota;
            this.id_usuario = id_usuario;
            this.tiempo = tiempo;
        }
    }
}