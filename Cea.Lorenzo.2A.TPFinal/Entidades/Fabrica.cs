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
                sb.AppendLine($"ITEM: {elemento.GetType().Name}");
                sb.Append(elemento.ToString());
                sb.AppendLine("---------------------");
            }

            return sb.ToString();
        }

        private bool Agregar(T obj)
        {
            bool retorno = false;

            if (this._lista.Count < this._capacidad)
            {
                foreach (var elemento in this._lista)
                {
                    if (elemento.Equals(obj))
                        return retorno;
                }

                retorno = true;
            }

            return retorno;
        }

        private bool Remover(T obj, out int indice)
        {
            indice = _lista.IndexOf(obj);

            return indice > -1;
        }

        public static Fabrica<T> operator +(Fabrica<T> fabrica, T obj)
        {
            if (fabrica.Agregar(obj))
            {
                fabrica._lista.Add(obj);
            }
            else //TODO reemplazar con una excepcion y controlarla
            {
                Console.WriteLine("NO FUE POSIBLE AGREGAR EL OBJETO!!!");
            }

            return fabrica;
        }

        public static Fabrica<T> operator -(Fabrica<T> fabrica, T obj)
        {
            if (fabrica.Remover(obj, out int indice))
            {
                fabrica._lista.RemoveAt(indice);
            }
            else //TODO reemplazar con una excepcion y controlarla
            {
                Console.WriteLine("EL OBJETO NO ESTA INCLUIDO EN LA LISTA!!!");
            }

                return fabrica;
        }
    }
}
