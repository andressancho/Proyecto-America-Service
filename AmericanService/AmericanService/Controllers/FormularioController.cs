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

        public ActionResult Editar(int id_formulario)
        {
            return View("Edit", obtener_formulario_editar(id_formulario));
        }

        public Formulario obtener_formulario_editar(int id)
        {
            Formulario formulario = new Formulario();
            Roleplay roleplay = new Roleplay();

            try
            {
                SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);

                SqlCommand cmd = new SqlCommand("obtener_formulario_editar", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_formulario", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                String primer_nombre;
                String segundo_nombre;
                String primer_apellido;
                String segundo_apellido;
                String cedula;
                int id_roleplay;
                bool jornada_diurna;
                bool jornada_mixta;
                bool jornada_nocturna;
                String justificacion_jornada;
                DateTime fecha;
                double salario;
                int telefono;
                String correo;
                String domicilio;
                bool exp_call_center;
                bool exp_ventas;
                bool exp_servicio_cliente;
                String detalle_experiencias;
                bool exp_cobros;
                bool exp_mora30;
                bool exp_mora60;
                bool exp_mora90;
                bool exp_cartera_separada;
                bool exp_cobro_judicial;
                String detalle_exp_cobros;
                bool excel;
                bool bachillerato;
                int id_formulario;
                DateTime fecha_roleplay;
                String detalle;
                String visto_bueno;

                while (dr.Read())
                {
                    primer_nombre = Convert.ToString(dr["primer_nombre"]);
                    segundo_nombre = Convert.ToString(dr["segundo_nombre"]);
                    primer_apellido = Convert.ToString(dr["primer_apellido"]);
                    segundo_apellido = Convert.ToString(dr["segundo_apellido"]);
                    cedula = Convert.ToString(dr["cedula"]);
                    id_roleplay = Convert.ToInt16(dr["id_roleplay"]);
                    jornada_diurna = Convert.ToBoolean(dr["jornada_diurna"]);
                    jornada_mixta = Convert.ToBoolean(dr["jornada_mixta"]);
                    jornada_nocturna = Convert.ToBoolean(dr["jornada_nocturna"]);
                    justificacion_jornada = Convert.ToString(dr["justificacion_jornada"]);
                    fecha = Convert.ToDateTime(dr["fecha"]);
                    salario = Convert.ToDouble(dr["salario"]);
                    telefono = Convert.ToInt32(dr["telefono"]);
                    correo = Convert.ToString(dr["correo"]);
                    domicilio = Convert.ToString(dr["domicilio"]);
                    exp_call_center = Convert.ToBoolean(dr["exp_call_center"]);
                    exp_ventas = Convert.ToBoolean(dr["exp_ventas"]);
                    exp_servicio_cliente = Convert.ToBoolean(dr["exp_servicio_cliente"]);
                    detalle_experiencias = Convert.ToString(dr["detalle_experiencias"]);
                    exp_cobros = Convert.ToBoolean(dr["exp_cobros"]);
                    exp_mora30 = Convert.ToBoolean(dr["exp_mora30"]);
                    exp_mora60 = Convert.ToBoolean(dr["exp_mora60"]);
                    exp_mora90 = Convert.ToBoolean(dr["exp_mora90"]);
                    exp_cartera_separada = Convert.ToBoolean(dr["exp_cartera_separada"]);
                    exp_cobro_judicial = Convert.ToBoolean(dr["exp_cobro_judicial"]);
                    detalle_exp_cobros = Convert.ToString(dr["detalle_exp_cobros"]);
                    excel = Convert.ToBoolean(dr["excel"]);
                    bachillerato = Convert.ToBoolean(dr["bachillerato"]);
                    id_formulario = Convert.ToInt16(dr["id_formulario"]);
                    fecha_roleplay = Convert.ToDateTime(dr["fecha_roleplay"]);
                    detalle = Convert.ToString(dr["detalle"]);
                    visto_bueno = Convert.ToString(dr["visto_bueno"]);
                    roleplay = new Roleplay(id_roleplay, fecha_roleplay, detalle, visto_bueno);
                    formulario = new Formulario(id_formulario,  cedula,  primer_nombre,  segundo_nombre,  primer_apellido,  segundo_apellido,  id_roleplay,  jornada_diurna,  jornada_mixta,  jornada_nocturna,  justificacion_jornada,  fecha,  salario,  telefono,  correo,  domicilio,  exp_call_center,  exp_ventas,  exp_servicio_cliente,  detalle_experiencias,  exp_cobros,  exp_mora30,  exp_mora60,  exp_mora90,  exp_cartera_separada,  exp_cobro_judicial,  detalle_exp_cobros,  excel,  bachillerato, roleplay);
                }

                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            return formulario;



        }

        public ActionResult Edit(int id_roleplay, DateTime fecha_roleplay, String detalle, String visto_bueno) {
            try
            {
                SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("editar_roleplay", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_roleplay", id_roleplay);
                cmd.Parameters.AddWithValue("@fecha_roleplay", fecha_roleplay);
                cmd.Parameters.AddWithValue("@detalle", detalle);
                cmd.Parameters.AddWithValue("@visto_bueno", visto_bueno);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            return View("~/Views/Formulario/Index.cshtml", obtener_formularios());
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
            int id_formulario;
            List<Formulario> lista_formularios = new List<Formulario>();

            while (dr.Read())
            {
                cedula = Convert.ToString(dr["cedula"]);
                primer_nombre = Convert.ToString(dr["primer_nombre"]);
                segundo_nombre = Convert.ToString(dr["segundo_nombre"]);
                primer_apellido = Convert.ToString(dr["primer_apellido"]);
                segundo_apellido = Convert.ToString(dr["segundo_apellido"]);
                fecha = Convert.ToDateTime(dr["fecha"]);
                id_formulario = Convert.ToInt16(dr["id_formulario"]);
                lista_formularios.Add(new Formulario(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, cedula, fecha, id_formulario));
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
                int id_formulario;


                while (dr.Read())
                {
                    cedula = Convert.ToString(dr["cedula"]);
                    primer_nombre = Convert.ToString(dr["primer_nombre"]);
                    segundo_nombre = Convert.ToString(dr["segundo_nombre"]);
                    primer_apellido = Convert.ToString(dr["primer_apellido"]);
                    segundo_apellido = Convert.ToString(dr["segundo_apellido"]);
                    fecha = Convert.ToDateTime(dr["fecha"]);
                    id_formulario = Convert.ToInt16(dr["id_formulario"]);
                    lista_formularios.Add(new Formulario(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, cedula, fecha, id_formulario));
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