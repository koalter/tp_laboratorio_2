using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Fabrica<Producto> fabrica = new Fabrica<Producto>(10);

            Console.ReadLine();
        }
    }
}
