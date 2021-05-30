using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class RemoverObjetoException : Exception
    {
        private string mensajeBase;

        public RemoverObjetoException() : this("EL OBJETO NO ESTA INCLUIDO EN LA LISTA!")
        {
        }

        public RemoverObjetoException(Exception e) : this("EL OBJETO NO ESTA INCLUIDO EN LA LISTA!", e)
        {
        }

        public RemoverObjetoException(string mensaje) : base(mensaje)
        {
            mensajeBase = mensaje;
        }

        public RemoverObjetoException(string mensaje, Exception e) : base(mensaje, e)
        {
            mensajeBase = mensaje;
        }
    }
}
