using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion hecha para el caso en que se quiera agregar un objeto ya existente.
    /// </summary>
    public class AgregarObjetoException : Exception
    {
        public AgregarObjetoException() : this("EL OBJETO YA EXISTE!")
        {
        }

        public AgregarObjetoException(Exception e) : this("EL OBJETO YA EXISTE!", e)
        {
        }

        public AgregarObjetoException(string mensaje) : base(mensaje)
        {
        }

        public AgregarObjetoException(string mensaje, Exception e) : base(mensaje, e)
        {
        }
    }
}
