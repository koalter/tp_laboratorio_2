using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class SmartWatch : Producto
	{
		public SmartWatch(string modelo, int ram, int rom, EMarca procesador)
			: base(modelo, ram, rom, ETamanio.Chico, procesador)
		{ }

		public SmartWatch(string modelo, int ram, int rom)
			: this(modelo, ram, rom, EMarca.Generico)
		{ }

		public override bool Equals(object obj)
		{
			return !(obj is null)
				&& obj is SmartWatch smartWatch
				&& this == smartWatch;
		}
	}
}
