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
        //Entradas: 
        //Salidas: Vista de tablas de formularios con todos los formularios
        //Descripción: 
        public ActionResult Index()
        {
            return View(obtener_formularios());
        }

        //Entradas: String para buscar formularios en la tabla
        //Salidas: La vista mostrando los los formularios encontrados
        //Descripción: Busca en la tabla formularios, registros segun lo que ingrese el usuario, ya sea nombres apellidos o cédula
        public ActionResult Buscar(string buscar_string)
        {
            int i;
            List<Formulario> lista_formulario_buscar = new List<Formulario>();
            foreach (Formulario h in obtener_formularios())
            {
                if (!String.IsNullOrEmpty(buscar_string))
                {
                    if (int.TryParse(buscar_string, out i))
                    {
                        if (h.cedula == i.ToString())
                        {
                            lista_formulario_buscar.Add(h);
                        }
                    }
                    else
                    {
                        if (h.primer_nombre.Equals(buscar_string) || h.segundo_nombre.Equals(buscar_string) || h.primer_apellido.Equals(buscar_string) || h.segundo_apellido.Equals(buscar_string))
                        {
                            lista_formulario_buscar.Add(h);
                        }
                    }

                }
            }
            return View("Index", lista_formulario_buscar);
        }

        //Entradas: Los filtros ingresados por el usuario
        //Salidas: La vista de la tabla mostrando los formularios que corresponden al filtro
        //Descripción: Obtiene los formularios que cumplen con el filtro ingresado por el usuario por ventas, cobros, call center, servicio al cliente, excel o bachillerato


        [HttpPost]
        public ActionResult Index(string ventas)
        {
            return View(obtener_formularios());
        }

        public ActionResult Filtrar(string ventas, string cobros, string call_center, string servicio_cliente, string excel, string bachillerato)
        {
            if (ventas == null)
            {
                ventas = "0";
            }
            if (cobros == null)
            {
                cobros = "0";
            }
            if (call_center == null)
            {
                call_center = "0";
            }
            if (servicio_cliente == null)
            {
                servicio_cliente = "0";
            }
            if (excel == null)
            {
                excel = "0";
            }
            if (bachillerato == null)
            {
                bachillerato = "0";
            }
            return View("Index", filtrar_formularios(ventas, cobros, bachillerato, excel, servicio_cliente, call_center));
        }
        //Entradas: el id de formulario por borrar
        //Salidas: la vista de la tabla con los registros de formularios
        //Descripción: Elimina un registro de formulario por el id

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

        //Entradas: el id del formulario para abrir la vista para editar ese formulario
        //Salidas: la vista de editar mostrando la informacion del formulario a editar
        //Descripción: función para desplegar la vista de editar con la informacion de un formulario
        public ActionResult Editar(int id_formulario)
        {
            return View("Edit", obtener_formulario_editar(id_formulario));
        }

        //Entradas: id de un formulario
        //Salidas: la información de un formulario para editar
        //Descripción: Obtiene la información para editarlo por medio del id
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
                int mecanografia;

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
                    mecanografia = Convert.ToInt32(dr["mecanografia"]);
                    roleplay = new Roleplay(id_roleplay, fecha_roleplay, detalle, visto_bueno,mecanografia);
                    formulario = new Formulario(id_formulario,  cedula,  primer_nombre,  segundo_nombre,  primer_apellido,  segundo_apellido,  id_roleplay,  jornada_diurna,  jornada_mixta,  jornada_nocturna,  justificacion_jornada,  fecha,  salario,  telefono,  correo,  domicilio,  exp_call_center,  exp_ventas,  exp_servicio_cliente,  detalle_experiencias,  exp_cobros,  exp_mora30,  exp_mora60,  exp_mora90,  exp_cartera_separada,  exp_cobro_judicial,  detalle_exp_cobros,  excel,  bachillerato, roleplay);
                }
                
                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            catch (SqlException) { }
            
            return formulario;
        }


        //Entradas:La información editable del formulario
        //Salidas: La vista de la tabla de formularios actualizada
        //Descripción: Edita un registro de un formulario
        public ActionResult Edit(int id_roleplay, DateTime fecha_roleplay, String detalle, String visto_bueno, string mecanografia) {

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
                cmd.Parameters.AddWithValue("@mecanografia", mecanografia);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            //TempData["message"] = "Formulario editado correctamente.";
            return View("~/Views/Formulario/Index.cshtml", obtener_formularios());
        }

        //Entradas: los filtros escogidos por el usuario
        //Salidas: la lsta de formularios que corresponden al filtro
        //Descripción: filtra los formularios escogido por el usuario (cobros, ventas, excel bachillerato, servicio al cliente, call center)
        public List<Formulario> filtrar_formularios(string ventas, string cobros, string excel, string bachillerato, string servicio_cliente, string call_center)
        {
            String cedula;
            String primer_nombre = "";
            String segundo_nombre = "";
            String primer_apellido = "";
            String segundo_apellido = "";
            //String descripcion = "";
            DateTime fecha;
            int id_formulario;
            List<Formulario> lista_formularios = new List<Formulario>();
            try
            {
                SqlConnection con = new SqlConnection(
               WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);
                SqlCommand cmd;



                cmd = new SqlCommand("filtrar_formularios", con);


                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ventas", ventas);
                cmd.Parameters.AddWithValue("@cobros", cobros);
                cmd.Parameters.AddWithValue("@excel", excel);
                cmd.Parameters.AddWithValue("@bachillerato", bachillerato);
                cmd.Parameters.AddWithValue("@servicio_cliente", servicio_cliente);
                cmd.Parameters.AddWithValue("@call_center", call_center);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                

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
            catch (SqlException)
            {

            }
            
            return lista_formularios;
        }


        //Entradas: no tiene entradas
        //Salidas:  Todos los formularios en la base de datos
        //Descripción: Obtiene la lista de formularios de la base de datos 

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

        public ActionResult update_formulario()
        {
            ConexionFtp ftp = new ConexionFtp();
            List<string> information = ftp.updateDataBase();

            SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);

            foreach (string line in information)
            {
                string[] values = line.Split(',');

                SqlCommand cmd = new SqlCommand("agregar_formulario", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", values[1]);
                cmd.Parameters.AddWithValue("@primer_nombre", values[2]);
                cmd.Parameters.AddWithValue("@segundo_nombre", "");
                cmd.Parameters.AddWithValue("@primer_apellido", values[3]);
                cmd.Parameters.AddWithValue("@segundo_apellido", values[4]);
                cmd.Parameters.AddWithValue("@id_roleplay", DBNull.Value);
                cmd.Parameters.AddWithValue("@jornada_diurna", bool.Parse(values[15]));
                cmd.Parameters.AddWithValue("@jornada_mixta", bool.Parse(values[16]));
                cmd.Parameters.AddWithValue("@jornada_nocturna", bool.Parse(values[17]));
                cmd.Parameters.AddWithValue("@justificacion_jornada", values[18]);
                cmd.Parameters.AddWithValue("@fecha", DBNull.Value);
                cmd.Parameters.AddWithValue("@salario", Int32.Parse(values[8]));
                cmd.Parameters.AddWithValue("@telefono", Int32.Parse(values[5]));
                cmd.Parameters.AddWithValue("@correo", values[6]);
                cmd.Parameters.AddWithValue("@domicilio", values[7]);
                cmd.Parameters.AddWithValue("@exp_call_center", bool.Parse(values[9]));
                cmd.Parameters.AddWithValue("@exp_ventas", bool.Parse(values[10]));
                cmd.Parameters.AddWithValue("@exp_servicio_cliente", bool.Parse(values[11]));
                cmd.Parameters.AddWithValue("@detalle_experiencias", values[13]);
                cmd.Parameters.AddWithValue("@exp_cobros", 0);
                cmd.Parameters.AddWithValue("@exp_mora30", bool.Parse(values[19]));
                cmd.Parameters.AddWithValue("@exp_mora60", bool.Parse(values[20]));
                cmd.Parameters.AddWithValue("@exp_mora90", bool.Parse(values[21]));
                cmd.Parameters.AddWithValue("@exp_cartera_separada", bool.Parse(values[22]));
                cmd.Parameters.AddWithValue("@exp_cobro_judicial", bool.Parse(values[23]));
                cmd.Parameters.AddWithValue("@detalle_exp_cobros", values[24]);
                cmd.Parameters.AddWithValue("@excel", bool.Parse(values[12]));
                cmd.Parameters.AddWithValue("@bachillerato", bool.Parse(values[14]));
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();
            }
            return View("Index", obtener_formularios());
        }
    }
}