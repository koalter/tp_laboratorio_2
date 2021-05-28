using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}

		public EMarca Procesador
		{
			get
			{
				return _procesador;
			}
		}

		public int Ram
		{
			get
			{
				return _ram;
			}
		}

		public int Rom
		{
			get
			{
				return _rom;
			}
		}

		public string Modelo
		{
			get
			{
				return _modelo;
			}
		}
        #endregion

        public Producto(string modelo, int ram, int rom, ETamanio tamanio, EMarca procesador)
		{
			_modelo = modelo;
			_tamanio = tamanio;
			_procesador = procesador;
			_ram = ram;
			_rom = rom;
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
			
			sb.AppendLine($"MODELO: {Modelo}");
			sb.AppendLine($"TAMAÑO: {Tamanio}");
			sb.AppendLine($"PROCESADOR: {Procesador}");
			sb.AppendLine($"RAM: {Ram}");
			sb.AppendLine($"ROM: {Rom}");
			//sb.AppendLine("---------------------");

			return sb.ToString();
        }
    }
}
