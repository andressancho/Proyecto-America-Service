﻿using System;
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
    public class FormularioControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            FormularioController controller = new FormularioController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Buscar()
        {
            // Arrange
            FormularioController controller = new FormularioController();

            // Act
            ViewResult result = controller.Buscar("Andres") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        
        public void Obtener_formularios()
        {
            // Arrange
            FormularioController controller = new FormularioController();

            // Act
            List<Formulario> result = controller.obtener_formularios() as List<Formulario>;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]

        public void Eliminar()
        {
            // Arrange
            FormularioController controller = new FormularioController();

            // Act
             ViewResult result = controller.Eliminar("000000") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void Editar()
        {
            // Arrange
            FormularioController controller = new FormularioController();

            // Act
            ViewResult result = controller.Editar(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void Actualizar()
        {
            // Arrange
            FormularioController controller = new FormularioController();

            // Act
            ViewResult result = controller.update_formulario() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
