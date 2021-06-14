using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
	public abstract class Producto
	{
		protected ETamanio _tamanio;
		protected EMarca _procesador;
		protected int _ram;
		protected int _rom;
		protected string _modelo;

		#region Propiedades
		public string Tamanio
		{
			get
			{
				return _tamanio.ToString();
			}
			protected set
            {
				if (!Enum.TryParse(value, out ETamanio tamanio))
                {
					throw new ValorInvalidoException("Tamaño");
                }

				_tamanio = tamanio;
            }
		}

		public string Procesador
		{
			get
			{
				return _procesador.ToString();
			}
			protected set
			{
				if (!Enum.TryParse(value, out EMarca procesador))
				{
					throw new ValorInvalidoException("Procesador");
				}
				_procesador = procesador;
			}
		}

		public string Ram
		{
			get
			{
				return _ram.ToString();
			}
			protected set
            {
				if (!int.TryParse(value, out int ram)
					|| (ram <= 0 || ram > 16))
                {
					throw new ValorInvalidoException("RAM");
                }
				
				_ram = ram;
            }
		}

		public string Rom
		{
			get
			{
				return _rom.ToString();
			}
			protected set
			{
				if (!int.TryParse(value, out int rom)
					|| (rom <= 0 || rom > 256))
				{
					throw new ValorInvalidoException("ROM");
				}

				_rom = rom;
			}
		}

		public string Modelo
		{
			get
			{
				return _modelo;
			}
			protected set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ValorInvalidoException("Modelo");
				}

				_modelo = value;
			}
		}
        #endregion

		public Producto() { }

        public Producto(string modelo, string ram, string rom, string tamanio, string procesador)
		{
			Modelo = modelo;
			Ram = ram;
			Rom = rom;
			Tamanio = tamanio;
			Procesador = procesador;
		}

		public static bool operator ==(Producto p1, Producto p2)
        {
			return p1._tamanio == p2._tamanio
				&& p1._procesador == p2._procesador
				&& p1._ram == p2._ram
				&& p1._rom == p2._rom
				&& p1._modelo == p2._modelo;
        }

		public static bool operator !=(Producto p1, Producto p2)
		{
			return !(p1 == p2);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append($"{this.GetType().Name}, {Modelo}, {Tamanio}, {Procesador}, {Ram}GB, {Rom}GB");
			//sb.AppendLine("---------------------");

			return sb.ToString();
		}
	}
}
