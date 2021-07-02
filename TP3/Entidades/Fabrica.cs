using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Entidades
{
    /// <summary>
    /// Es la clase que va a contener la información de nuestra aplicación. 
    /// Se usa de manera genérica con vistas a futuro para otros usos fuera del TP.
    /// </summary>
    /// <typeparam name="T">Tipo de objeto que va a contener la Fabrica</typeparam>
	public class Fabrica<T> where T : class
	{
		private List<T> lista;

		public Fabrica()
		{
			lista = new List<T>();
		}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var elemento in lista)
            {
                //sb.AppendLine();
                sb.AppendLine(elemento.ToString());
                //sb.AppendLine("---------------------");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Agrega un elemento a la lista de la Fabrica, siempre y cuando no haya sido incluída previamente
        /// (se implementa con el operador "+" de la Fabrica)
        /// </summary>
        /// <param name="obj"></param>
        private void Agregar(T obj)
        {
            if (obj is null) throw new NullReferenceException("No hay objeto para agregar!");

            foreach (var elemento in this.lista)
            {
                if (elemento.Equals(obj))
                    throw new AgregarObjetoException();
            }

            this.lista.Add(obj);
        }

        /// <summary>
        /// Remueve un elemento compatible de la lista de la Fabrica, verificando que se haga referencia
        /// a un objeto no nulo y que esté incluída en la Fabrica. (se implementa con el operador "-" de la Fabrica)
        /// </summary>
        /// <param name="obj"></param>
        private void Remover(T obj)
        {
            if (obj is null) throw new NullReferenceException();

            int indice = lista.IndexOf(obj);

            if (indice < 0)
            {
                throw new RemoverObjetoException();
            }

            this.lista.RemoveAt(indice);
        }

        /// <summary>
        /// Borra todos los elementos contenidos en la lista de la Fabrica
        /// </summary>
        public void Limpiar()
        {
            this.lista.Clear();
        }

        /// <summary>
        /// Guarda los datos de la Fabrica en un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public bool GuardarComoTexto(string archivo)
        {
            Texto texto = new Texto();
            return texto.Guardar(archivo, this.ToString());
        }

        /// <summary>
        /// Guarda los datos de la lista de la Fabrica en un archivo xml,
        /// que luego podrá usarse para leerse y cargar esos mismos datos
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public bool GuardarComoXml(string archivo)
        {
            Xml<List<T>> xml = new Xml<List<T>>();
            return xml.Guardar(archivo, lista);
        }

        /// <summary>
        /// Lee un archivo de texto
        /// (TODO: se puede borrar este método ya que no cumple una función necesaria para Fabrica)
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public string LeerArchivoTexto(string archivo)
        {
            Texto texto = new Texto();
            if (texto.Leer(archivo, out string datos))
            {
                return datos;
            }

            return string.Empty;
        }

        /// <summary>
        /// Lee los datos de un archivo xml compatible para la Fabrica
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public List<T> LeerArchivoXml(string archivo)
        {
            Xml<List<T>> xml = new Xml<List<T>>();
            if (xml.Leer(archivo, out List<T> datos))
            {
                return datos;
            }

            return null;
        }

        /// <summary>
        /// Operador suma de Fabrica.
        /// Implementa el método Agregar.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Fabrica<T> operator +(Fabrica<T> fabrica, T obj)
        {
            fabrica.Agregar(obj);

            return fabrica;
        }

        /// <summary>
        /// Operador resta de Fabrica.
        /// Implementa el método Remover.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Fabrica<T> operator -(Fabrica<T> fabrica, T obj)
        {
            fabrica.Remover(obj);
            
            return fabrica;
        }
    }
}
