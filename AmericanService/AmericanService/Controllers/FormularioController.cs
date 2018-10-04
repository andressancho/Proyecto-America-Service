using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using AmericanService.Models;
using System.Web.Configuration;

namespace AmericanService.Controllers
{
    public class FormularioController : Controller
    {
        // GET: Formulario
        public ActionResult Index()
        {
            return View(obtener_formularios());
        }

        public List<Formulario> obtener_formularios()
        {
            SqlConnection con = new SqlConnection(
               WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


            SqlCommand cmd = new SqlCommand("obtener_formularios", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            String cedula;
            String nombre = "";
            String descripcion = "";
            DateTime fecha;
            List<Formulario> lista_formularios = new List<Formulario>();

            while (dr.Read())
            {
                cedula = Convert.ToString(dr["cedula"]);
                nombre = Convert.ToString(dr["nombre"]);
                fecha = Convert.ToDateTime(dr["fecha"]);
                lista_formularios.Add(new Formulario(cedula, nombre, fecha));
            }

            //foreach (Historico h in lista_historico) {
            //    Response.Write(h.nombre);
            //}
            con.Close();
            return lista_formularios;
        }
    }
}