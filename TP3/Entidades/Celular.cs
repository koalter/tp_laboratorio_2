using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
	public class Celular : Producto
	{
		private int _megapixeles;

		public string Megapixeles
		{
			get
			{
				return _megapixeles.ToString();
			}
			set
            {
				if (!int.TryParse(value, out int megapixeles)
					|| (megapixeles <= 0 || megapixeles > 64))
                {
					throw new ValorInvalidoException("Cámara");
				}

				_megapixeles = megapixeles;
            }
		}

		public Celular() : base() { }

		public Celular(string modelo, string ram, string rom, string megapixeles, string tamanio, string procesador)
			: base(modelo, ram, rom, tamanio, procesador)
		{
			Megapixeles = megapixeles;
		}

		public Celular(string modelo, string ram, string rom, string megapixeles, string tamanio)
			: this(modelo, ram, rom, megapixeles, tamanio, EMarca.Generico.ToString())
		{ }

		public static bool operator ==(Celular c1, Celular c2)
		{
			return (Producto)c1 == c2
				&& c1._megapixeles == c2._megapixeles;
		}

		public static bool operator !=(Celular c1, Celular c2)
		{
			return !(c1 == c2);
		}

        public override bool Equals(object obj)
        {
            return !(obj is null)
				&& obj is Celular celular
				&& this == celular;
        }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append($"{base.ToString()}, {Megapixeles}mpx");

			return sb.ToString();
		}
	}
}
