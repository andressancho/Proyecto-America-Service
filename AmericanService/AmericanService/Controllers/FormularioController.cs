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
        [HttpGet]
        public ActionResult Index()
        {
            return View(obtener_formularios());
        }
        [HttpPost]
        public ActionResult Index(string ventas)
        {
            return View(obtener_formularios());
        }

        public ActionResult Filtrar(int i)
        {

            return View("Index", filtrar_formularios(i));
        }

        public List<Formulario> filtrar_formularios(int i)
        {
            SqlConnection con = new SqlConnection(
               WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);
            SqlCommand cmd;

            if (i == 1)
            {
                cmd = new SqlCommand("obtener_por_exp_callcenter", con);
            }
            else if (i == 2)
            {
                cmd = new SqlCommand("obtener_por_exp_servicio_cliente", con);
            }
            else if (i == 3)
            {
                cmd = new SqlCommand("obtener_por_exp_cobros", con);
            }
            else if (i == 4)
            {
                cmd = new SqlCommand("obtener_por_exp_ventas", con);
            }
            else if (i == 5)
            {
                cmd = new SqlCommand("obtener_por_excel", con);
            }
            else if (i == 6)
            {
                cmd = new SqlCommand("obtener_por_excel", con);
            }
            else
            {
                cmd = new SqlCommand("obtener_bachillerato", con);
            }

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

            con.Close();
            return lista_formularios;
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