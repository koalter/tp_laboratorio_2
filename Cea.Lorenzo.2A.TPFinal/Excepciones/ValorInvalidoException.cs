using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ValorInvalidoException : Exception
    {
        private string mensajeBase;

        public ValorInvalidoException() : this("El valor ingresado es inválido o está vacío!")
        {
        }

        public ValorInvalidoException(Exception e) : this("El valor ingresado es inválido o está vacío!", e)
        {
        }

        public ValorInvalidoException(string mensaje) : base(mensaje)
        {
            mensajeBase = mensaje;
        }

        public ValorInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {
            mensajeBase = mensaje;
        }
    }
}
