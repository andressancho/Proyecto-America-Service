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

            while (dr.Read()) {
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
          return View(lista_historico);
        }

        // GET: Historico/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Historico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Historico/Create
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

        // GET: Historico/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Historico/Edit/5
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

        // GET: Historico/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Historico/Delete/5
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
