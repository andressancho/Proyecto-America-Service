using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Mecanografia
    {
        private int id_mecanografia { get; set; }
        private string texto { get; set; }
        private string respuesta { get; set; }
        private double nota { get; set; }

        public Mecanografia(int id_mecanografia, string texto, string respuesta, double nota)
        {
            this.id_mecanografia = id_mecanografia;
            this.texto = texto;
            this.respuesta = respuesta;
            this.nota = nota;
        }
    }
}