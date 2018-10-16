﻿using System;
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

            return View(obtener_usuarios());
        }

        public ActionResult Editar(string cedula, string nombre, string apellidos, string fecha_nacimiento, string estado)
        {
            SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


            SqlCommand cmd = new SqlCommand("editar_perfil", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@cumpleanos", fecha_nacimiento);
            if (estado.ToLower() == "activo")
            {
                cmd.Parameters.AddWithValue("@estado", "A");
            }
            else
            {
                cmd.Parameters.AddWithValue("@estado", "I");
            }

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            con.Close();


            Usuario usuario = obtener_usuario_actual();
            return View("~/Views/Perfil/Perfil.cshtml", usuario);
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult CrearPerfil(string cedula, string nombre, string apellidos, string fecha_nacimiento, string usuario, string contrasena)
        {
            SqlConnection con = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


            SqlCommand cmd = new SqlCommand("crear_perfil", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@cumpleanos", fecha_nacimiento);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@contrasena", contrasena);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            con.Close();



            return View("~/Views/Perfil/Crear.cshtml");
        }

        public ActionResult gestionar_perfil() {


            Usuario usuario = obtener_usuario_actual();
            return View("~/Views/Perfil/Perfil.cshtml", usuario);

        }

        public List<Usuario> obtener_usuarios()
        {
            SqlConnection con = new SqlConnection(
               WebConfigurationManager.ConnectionStrings["MyDbconn"].ConnectionString);


            SqlCommand cmd = new SqlCommand("obtener_perfiles", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            string cedula;
            String nombre = "";
            String apellidos = "";
            DateTime fecha_nacimiento;
            DateTime fecha_ingreso;
            string estado;
            string usuario;
            List<Usuario> lista_usuarios = new List<Usuario>();

            while (dr.Read())
            {
                cedula = Convert.ToString(dr["cedula"]);
                nombre = Convert.ToString(dr["nombre"]);
                apellidos = Convert.ToString(dr["apellidos"]);
                fecha_ingreso = Convert.ToDateTime(dr["fecha_ingreso"]);
                fecha_nacimiento = Convert.ToDateTime(dr["cumpleanos"]);
                estado = Convert.ToString(dr["estado"]);
                usuario = Convert.ToString(dr["usuario"]);
                lista_usuarios.Add(new Usuario(cedula, nombre, apellidos, fecha_nacimiento, fecha_ingreso,estado,usuario));
            }


            con.Close();
            return lista_usuarios;
        }



        public Usuario obtener_usuario_actual()
        {
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
            return usuario;
        }
    }
}