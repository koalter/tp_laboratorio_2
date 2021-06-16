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

		public string Megapixeles
		{
			get
			{
				return _megapixeles.ToString();
			}
			protected set
			{
				if (!int.TryParse(value, out int megapixeles)
					|| (megapixeles <= 0 || megapixeles > 64))
				{
					throw new ValorInvalidoException("Cámara");
				}

				_megapixeles = megapixeles;
			}
		}

		public Tablet() : base() { }
		public Tablet(string modelo, string ram, string rom, string megapixeles, string procesador)
			: base(modelo, ram, rom, ETamanio.Grande.ToString(), procesador)
		{
			Megapixeles = megapixeles;
		}

		public Tablet(string modelo, string ram, string rom, string megapixeles)
			: this(modelo, ram, rom, megapixeles, EMarca.Generico.ToString())
		{ }

		public static bool operator ==(Tablet t1, Tablet t2)
		{
			return (Producto)t1 == t2
				&& t1._megapixeles == t2._megapixeles;
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
			sb.Append($"{base.ToString()}, {Megapixeles}mpx");

			return sb.ToString();
		}
	}
}
