using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Entidades;
using Excepciones;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string archivo = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\Productos\\test";

            Fabrica<Producto> fabrica = new Fabrica<Producto>();

            Celular c1 = new Celular("Redmi 9", "2", "64", "13", "Mediano", "Helio");
            Producto c2 = new Celular("A01 Core", "1", "16", "5", "Chico", "Exynos");
            Tablet t1 = new Tablet("A08", "2", "32", "8", EMarca.Exynos.ToString());
            Tablet t2 = new Tablet("TM-1640A7", "2", "32", "5");
            SmartWatch s1 = new SmartWatch("GT-1054", "1", "8", "Snapdragon");
            SmartWatch s2 = new SmartWatch("FM-6654", "1", "8");

            Producto productoInvalido;
            try // ValorInvalidoException
            {
                productoInvalido = new Celular("", "0", "0", "0", "Mediano", "Exynos");
            }
            catch (ValorInvalidoException e)
            {
                Console.WriteLine(e.Message);
                productoInvalido = null;
            }

            fabrica += c1;
            fabrica += t1;
            fabrica += s1;

            // No deberia dejar agregar estos objetos
            try
            {
                fabrica += productoInvalido;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                fabrica += null;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine(fabrica.ToString());
            Console.WriteLine("<-------------------PRESIONE UNA TECLA PARA CONTINUAR------------------->");
            Console.ReadLine();
            Console.Clear();

            // Deberia remover t1 e impedir agregar c1 de nuevo al estar ya incluido en la fabrica
            fabrica -= t1;
            try
            {
                fabrica += c1;
            }
            catch (AgregarObjetoException e)
            {
                Console.WriteLine(e.Message);
            }

            fabrica += c2;

            Console.WriteLine();
            Console.WriteLine(fabrica.ToString());
            Console.WriteLine("<-------------------PRESIONE UNA TECLA PARA CONTINUAR------------------->");
            Console.ReadLine();
            Console.Clear();

            fabrica -= s1;
            try //RemoverObjetoException
            {
                fabrica -= t1;
            }
            catch (RemoverObjetoException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine(fabrica.ToString());
            Console.WriteLine("<-------------------PRESIONE UNA TECLA PARA CONTINUAR------------------->");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("PROBANDO GuardarComoTexto");
            Directory.CreateDirectory(archivo);
            fabrica.GuardarComoTexto(archivo + "\\test");
            
            Console.WriteLine();
            Console.WriteLine(fabrica.LeerArchivoTexto(archivo + "\\test.txt"));
            Console.WriteLine("<-------------------PRESIONE UNA TECLA PARA CONTINUAR------------------->");
            Console.ReadLine();

            Console.WriteLine("PROBANDO GuardarComoXml");
            Directory.CreateDirectory(archivo);
            fabrica.GuardarComoXml(archivo + "\\test");

            fabrica.Limpiar();

            List<Producto> nuevaListaDeProductos = new List<Producto>(fabrica.LeerArchivoXml(archivo + "\\test.xml"));

            foreach (Producto producto in nuevaListaDeProductos)
            {
                fabrica += producto;
            }

            Console.WriteLine();
            Console.WriteLine(fabrica);
            Console.WriteLine("<-------------------PRESIONE UNA TECLA PARA CONTINUAR------------------->");
            Console.ReadLine();
        }
    }
}
