using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Archivos;

namespace Entidades
{
	public class SmartWatch : Producto, IArchivos<SmartWatch>
	{
		public SmartWatch() : base()
        {

        }

		public SmartWatch(string modelo, string ram, string rom, string procesador)
			: base(modelo, ram, rom, ETamanio.Chico.ToString(), procesador, "0")
        {

        }

		public SmartWatch(string modelo, string ram, string rom)
			: this(modelo, ram, rom, EMarca.Generico.ToString())
		{ 
        
        }

		public override bool Equals(object obj)
		{
			return !(obj is null)
				&& obj is SmartWatch smartWatch
				&& this == smartWatch;
		}

        bool IArchivos<SmartWatch>.Guardar(string archivo, SmartWatch datos)
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

        bool IArchivos<SmartWatch>.Leer(string archivo, out SmartWatch smartWatch)
        {
            SqlConnection connection = new SqlConnection(archivo);
            SqlCommand comando = connection.CreateCommand();
            StringBuilder stringBuilder = new StringBuilder();
            SmartWatch data = null;

            stringBuilder.AppendLine("SELECT TOP 1 Modelo, Ram, Rom, Tamanio, Procesador, Camara FROM Productos");
            comando.CommandType = CommandType.Text;
            comando.CommandText = stringBuilder.ToString();

            try
            {
                connection.Open();
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    data = new SmartWatch(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                        dataReader.GetString(5));
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

                smartWatch = data;
            }
        }
    }
}
