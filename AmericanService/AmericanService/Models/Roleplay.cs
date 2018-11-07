using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Roleplay
    {
        public int id_roleplay { get; set; }
        public DateTime fecha { get; set; }
        public string detalle { get; set; }
        public string visto_bueno { get; set; }

        public Roleplay(int id_roleplay, DateTime fecha, string detalle, string visto_bueno)
        {
            this.id_roleplay = id_roleplay;
            this.fecha = fecha;
            this.detalle = detalle;
            this.visto_bueno = visto_bueno;
        }
        public Roleplay() {

        }
    }
}