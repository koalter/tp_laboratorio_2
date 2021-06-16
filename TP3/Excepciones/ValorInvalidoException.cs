using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ValorInvalidoException : Exception
    {
        public ValorInvalidoException() : this("El valor ingresado es inválido o está vacío!")
        {
        }

        public ValorInvalidoException(Exception e) : this($"El valor ingresado {e.Source} es inválido o está vacío!", e)
        {
        }

        public ValorInvalidoException(string parametro) : base($"El valor ingresado {parametro} es inválido o está vacío!")
        {
        }

        public ValorInvalidoException(string parametro, Exception e) : base($"El valor ingresado {parametro} es inválido o está vacío!", e)
        {
        }
    }
}
