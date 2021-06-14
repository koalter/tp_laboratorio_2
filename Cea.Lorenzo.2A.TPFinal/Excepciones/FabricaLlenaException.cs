using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class FabricaLlenaException : Exception
    {
        private string mensajeBase;

        public FabricaLlenaException() : this("Se ha excedido la capacidad máxima de la fábrica!")
        {
        }

        public FabricaLlenaException(Exception e) : this("Se ha excedido la capacidad máxima de la fábrica!", e)
        {
        }

        public FabricaLlenaException(string mensaje) : base(mensaje)
        {
            mensajeBase = mensaje;
        }

        public FabricaLlenaException(string mensaje, Exception e) : base(mensaje, e)
        {
            mensajeBase = mensaje;
        }
    }
}
