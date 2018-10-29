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
    public class HistoricoControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HistoricoController controller = new HistoricoController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ConsultaHistoricos()
        {
            string filtro = "I";

            // Arrange
            HistoricoController controller = new HistoricoController();

            // Act
            List<Historico> result = controller.consulta_historico() as List<Historico>;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Find()
        {
            string buscar = "Andres";
            // Arrange
            HistoricoController controller = new HistoricoController();

            // Act
            ViewResult result = controller.Find(buscar) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
