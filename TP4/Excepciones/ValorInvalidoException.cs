using System;

namespace Excepciones
{
    /// <summary>
    /// Excepcion hecha para el caso en que se vaya a ingresar un dato inválido
    /// (como por ejemplo un caracter para un campo numérico) o un dato vacío
    /// </summary>
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
