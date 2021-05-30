using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
	public class Tablet : Producto
	{
		private int _megapixeles;

		public int Megapixeles
		{
			get
			{
				return _megapixeles;
			}
			protected set
			{
				if (value <= 0 || value > 64)
				{
					throw new ValorInvalidoException();
				}

				_megapixeles = value;
			}
		}

		public Tablet(string modelo, int ram, int rom, int megapixeles, EMarca procesador)
			: base(modelo, ram, rom, ETamanio.Grande, procesador)
		{
			Megapixeles = megapixeles;
		}

		public Tablet(string modelo, int ram, int rom, int megapixeles)
			: this(modelo, ram, rom, megapixeles, EMarca.Generico)
		{ }

		public static bool operator ==(Tablet t1, Tablet t2)
		{
			return (Producto)t1 == t2
				&& t1.Megapixeles == t2.Megapixeles;
		}

		public static bool operator !=(Tablet t1, Tablet t2)
		{
			return !(t1 == t2);
		}

		public override bool Equals(object obj)
		{
			return !(obj is null)
				&& obj is Tablet tablet
				&& this == tablet;
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
