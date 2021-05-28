using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class Celular : Producto
	{
		private int _megapixeles;

		public int Megapixeles
		{
			get
			{
				return _megapixeles;
			}
		}

		public Celular(string modelo, int ram, int rom, int megapixeles, ETamanio tamanio, EMarca procesador)
			: base(modelo, ram, rom, tamanio, procesador)
		{
			_megapixeles = megapixeles;
		}

		public Celular(string modelo, int ram, int rom, int megapixeles, ETamanio tamanio)
			: this(modelo, ram, rom, megapixeles, tamanio, EMarca.Generico)
		{ }

		public static bool operator ==(Celular c1, Celular c2)
		{
			return (Producto)c1 == c2
				&& c1.Megapixeles == c2.Megapixeles;
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
			sb.Append(base.ToString());
			sb.AppendLine($"CAMARA: {Megapixeles}mpx");

			return sb.ToString();
        }
    }
}
