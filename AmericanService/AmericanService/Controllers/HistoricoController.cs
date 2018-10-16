using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Data.SqlClient;
using AmericanService.Models;

namespace AmericanService.Controllers
{
    public class HistoricoController : Controller
    {
        // GET: Historico
        public ActionResult Index()
        {
            
          return View(consulta_historico());
        }

        public List<Historico> consulta_historico() {
            SqlConnection con = new SqlConnection(
               WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


            SqlCommand cmd = new SqlCommand("obtener_historico_reclutandos", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            int cedula;
            String nombre = "";
            String descripcion = "";
            DateTime fecha;
            int cantidad;
            List<Historico> lista_historico = new List<Historico>();

            while (dr.Read())
            {
                cedula = Convert.ToInt32(dr["cedula"]);
                nombre = Convert.ToString(dr["nombre"]);
                descripcion = Convert.ToString(dr["descripcion"]);
                fecha = Convert.ToDateTime(dr["fecha"]);
                cantidad = Convert.ToInt32(dr["cantidad"]);
                lista_historico.Add(new Historico(cedula, nombre, descripcion, fecha, cantidad));
            }

            //foreach (Historico h in lista_historico) {
            //    Response.Write(h.nombre);
            //}
            con.Close();
            return lista_historico;
        }

        public ActionResult Find(string buscar_string) {
            int i;
            List<Historico> lista_historico_buscar = new List<Historico>();
            foreach (Historico h in consulta_historico()) {
                if (!String.IsNullOrEmpty(buscar_string)) {
                    if (int.TryParse(buscar_string, out i))
                    {
                        if (h.cedula == i)
                        {
                            lista_historico_buscar.Add(h);
                        }
                    }
                    else
                    {
                        if (h.nombre.Equals(buscar_string))
                        {
                            lista_historico_buscar.Add(h);    
                        }
                    }
                   
                }
            }
            return View("Index", lista_historico_buscar);
        }
        public ActionResult Edit(String cedula) {
            Response.Write(cedula);
            List<Historico> lista = new List<Historico>();
            return View("Index", lista);
        }

        
    }
}
