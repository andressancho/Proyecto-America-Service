using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace AmericanService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(string userid, string pwd) //Formal Parameters  
        {
            string username = userid;
            string password = pwd;

            SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


            SqlCommand cmd = new SqlCommand("iniciar_sesion", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", username);
            cmd.Parameters.AddWithValue("@contrasena", password);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();



            bool exito = false;
            string nombre = "";
            string apellidos = "";

            while (dr.Read())
            {
                exito = true;
                nombre = Convert.ToString(dr["nombre"]);
                apellidos = Convert.ToString(dr["apellidos"]);
            }
            con.Close();

            if (exito)
            {
                Response.Write(" <h2> Bienvenido </h2>" + nombre + " " + apellidos);
                return View("Contact");
            }
            else
            {

                return View("Index");
            }
            return View("Index");
        }
    }
}