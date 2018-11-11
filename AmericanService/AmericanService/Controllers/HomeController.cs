using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Data.SqlClient;
using AmericanService.Models;
using System.Web.SessionState;

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

<<<<<<< HEAD
            
            
=======
           
>>>>>>> 76e90664fc632de1ab84053612fc00fa736c7d63

            try
            {
                SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("iniciar_sesion", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", username);
                cmd.Parameters.AddWithValue("@contrasena", password);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                Usuario usuario = new Usuario();
                bool exito = false;
                string primer_nombre = "";
                string segundo_nombre = "";
                string primer_apellido = "";
                string segundo_apellido = "";
                DateTime fecha_nacimiento;
                DateTime fecha_ingreso;
                string cedula = "";
                string estado = "";
                string desempeno = "";
                string supervisor = "";
                string tipo = "";
                int productividad, pruebas, habilidades_blandas;

                while (dr.Read())
                {
                    exito = true;
                    cedula = Convert.ToString(dr["cedula"]);
                    primer_nombre = Convert.ToString(dr["primer_nombre"]);
                    segundo_nombre = Convert.ToString(dr["segundo_nombre"]);
                    primer_apellido = Convert.ToString(dr["primer_apellido"]);
                    segundo_apellido = Convert.ToString(dr["segundo_apellido"]);
                    fecha_nacimiento = Convert.ToDateTime(dr["cumpleanos"]);
                    fecha_ingreso = Convert.ToDateTime(dr["fecha_ingreso"]);
                    estado = Convert.ToString(dr["estado"]);
                    desempeno = Convert.ToString(dr["desempeno"]);
                    productividad = Convert.ToInt32(dr["productividad"]);
                    pruebas = Convert.ToInt32(dr["pruebas"]);
                    habilidades_blandas = Convert.ToInt32(dr["habilidades_blandas"]);
                    supervisor = Convert.ToString(dr["supervisor"]);
                    tipo = Convert.ToString(dr["tipo"]);
                    if (estado == "A")
                    {
                        estado = "Activo";
                    }
                    else
                    {
                        estado = "Inactivo";
                    }
                    if (tipo == "A")
                    {
                        tipo = "Administrador";
                    }
                    else if (tipo == "S")
                    {
                        tipo = "Supervisor";
                    }
                    else
                    {
                        tipo = "Colaborador";
                    }

                    HttpContext.Session["usuario_actual"] = cedula;
                    HttpContext.Session["tipo_usuario"] = tipo;
                    usuario = new Usuario(cedula, primer_nombre,segundo_nombre, primer_apellido, segundo_apellido, fecha_nacimiento, fecha_ingreso, estado, desempeno, supervisor,tipo,productividad, pruebas, habilidades_blandas);
                }
                con.Close();

                if (exito)
                {
                    Session["Sid"] = Session.SessionID;
                    //Response.Write(" <h2> Bienvenido </h2>" + nombre + " " + apellidos);    
                    if (tipo == "Administrador")
                    {
                        return View("~/Views/Perfil/Perfil.cshtml", "~/Views/Shared/_Menu.cshtml", usuario);
                    }
                    else if (tipo=="Colaborador"){
                        return View("~/Views/Perfil/Perfil.cshtml", "~/Views/Shared/_Menu_Colaborador.cshtml", usuario);
                    }   
                    
                    
                }
                else
                {
                    TempData["message"] = "Usuario y contraseña no coinciden";
                    return View("Index");
                }
            }
            catch (SqlException)
            {

            }
            catch(NullReferenceException)
            {

            }

            
            return View("Index");
        }
        public ActionResult Logout()
        {
            HttpContext.Session["usuario_actual"] = " ";
            HttpContext.Session["tipo_usuario"] = " ";

            return View("Index");
        }
    }
}