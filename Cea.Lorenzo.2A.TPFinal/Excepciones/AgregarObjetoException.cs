using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AgregarObjetoException : Exception
    {
        private string mensajeBase;

        public AgregarObjetoException() : this("NO FUE POSIBLE AGREGAR EL OBJETO!")
        {
        }

        public AgregarObjetoException(Exception e) : this("NO FUE POSIBLE AGREGAR EL OBJETO!", e)
        {
        }

        public AgregarObjetoException(string mensaje) : base(mensaje)
        {
            mensajeBase = mensaje;
        }

        public AgregarObjetoException(string mensaje, Exception e) : base(mensaje, e)
        {
            mensajeBase = mensaje;
        }
    }
}
