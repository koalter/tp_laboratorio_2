using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Entidades
{
	public class Fabrica<T> where T : class
	{
		private List<T> _lista;

		public Fabrica()
		{
			_lista = new List<T>();
		}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var elemento in _lista)
            {
                //sb.AppendLine();
                sb.AppendLine(elemento.ToString());
                //sb.AppendLine("---------------------");
            }

            return sb.ToString();
        }

        private void Agregar(T obj)
        {
            if (obj is null) throw new NullReferenceException("No hay objeto para agregar!");

            foreach (var elemento in this._lista)
            {
                if (elemento.Equals(obj))
                    throw new AgregarObjetoException();
            }

            this._lista.Add(obj);
        }

        private void Remover(T obj)
        {
            if (obj is null) throw new NullReferenceException();

            int indice = _lista.IndexOf(obj);

            if (indice < 0)
            {
                throw new RemoverObjetoException();
            }

            this._lista.RemoveAt(indice);
        }

        public bool GuardarComoTexto(string archivo)
        {
            Texto texto = new Texto();
            return texto.Guardar(archivo, this.ToString());
        }

        public bool GuardarComoXml(string archivo)
        {
            Xml<Fabrica<T>> xml = new Xml<Fabrica<T>>();
            return xml.Guardar(archivo, this);
        }

        public string LeerArchivoTexto(string archivo)
        {
            Texto texto = new Texto();
            if (texto.Leer(archivo, out string datos))
            {
                return datos;
            }

            return string.Empty;
        }

        public Fabrica<T> LeerArchivoXml(string archivo)
        {
            Xml<Fabrica<T>> xml = new Xml<Fabrica<T>>();
            if (xml.Leer(archivo, out Fabrica<T> datos))
            {
                return datos;
            }

            return null;
        }

        public static Fabrica<T> operator +(Fabrica<T> fabrica, T obj)
        {
            fabrica.Agregar(obj);

            return fabrica;
        }

        public static Fabrica<T> operator -(Fabrica<T> fabrica, T obj)
        {
            fabrica.Remover(obj);
            
            return fabrica;
        }
    }
}
