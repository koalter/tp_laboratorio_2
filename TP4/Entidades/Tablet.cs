using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Excepciones;
using Archivos;

namespace Entidades
{
	public class Tablet : Producto, IArchivos<Tablet>
	{
		public Tablet() : base()
        {

        }

		public Tablet(string modelo, string ram, string rom, string megapixeles, string procesador)
			: base(modelo, ram, rom, ETamanio.Grande.ToString(), procesador, megapixeles)
		{

		}

		public Tablet(string modelo, string ram, string rom, string megapixeles)
			: this(modelo, ram, rom, megapixeles, EMarca.Generico.ToString())
		{ 
        
        }

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

        bool IArchivos<Tablet>.Guardar(string archivo, Tablet datos)
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

        bool IArchivos<Tablet>.Leer(string archivo, out Tablet tablet)
        {
            SqlConnection connection = new SqlConnection(archivo);
            SqlCommand comando = connection.CreateCommand();
            StringBuilder stringBuilder = new StringBuilder();
            Tablet data = null;

            stringBuilder.AppendLine("SELECT TOP 1 Modelo, Ram, Rom, Tamanio, Procesador, Camara FROM Productos");
            comando.CommandType = CommandType.Text;
            comando.CommandText = stringBuilder.ToString();

            try
            {
                connection.Open();
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    data = new Tablet(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                        dataReader.GetString(5), dataReader.GetString(4));
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
                
                tablet = data;
            }
        }
    }
}
