using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.Text;
using System.IO;
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
            Producto producto = new Celular("testModel", "1", "16", "13", ETamanio.Chico.ToString(), EMarca.Generico.ToString());

            string rutaDePrueba = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\Cea.Lorenzo.2A.TPFinal.UnitTest";
            string archivo = rutaDePrueba + "\\DebeGenerarYLeerTexto.txt";
            Directory.CreateDirectory(rutaDePrueba);

            try
            {
                Assert.IsTrue(Fabrica.GuardarComoTexto(rutaDePrueba + "\\DebeGenerarYLeerTexto", producto));
                Assert.AreEqual(producto.ToString(), Fabrica.LeerArchivoTexto(archivo));
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
            Celular producto = new Celular("testModel", "1", "16", "13", ETamanio.Chico.ToString(), EMarca.Generico.ToString());
            
            string rutaDePrueba = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\Cea.Lorenzo.2A.TPFinal.UnitTest";
            string archivo = rutaDePrueba + "\\DebeGenerarYLeerXml.xml";
            Directory.CreateDirectory(rutaDePrueba);

            try
            {
                Assert.IsTrue(Fabrica.GuardarComoXml(rutaDePrueba + "\\DebeGenerarYLeerXml", producto));

                Producto productoRecuperadoXml = Fabrica.LeerArchivoXml(archivo);

                Assert.IsTrue(!(productoRecuperadoXml is null));
                Assert.IsTrue(productoRecuperadoXml == producto);
            }
            finally
            {
                Directory.Delete(rutaDePrueba, true);
            }
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

        /// <summary>
        /// Test unitario para probar la conexión a la base.
        /// </summary>
        [TestMethod]
        public void TestConnectionString()
        {
            Assert.IsTrue(Fabrica.TestConnectionString(), "No se pudo conectar a la base de datos.");
        }

        /// <summary>
        /// Test unitario para probar que se inserte un registro exitosamente.
        /// </summary>
        [TestMethod]
        public void DebeInsertarUnRegistroEnLaBase()
        {
            Celular testCelular = new Celular("DebeInsertarUnRegistroEnLaBase", "4", "64", "13", ETamanio.Mediano.ToString(), EMarca.Snapdragon.ToString());

            Assert.IsTrue(Fabrica.GuardarEnLaBase(testCelular), "No se pudo guardar el registro en la base de datos.");
        }
    }
}
