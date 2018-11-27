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
        //Entradas: ninguna
        //Salidas: La vista con la información de la tabla de historicos
        //Descripción: Muestra todos los historicos en la tabla de la vista
        public ActionResult Index()
        {
            
          return View(consulta_historico());
        }

        //Entradas: Todos los valores editables de los históricos
        //Salidas: La vista con los registros de historicos actualizados
        //Descripción: Edita un registro de historicos
        public ActionResult Editar(string cedula, string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, string descripcion, string fecha, string cantidad)
        {
            try
            {
                SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("editar_historico", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);
                cmd.Parameters.AddWithValue("@primer_nombre", primer_nombre);
                cmd.Parameters.AddWithValue("@segundo_nombre", segundo_nombre);
                cmd.Parameters.AddWithValue("@primer_apellido", primer_apellido);
                cmd.Parameters.AddWithValue("@segundo_apellido", segundo_apellido);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            return View("~/Views/Historico/Index.cshtml", consulta_historico());
        }

        //Entradas: ninguna
        //Salidas: La lista de historicos que están en la base de datos
        //Descripción: obtiene la lista de históricos de la base de datos
        public List<Historico> consulta_historico() {
            List<Historico> lista_historico = new List<Historico>();
            try
            {
               SqlConnection con = new SqlConnection(
               WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("obtener_historico_reclutandos", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                String cedula;
                String primer_nombre = "";
                String segundo_nombre = "";
                String primer_apellido = "";
                String segundo_apellido = "";
                String descripcion = "";
                DateTime fecha;
                String cantidad;


                while (dr.Read())
                {
                    cedula = Convert.ToString(dr["cedula"]);
                    primer_nombre = Convert.ToString(dr["primer_nombre"]);
                    segundo_nombre = Convert.ToString(dr["segundo_nombre"]);
                    primer_apellido = Convert.ToString(dr["primer_apellido"]);
                    segundo_apellido = Convert.ToString(dr["segundo_apellido"]);
                    descripcion = Convert.ToString(dr["descripcion"]);
                    fecha = Convert.ToDateTime(dr["fecha"]);
                    cantidad = Convert.ToString(dr["cantidad"]);
                    lista_historico.Add(new Historico(cedula, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, descripcion, fecha, cantidad));
                }

                //foreach (Historico h in lista_historico) {
                //    Response.Write(h.nombre);
                //}
                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            
            return lista_historico;
        }

        //Entradas: La cedula para eliminar un historico
        //Salidas: la vista con la tabla de historicos actualizada
        //Descripción: Elimina un registro de historico por la cedula
        public ActionResult Eliminar(String cedula)
        {
            try
            {
                SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("eliminar_historico", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception)
            {

            }
            
            return View("Index", consulta_historico());
        }

        //Entradas: la cedula para editar un historico
        //Salidas: La vista de editar con la informacion del historico a editar
        //Descripción: Abrir la vista de editar con la informacion de un historico
        public ActionResult Editar_btn(String cedula)
        {
            return View("Edit", obtener_historico_actual(cedula));
        }

        //Entradas:un string para buscar
        //Salidas: la vista con la tabla con los registros buscados
        //Descripción: Busca los registros que coincidan con el string buscar segun nombres, apellido, cedula
        public ActionResult Buscar(string buscar_string) {
            int i;
            List<Historico> lista_historico_buscar = new List<Historico>();
            foreach (Historico h in consulta_historico()) {
                if (!String.IsNullOrEmpty(buscar_string)) {
                    if (int.TryParse(buscar_string, out i))
                    {
                        if (h.cedula == i.ToString())
                        {
                            lista_historico_buscar.Add(h);
                        }
                    }
                    else
                    {
                        if (h.primer_nombre.Equals(buscar_string) || h.segundo_nombre.Equals(buscar_string) || h.primer_apellido.Equals(buscar_string) || h.segundo_apellido.Equals(buscar_string))
                        {
                            lista_historico_buscar.Add(h);    
                        }
                    }
                   
                }
            }
            return View("Index", lista_historico_buscar);
        }

        //Entradas:  la cedula del historico a editar
        //Salidas: un historico
        //Descripción: obtiene la informacion del historico a editar y desplegarlo en la vista
        public Historico obtener_historico_actual(String cedula)
        {
            Historico historico = new Historico();
            try
            {
                //String cedula = HttpContext.Session["usuario_actual"].ToString();

                SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("obtener_historico", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();



                
                string primer_nombre = "";
                string segundo_nombre = "";
                string primer_apellido = "";
                string segundo_apellido = "";
                DateTime fecha;
                string descripcion = "";
                string cantidad = "";

                while (dr.Read())
                {

                    cedula = Convert.ToString(dr["cedula"]);
                    primer_nombre = Convert.ToString(dr["primer_nombre"]);
                    segundo_nombre = Convert.ToString(dr["segundo_nombre"]);
                    primer_apellido = Convert.ToString(dr["primer_apellido"]);
                    segundo_apellido = Convert.ToString(dr["segundo_apellido"]);
                    fecha = Convert.ToDateTime(dr["fecha"]);
                    descripcion = Convert.ToString(dr["descripcion"]);
                    cantidad = Convert.ToString(dr["cantidad"]);


                    historico = new Historico(cedula, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, descripcion, fecha, cantidad);

                }
                con.Close();
            }
            catch (NullReferenceException)
            {

            }

            return historico;
        }


    }
}
