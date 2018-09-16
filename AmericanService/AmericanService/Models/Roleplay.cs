using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class Roleplay
    {
        private int id_roleplay { get; set; }
        private Usuario supervisor { get; set; }
        private DateTime fecha { get; set; }
        private string detalle { get; set; }
        private string visto_bueno { get; set; }

        public Roleplay(int id_roleplay, Usuario supervisor, DateTime fecha, string detalle, string visto_bueno)
        {
            this.id_roleplay = id_roleplay;
            this.supervisor = supervisor;
            this.fecha = fecha;
            this.detalle = detalle;
            this.visto_bueno = visto_bueno;
        }
    }
}