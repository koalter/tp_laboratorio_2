using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Fabrica<T> where T : class
	{
		private int _capacidad;
		private List<T> _lista;

		private Fabrica()
		{
			_lista = new List<T>();
		}

		public Fabrica(int capacidad)
			: this()
        {
			_capacidad = capacidad;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var elemento in _lista)
            {
                sb.AppendLine();
                sb.AppendLine($"{elemento.GetType().Name}, {elemento}");
                sb.AppendLine("---------------------");
            }

            return sb.ToString();
        }

        private void Agregar(T obj)
        {
            if (obj is null) throw new NullReferenceException();

            if (this._lista.Count >= this._capacidad) throw new FabricaLlenaException();

            foreach (var elemento in this._lista)
            {
                if (elemento.Equals(obj))
                    throw new AgregarObjetoException();
            }

            this._lista.Add(obj);
        }

        private void Remover(T obj)
        {
            int indice = _lista.IndexOf(obj);

            if (indice < 0)
            {
                throw new RemoverObjetoException();
            }

            this._lista.RemoveAt(indice);
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
