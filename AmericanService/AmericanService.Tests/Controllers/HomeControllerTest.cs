using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmericanService;
using AmericanService.Controllers;

namespace AmericanService.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestMethod]

        public void Login()
        {
            var usuario = "dvillalobos";
            var contrasena = "12345678";
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Login(usuario,contrasena) as ViewResult;

            // Assert
            Assert.IsNotNull( result);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]

        public void Logout()
        {
            
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Logout() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


    }
}
