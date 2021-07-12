using System;

namespace Excepciones
{
    /// <summary>
    /// Excepcion hecha para situaciones en que se haga referencia a un objeto
    /// que no se encuentra en una lista determinada.
    /// </summary>
    public class RemoverObjetoException : Exception
    {
        public RemoverObjetoException() : this("EL OBJETO NO ESTA INCLUIDO EN LA LISTA!")
        {
        }

        public RemoverObjetoException(Exception e) : this("EL OBJETO NO ESTA INCLUIDO EN LA LISTA!", e)
        {
        }

        public RemoverObjetoException(string mensaje) : base(mensaje)
        {
        }

        public RemoverObjetoException(string mensaje, Exception e) : base(mensaje, e)
        {
        }
    }
}
