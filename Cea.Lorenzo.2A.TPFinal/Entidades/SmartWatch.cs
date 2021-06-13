using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class SmartWatch : Producto
	{
		public SmartWatch(string modelo, string ram, string rom, string procesador)
			: base(modelo, ram, rom, ETamanio.Chico.ToString(), procesador)
		{ }

		public SmartWatch(string modelo, string ram, string rom)
			: this(modelo, ram, rom, EMarca.Generico.ToString())
		{ }

		public override bool Equals(object obj)
		{
			return !(obj is null)
				&& obj is SmartWatch smartWatch
				&& this == smartWatch;
		}
	}
}
