using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Excepciones;

namespace Unit.Tests
{
    [TestClass]
    public class FabricaTest
    {
        /// <summary>
        /// Test unitario para Fabrica.Agregar(), el operador +, Fabrica.ToString() y Producto.ToString()
        /// </summary>
        [TestMethod]
        public void DebeAgregarUnProducto()
        {
            Fabrica fabrica = new Fabrica();
            Producto producto = new Celular("testModel", "1", "16", "13", ETamanio.Chico.ToString(), EMarca.Generico.ToString());

            fabrica += producto;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(producto.ToString());

            Assert.AreEqual(fabrica.ToString(), sb.ToString());
        }

        /// <summary>
        /// Test unitario para Fabrica.Remover()
        /// </summary>
        [TestMethod]
        public void DebeRemoverUnProducto()
        {
            Fabrica fabrica = new Fabrica();
            Producto producto = new Celular("testModel", "1", "16", "13", ETamanio.Chico.ToString(), EMarca.Generico.ToString());

            fabrica += producto;
            fabrica -= producto;

            Assert.AreEqual(fabrica.ToString(), string.Empty);
        }

        /// <summary>
        /// Test unitario para Fabrica.Limpiar()
        /// </summary>
        [TestMethod]
        public void DebeLimpiarLaLista()
        {
            Fabrica fabrica = new Fabrica();
            Producto producto1 = new Celular("testModel", "1", "16", "13", ETamanio.Chico.ToString(), EMarca.Generico.ToString());
            Producto producto2 = new Tablet("testModel2", "2", "32", "8", EMarca.Snapdragon.ToString());

            fabrica += producto1;
            fabrica += producto2;

            fabrica.Limpiar();

            Assert.AreEqual(fabrica.ToString(), string.Empty);
        }

        /// <summary>
        /// Test unitario para Fabrica.GuardarComoTexto(string archivo) y Fabrica.LeerArchivoTexto(string archivo).<br />
        /// Se crea un directorio de prueba que se elimina al finalizar el test
        /// </summary>
        [TestMethod]
        public void DebeGenerarYLeerTexto()
        {
            Fabrica fabrica = new Fabrica();
            Producto producto = new Celular("testModel", "1", "16", "13", ETamanio.Chico.ToString(), EMarca.Generico.ToString());

            fabrica += producto;

            string rutaDePrueba = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\Cea.Lorenzo.2A.TPFinal.UnitTest";
            string archivo = rutaDePrueba + "\\DebeGenerarYLeerTexto.txt";
            Directory.CreateDirectory(rutaDePrueba);

            try
            {
                Assert.IsTrue(fabrica.GuardarComoTexto(rutaDePrueba + "\\DebeGenerarYLeerTexto"));
                Assert.AreEqual(fabrica.ToString(), fabrica.LeerArchivoTexto(archivo));
            }
            finally
            {
                Directory.Delete(rutaDePrueba, true);
            }

        }

        /// <summary>
        /// Test unitario para Fabrica.GuardarComoXml(string archivo) y Fabrica.LeerArchivoXml(string archivo).<br />
        /// Se crea un directorio de prueba que se elimina al finalizar el test
        /// </summary>
        [TestMethod]
        public void DebeGenerarYLeerXml()
        {
            Fabrica fabrica = new Fabrica();
            Producto producto = new Celular("testModel", "1", "16", "13", ETamanio.Chico.ToString(), EMarca.Generico.ToString());

            fabrica += producto;

            string rutaDePrueba = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\Cea.Lorenzo.2A.TPFinal.UnitTest";
            string archivo = rutaDePrueba + "\\DebeGenerarYLeerXml.xml";
            Directory.CreateDirectory(rutaDePrueba);

            try
            {
                Assert.IsTrue(fabrica.GuardarComoXml(rutaDePrueba + "\\DebeGenerarYLeerXml"));

                List<Producto> listaRecuperadaDeProductos = fabrica.LeerArchivoXml(archivo);

                Assert.IsTrue(listaRecuperadaDeProductos != null && listaRecuperadaDeProductos.Count == 1);
                Assert.IsTrue(listaRecuperadaDeProductos[0] == producto);
            }
            finally
            {
                Directory.Delete(rutaDePrueba, true);
            }
        }

        /// <summary>
        /// Test unitario para probar que arroje AgregarObjetoException
        /// </summary>
        [TestMethod]
        public void DebeImpedirAgregarDuplicados()
        {
            Fabrica fabrica = new Fabrica();
            Producto producto = new Celular("testModel", "1", "16", "13", ETamanio.Chico.ToString(), EMarca.Generico.ToString());
            bool arrojaExcepcion = false;

            fabrica += producto;

            try
            {
                fabrica += producto;
            }
            catch (AgregarObjetoException)
            {
                arrojaExcepcion = true;
            }

            Assert.IsTrue(arrojaExcepcion);
        }

        /// <summary>
        /// Test unitario para probar que arroje RemoverObjetoException
        /// </summary>
        [TestMethod]
        public void DebeImpedirRemoverUnObjetoNoExistente()
        {
            Fabrica fabrica = new Fabrica();
            Producto producto = new Celular("testModel", "1", "16", "13", ETamanio.Chico.ToString(), EMarca.Generico.ToString());
            bool arrojaExcepcion = false;

            try
            {
                fabrica -= producto;
            }
            catch (RemoverObjetoException)
            {
                arrojaExcepcion = true;
            }

            Assert.IsTrue(arrojaExcepcion);
        }

        /// <summary>
        /// Test unitario para probar que arroje ValorInvalidoException
        /// </summary>
        [TestMethod]
        public void DebeValidarDatosIngresadosAlProducto()
        {
            bool arrojaExcepcion = false;

            try
            {
                Producto producto = new Celular("errorModel", "ram", "rom", "megapixeles", "tamaño");
            }
            catch (ValorInvalidoException)
            {
                arrojaExcepcion = true;
            }

            Assert.IsTrue(arrojaExcepcion);
        }
    }
}
