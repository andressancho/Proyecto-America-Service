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
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult crear_perfil()
        {
            return View();
        }

        public ActionResult gestionar_perfil() {
            String cedula = HttpContext.Session["usuario_actual"].ToString();

            SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


            SqlCommand cmd = new SqlCommand("obtener_perfil", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cedula", cedula);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();


            Usuario usuario = new Usuario();
            string nombre = "";
            string apellidos = "";
            DateTime fecha_nacimiento;
            DateTime fecha_ingreso;
            string estado = "";
            string desempeno = "";
            string supervisor = "";

            while (dr.Read())
            {

                cedula = Convert.ToString(dr["cedula"]);
                nombre = Convert.ToString(dr["nombre"]);
                apellidos = Convert.ToString(dr["apellidos"]);
                fecha_nacimiento = Convert.ToDateTime(dr["cumpleanos"]);
                fecha_ingreso = Convert.ToDateTime(dr["fecha_ingreso"]);
                estado = Convert.ToString(dr["estado"]);
                desempeno = Convert.ToString(dr["desempeno_pruebas"]);
                supervisor = Convert.ToString(dr["supervisor"]);
                if (estado == "A")
                {
                    estado = "Activo";
                }
                else
                {
                    estado = "No Activo";
                }
                usuario = new Usuario(cedula, nombre, apellidos, fecha_nacimiento, fecha_ingreso, estado, desempeno, supervisor);

            }
            con.Close();
            return View("~/Views/Perfil/Perfil.cshtml", usuario);

        }

        // GET: Perfil/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Perfil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfil/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Perfil/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Perfil/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Perfil/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Perfil/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
