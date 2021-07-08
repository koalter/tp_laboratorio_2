using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
	public class Celular : Producto, IArchivos<Celular>
	{
		public Celular() : base()
        {

        }

		public Celular(string modelo, string ram, string rom, string megapixeles, string tamanio, string procesador)
			: base(modelo, ram, rom, tamanio, procesador, megapixeles)
		{

		}

		public Celular(string modelo, string ram, string rom, string megapixeles, string tamanio)
			: this(modelo, ram, rom, megapixeles, tamanio, EMarca.Generico.ToString())
        {

        }

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

        bool IArchivos<Celular>.Guardar(string archivo, Celular datos)
        {
            SqlConnection connection = new SqlConnection(archivo);
            SqlCommand comando = connection.CreateCommand();
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("INSERT INTO Productos (Modelo, Ram, Rom, Tamanio, Procesador, Camara) VALUES");
            stringBuilder.AppendLine("(@modelo, @ram, @rom, @tamanio, @procesador, @camara)");
            comando.CommandType = CommandType.Text;
            comando.CommandText = stringBuilder.ToString();
            comando.Parameters.AddWithValue("@modelo", datos.Modelo);
            comando.Parameters.AddWithValue("@ram", datos.Ram);
            comando.Parameters.AddWithValue("@rom", datos.Rom);
            comando.Parameters.AddWithValue("@tamanio", datos.Tamanio);
            comando.Parameters.AddWithValue("@procesador", datos.Procesador);
            comando.Parameters.AddWithValue("@camara", datos.Megapixeles);

            try
            {
                connection.Open();
                int registrosInsertados = comando.ExecuteNonQuery();
                return registrosInsertados == 1;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        bool IArchivos<Celular>.Leer(string archivo, out Celular celular)
        {
            SqlConnection connection = new SqlConnection(archivo);
            SqlCommand comando = connection.CreateCommand();
            StringBuilder stringBuilder = new StringBuilder();
            Celular data = null;

            stringBuilder.AppendLine("SELECT TOP 1 Modelo, Ram, Rom, Tamanio, Procesador, Camara FROM Productos");
            comando.CommandType = CommandType.Text;
            comando.CommandText = stringBuilder.ToString();

            try
            {
                connection.Open();
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    data = new Celular(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                        dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5));
                }

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                celular = data;
            }
        }
    }
}
