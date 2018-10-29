using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmericanService;
using AmericanService.Models;
using AmericanService.Controllers;

namespace AmericanService.Tests.Controllers
{
    [TestClass]
    public class PerfilControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            PerfilController controller = new PerfilController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Index_Filtrado()
        {
            string estado = "A";
            // Arrange
            PerfilController controller = new PerfilController();

            // Act
            ViewResult result = controller.Index(estado) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Editar()
        {
            string cedula= "204450123";
            string nombre="Andrés";
            string apellido="Sancho";
            string estado="Activo";
            string fecha="10/12/1997";
            // Arrange
            PerfilController controller = new PerfilController();

            // Act
            ViewResult result = controller.Editar(cedula,nombre,apellido,fecha,estado) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CrearPerfil()
        {
            string cedula = "204450123";
            string nombre = "Andrés";
            string apellido = "Sancho";
            string usuario = "Activo";
            string fecha = "10/12/1997";
            string contrasena = "12345678";
            // Arrange
            PerfilController controller = new PerfilController();

            // Act
            ViewResult result = controller.CrearPerfil(cedula, nombre, apellido, fecha, usuario, contrasena) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GestionarPerfil()
        {

            // Arrange
            PerfilController controller = new PerfilController();

            // Act
            ViewResult result = controller.gestionar_perfil() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ObtenerUsuarios()
        {

            // Arrange
            PerfilController controller = new PerfilController();

            // Act
            List<Usuario> result = controller.obtener_usuarios() as List<Usuario>;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void FiltrarUsuarios()
        {
            string filtro = "I";

            // Arrange
            PerfilController controller = new PerfilController();

            // Act
            List<Usuario> result = controller.filtrar_usuarios(filtro) as List<Usuario>;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void UsuarioActual()
        {
        

            // Arrange
            PerfilController controller = new PerfilController();

            // Act
            Usuario result = controller.obtener_usuario_actual() as Usuario;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
