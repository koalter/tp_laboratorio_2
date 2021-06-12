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
		public ETamanio Tamanio
		{
			get
			{
				return _tamanio;
			}
			protected set
            {
				_tamanio = value;
            }
		}

		public EMarca Procesador
		{
			get
			{
				return _procesador;
			}
			protected set
			{
				_procesador = value;
			}
		}

		public int Ram
		{
			get
			{
				return _ram;
			}
			protected set
            {
				if (value <= 0 || value > 16)
                {
					throw new ValorInvalidoException();
                }
				
				_ram = value;
            }
		}

		public int Rom
		{
			get
			{
				return _rom;
			}
			protected set
			{
				if (value <= 0 || value > 256)
				{
					throw new ValorInvalidoException();
				}

				_rom = value;
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
					throw new ValorInvalidoException();
				}

				_modelo = value;
			}
		}
        #endregion

        public Producto(string modelo, int ram, int rom, ETamanio tamanio, EMarca procesador)
		{
			Modelo = modelo;
			Ram = ram;
			Rom = rom;
			Tamanio = tamanio;
			Procesador = procesador;
		}

		public static bool operator ==(Producto p1, Producto p2)
        {
			return p1.Tamanio == p2.Tamanio
				&& p1.Procesador == p2.Procesador
				&& p1.Ram == p2.Ram
				&& p1.Rom == p2.Rom
				&& p1.Modelo == p2.Modelo;
        }

		public static bool operator !=(Producto p1, Producto p2)
		{
			return !(p1 == p2);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append($"{Modelo}, {Tamanio}, {Procesador}, {Ram}GB, {Rom}GB");
			//sb.AppendLine("---------------------");

			return sb.ToString();
		}

		//     public override string ToString()
		//     {
		//StringBuilder sb = new StringBuilder();

		//sb.AppendLine($"MODELO: {Modelo}");
		//sb.AppendLine($"TAMAÑO: {Tamanio}");
		//sb.AppendLine($"PROCESADOR: {Procesador}");
		//sb.AppendLine($"RAM: {Ram}");
		//sb.AppendLine($"ROM: {Rom}");
		////sb.AppendLine("---------------------");

		//return sb.ToString();
		//     }
	}
}
