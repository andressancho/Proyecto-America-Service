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

        public ActionResult Eliminar(String cedula)
        {
            SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


            SqlCommand cmd = new SqlCommand("eliminar_formulario", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cedula", cedula);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            con.Close();
            return View("Index", obtener_formularios());
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
            String primer_nombre = "";
            String segundo_nombre = "";
            String primer_apellido = "";
            String segundo_apellido = "";
            //String descripcion = "";
            DateTime fecha;
            List<Formulario> lista_formularios = new List<Formulario>();

            while (dr.Read())
            {
                cedula = Convert.ToString(dr["cedula"]);
                primer_nombre = Convert.ToString(dr["primer_nombre"]);
                segundo_nombre = Convert.ToString(dr["segundo_nombre"]);
                primer_apellido = Convert.ToString(dr["primer_apellido"]);
                segundo_apellido = Convert.ToString(dr["segundo_apellido"]);
                fecha = Convert.ToDateTime(dr["fecha"]);
                lista_formularios.Add(new Formulario(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, cedula, fecha));
            }

            con.Close();
            return lista_formularios;
        }


        public List<Formulario> obtener_formularios()
        {
            List<Formulario> lista_formularios = new List<Formulario>();
            try
            {
                SqlConnection con = new SqlConnection(
               WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);

                SqlCommand cmd = new SqlCommand("obtener_formularios", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                String cedula;
                String primer_nombre = "";
                String segundo_nombre = "";
                String primer_apellido = "";
                String segundo_apellido = "";
                //String descripcion = "";
                DateTime fecha;


                while (dr.Read())
                {
                    cedula = Convert.ToString(dr["cedula"]);
                    primer_nombre = Convert.ToString(dr["primer_nombre"]);
                    segundo_nombre = Convert.ToString(dr["segundo_nombre"]);
                    primer_apellido = Convert.ToString(dr["primer_apellido"]);
                    segundo_apellido = Convert.ToString(dr["segundo_apellido"]);
                    fecha = Convert.ToDateTime(dr["fecha"]);
                    lista_formularios.Add(new Formulario(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, cedula, fecha));
                }

                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            


            
            return lista_formularios;
        }
    }
}