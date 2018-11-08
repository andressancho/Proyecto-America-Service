using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Data.SqlClient;
using AmericanService.Models;
using AmericanService.PDF;

namespace AmericanService.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        [HttpGet]
        public ActionResult Index()
        {

            return View(obtener_usuarios());
        }
        [HttpPost]
        public ActionResult Index(string Estado)
        {
            return View(filtrar_usuarios(Estado));
        }

        public ActionResult Eliminar(String cedula)
        {
            SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


            SqlCommand cmd = new SqlCommand("eliminar_perfil", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cedula", cedula);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            con.Close();
            return View("Index", obtener_usuarios());
        }

        public ActionResult Editar_otro_usuario(String cedula)
        {
            return View("~/Views/Perfil/Edit.cshtml", obtener_usuario_actual(cedula));
        }


        public ActionResult Descargar_PDF(String cedula)
        {
            return obtener_usuario_PDF(obtener_usuario_actual(cedula));
        }

        public ActionResult obtener_usuario_PDF(Usuario usuario) {
            ArchivoPDF archivoPDF = new ArchivoPDF();
            byte[] abytes = archivoPDF.PrepararPDF(usuario);
            return File(abytes, "application/pdf");
        }



 
        public ActionResult Editar(string cedula, string ced, string primer_nombre,string segundo_nombre, string primer_apellido, string segundo_apellido, string fecha_nacimiento, string fecha_ingreso,string tipo,string supervisor,string desempeno, string estado,string productividad, string pruebas, string habilidades)

        {
            try
            {
                SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("editar_perfil", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);
                cmd.Parameters.AddWithValue("@ced", ced);
                cmd.Parameters.AddWithValue("@primer_nombre", primer_nombre);
                cmd.Parameters.AddWithValue("@segundo_nombre", segundo_nombre);
                cmd.Parameters.AddWithValue("@primer_apellido", primer_apellido);
                cmd.Parameters.AddWithValue("@segundo_apellido", segundo_apellido);
                cmd.Parameters.AddWithValue("@cumpleanos", fecha_nacimiento);
                cmd.Parameters.AddWithValue("@ingreso", fecha_ingreso);
                cmd.Parameters.AddWithValue("@supervisor", supervisor);
                cmd.Parameters.AddWithValue("@productividad", Convert.ToInt32(productividad));
                cmd.Parameters.AddWithValue("@pruebas", Convert.ToInt32(pruebas));
                cmd.Parameters.AddWithValue("@habilidades_blandas", Convert.ToInt32(habilidades));
                //cmd.Parameters.AddWithValue("@desempeno", desempeno);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            catch(SqlException)
            {
                TempData["message"] = "Ya existe un usuario con la misma cedula";
            }

            HttpContext.Session["usuario_actual"] = ced;
            Usuario usuario = obtener_usuario_actual(HttpContext.Session["usuario_actual"].ToString());

            if (tipo == "Administrador")
            {
                return View("~/Views/Perfil/Perfil.cshtml", "~/Views/Shared/_Menu.cshtml", usuario);
            }
            else if (tipo == "Colaborador")
            {
                return View("~/Views/Perfil/Perfil.cshtml", "~/Views/Shared/_Menu_Colaborador.cshtml", usuario);
            }
            else
            {
                return View("~/Views/Perfil/Perfil.cshtml", "~/Views/Shared/_Menu.cshtml", usuario);
            }
            
        }
        public ActionResult Editar_otro_perfil(string cedula, string ced, string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, string fecha_nacimiento, string fecha_ingreso, string tipo, string supervisor, string desempeno, string estado, string productividad, string pruebas, string habilidades)
        {
            try
            {
                SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("editar_perfil", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);
                cmd.Parameters.AddWithValue("@ced", ced); 
                cmd.Parameters.AddWithValue("@primer_nombre", primer_nombre);
                cmd.Parameters.AddWithValue("@segundo_nombre", segundo_nombre);
                cmd.Parameters.AddWithValue("@primer_apellido", primer_apellido);
                cmd.Parameters.AddWithValue("@segundo_apellido", segundo_apellido);
                cmd.Parameters.AddWithValue("@cumpleanos", fecha_nacimiento);
                cmd.Parameters.AddWithValue("@ingreso", fecha_ingreso);
                cmd.Parameters.AddWithValue("@supervisor", supervisor);
                cmd.Parameters.AddWithValue("@productividad", Convert.ToInt32(productividad));
                cmd.Parameters.AddWithValue("@pruebas", Convert.ToInt32(pruebas));
                cmd.Parameters.AddWithValue("@habilidades_blandas", Convert.ToInt32(habilidades));
                //cmd.Parameters.AddWithValue("@desempeno", desempeno);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@tipo", tipo);


                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            catch (SqlException)
            {
                TempData["message"] = "Ya existe un usuario con la misma cedula";
            }

            return View("~/Views/Perfil/Index.cshtml", obtener_usuarios());
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult CrearPerfil(string cedula, string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, string fecha_nacimiento, string fecha_ingreso, string tipo, string supervisor,string contrasena, string usuario)
        {
            try
            {
                SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("crear_perfil", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);
                cmd.Parameters.AddWithValue("@primer_nombre", primer_nombre);
                cmd.Parameters.AddWithValue("@segundo_nombre", segundo_nombre);
                cmd.Parameters.AddWithValue("@primer_apellido", primer_apellido);
                cmd.Parameters.AddWithValue("@segundo_apellido", segundo_apellido);
                cmd.Parameters.AddWithValue("@cumpleanos", fecha_nacimiento);
                cmd.Parameters.AddWithValue("@ingreso", fecha_ingreso);
                cmd.Parameters.AddWithValue("@supervisor", supervisor);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                cmd.Parameters.AddWithValue("@usuario", usuario);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int i=dr.RecordsAffected;
                if (i == -1)
                {
                    TempData["message"] = "Ya existe un usuario con esa cedula o nombre de usuario";
                }
                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            catch(SqlException)
            {

            }

             return View("~/Views/Perfil/Crear.cshtml");
        }

        public ActionResult gestionar_perfil() {

            if (Session["Sid"] == null)
            {
                return View("~/Views/Home/Index.cshtml");
            }
            Usuario usuario = obtener_usuario_actual(HttpContext.Session["usuario_actual"].ToString());
            String tipo = HttpContext.Session["tipo_usuario"].ToString();
            if (tipo == "Administrador")
            {
                return View("~/Views/Perfil/Perfil.cshtml", "~/Views/Shared/_Menu.cshtml", usuario);
            }
            else if (tipo == "Colaborador")
            {
                return View("~/Views/Perfil/Perfil.cshtml", "~/Views/Shared/_Menu_Colaborador.cshtml", usuario);
            }
            return View("~/Views/Perfil/Perfil.cshtml", usuario);

        }

        public List<Usuario> obtener_usuarios()
        {
            List<Usuario> lista_usuarios = new List<Usuario>();
            try
            {
                SqlConnection con = new SqlConnection(
               WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("obtener_perfiles", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                string cedula;
                String primer_nombre = "";
                String segundo_nombre = "";
                String primer_apellido = "";
                String segundo_apellido = "";
                DateTime fecha_nacimiento;
                DateTime fecha_ingreso;
                string estado;
                string tipo;
                string usuario;
                string supervisor;
                string desempeno;
                int productividad, pruebas, habilidades_blandas;


                while (dr.Read())
                {
                    cedula = Convert.ToString(dr["cedula"]);
                    primer_nombre = Convert.ToString(dr["primer_nombre"]);
                    segundo_nombre = Convert.ToString(dr["segundo_nombre"]);
                    primer_apellido = Convert.ToString(dr["primer_apellido"]);
                    segundo_apellido = Convert.ToString(dr["segundo_apellido"]);
                    fecha_ingreso = Convert.ToDateTime(dr["fecha_ingreso"]);
                    fecha_nacimiento = Convert.ToDateTime(dr["cumpleanos"]);
                    estado = Convert.ToString(dr["estado"]);
                    usuario = Convert.ToString(dr["usuario"]);
                    tipo = Convert.ToString(dr["tipo"]);
                    supervisor = Convert.ToString(dr["supervisor"]);
                    desempeno = Convert.ToString(dr["desempeno"]);
                    productividad = Convert.ToInt32(dr["productividad"]);
                    pruebas = Convert.ToInt32(dr["pruebas"]);
                    habilidades_blandas = Convert.ToInt32(dr["habilidades_blandas"]);
                    lista_usuarios.Add(new Usuario(cedula, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, fecha_nacimiento, supervisor, fecha_ingreso, estado, tipo, usuario,desempeno,productividad,pruebas, habilidades_blandas));
                }


                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            
            return lista_usuarios;
        }
        public List<Usuario> filtrar_usuarios(string filtro)
        {
            List<Usuario> lista_usuarios = new List<Usuario>();
            try
            {
               SqlConnection con = new SqlConnection(
               WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("filtrar_perfiles", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@filtro", filtro);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                string cedula;
                String primer_nombre = "";
                String segundo_nombre = "";
                String primer_apellido = "";
                String segundo_apellido = "";
                DateTime fecha_nacimiento;
                DateTime fecha_ingreso;
                string estado;
                string tipo;
                string usuario;
                string supervisor;


                while (dr.Read())
                {
                    cedula = Convert.ToString(dr["cedula"]);
                    primer_nombre = Convert.ToString(dr["primer_nombre"]);
                    segundo_nombre = Convert.ToString(dr["segundo_nombre"]);
                    primer_apellido = Convert.ToString(dr["primer_apellido"]);
                    segundo_apellido = Convert.ToString(dr["segundo_apellido"]);
                    fecha_ingreso = Convert.ToDateTime(dr["fecha_ingreso"]);
                    fecha_nacimiento = Convert.ToDateTime(dr["cumpleanos"]);
                    estado = Convert.ToString(dr["estado"]);
                    usuario = Convert.ToString(dr["usuario"]);
                    tipo = Convert.ToString(dr["tipo"]);
                    supervisor = Convert.ToString(dr["supervisor"]);
                    lista_usuarios.Add(new Usuario(cedula, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, fecha_nacimiento, supervisor, fecha_ingreso, estado, tipo, usuario,"",1,1,1));
                }


                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            
            

            
            return lista_usuarios;
        }
        
        public Usuario obtener_usuario_actual(String cedula)
        {
            Usuario usuario = new Usuario();
            try
            {
                //String cedula = HttpContext.Session["usuario_actual"].ToString();

                SqlConnection con = new SqlConnection(
                    WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


                SqlCommand cmd = new SqlCommand("obtener_perfil", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();




                string primer_nombre = "";
                string segundo_nombre = "";
                string primer_apellido = "";
                string segundo_apellido = "";
                DateTime fecha_nacimiento;
                DateTime fecha_ingreso;
                string estado = "";
                string desempeno = "";
                string supervisor = "";
                string tipo = "";
                int productividad, pruebas, habilidades_blandas;

                while (dr.Read())
                {

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
                    usuario = new Usuario(cedula, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, fecha_nacimiento, fecha_ingreso, estado, desempeno, supervisor, tipo, productividad,pruebas,habilidades_blandas);

                }
                con.Close();
            }
            catch (NullReferenceException)
            {

            }
            
            return usuario;
        }
    }

   
}
