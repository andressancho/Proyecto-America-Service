using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Pregunta
    {
        private int id_pregunte { get; set; }
        private string enunciado { get; set; }
        private string correcta { get; set; }
        private List<string> incorrectas { get; set; }
        private string tema { get; set; }

        public Pregunta(int id_pregunte, string enunciado, string correcta, List<string> incorrectas, string tema)
        {
            this.id_pregunte = id_pregunte;
            this.enunciado = enunciado;
            this.correcta = correcta;
            this.incorrectas = incorrectas;
            this.tema = tema;
        }
    }
}