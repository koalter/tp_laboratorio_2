using System;
using System.IO;
using Entidades;
using Excepciones;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string archivo = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\Productos\\test";

            Fabrica fabrica = new Fabrica();

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
            }

            fabrica += c1;
            fabrica += t1;
            fabrica += s1;
            fabrica += null; //No deberia hacer nada

            Console.WriteLine();
            Console.WriteLine(fabrica.ToString());
            Console.WriteLine("<-------------------PRESIONE UNA TECLA PARA CONTINUAR------------------->");
            Console.ReadLine();
            Console.Clear();

            fabrica -= t1;

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
            Fabrica.GuardarComoTexto(archivo + "\\test", c1);
            
            Console.WriteLine();
            Console.WriteLine(Fabrica.LeerArchivoTexto(archivo + "\\test.txt"));
            Console.WriteLine("<-------------------PRESIONE UNA TECLA PARA CONTINUAR------------------->");
            Console.ReadLine();

            Console.WriteLine("PROBANDO GuardarComoXml");
            Directory.CreateDirectory(archivo);
            Fabrica.GuardarComoXml(archivo + "\\test", c2);

            Console.WriteLine();
            Console.WriteLine(Fabrica.LeerArchivoXml(archivo + "\\test.xml"));
            Console.WriteLine("<-------------------PRESIONE UNA TECLA PARA CONTINUAR------------------->");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("PROBANDO GuardarEnLaBase");
            Console.Write("Conectando a la base...");
            
            if (Fabrica.GuardarEnLaBase(new Tablet("tablet-test-consola", "2", "32", "16", "un procesador cualquiera")))
            {
                Console.WriteLine("Conexión exitosa");
                Console.WriteLine();
                Console.WriteLine(Fabrica.LeerDeLaBase().ToString());
            }
            else
            {
                Console.WriteLine("ERROR AL CONECTAR A LA BASE");
                Console.WriteLine();
                Console.WriteLine("Verifique que connectionString este correctamente configurado en la clase Fabrica");
                Console.WriteLine();
            }

            Console.WriteLine("<-------------------PRESIONE UNA TECLA PARA CONTINUAR------------------->");
            Console.ReadLine();
        }
    }
}
