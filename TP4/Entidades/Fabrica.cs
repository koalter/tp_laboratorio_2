using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    /// <summary>
    /// Es la clase que va a contener la información de nuestra aplicación. 
    /// Se usa de manera genérica con vistas a futuro para otros usos fuera del TP.
    /// </summary>
    /// <typeparam name="T">Tipo de objeto que va a contener la Fabrica</typeparam>
	public class Fabrica : IArchivos<Fabrica>
	{
		private List<Producto> lista;
        public event CambioStatus CambiarStatusEvent;

		public Fabrica()
		{
			lista = new List<Producto>();
		}

        public void CambiarStatus(object producto)
        {
            CambiarStatusEvent(producto);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var elemento in lista)
            {
                //sb.AppendLine();
                sb.AppendLine(elemento.ToString());
                //sb.AppendLine("---------------------");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Agrega un elemento a la lista de la Fabrica, siempre y cuando no haya sido incluída previamente
        /// (se implementa con el operador "+" de la Fabrica)
        /// </summary>
        /// <param name="obj"></param>
        private void Agregar(Producto obj)
        {
            if (obj is null) throw new NullReferenceException("No hay objeto para agregar!");

            foreach (var elemento in this.lista)
            {
                if (elemento.Equals(obj))
                    throw new AgregarObjetoException();
            }

            this.lista.Add(obj);
        }

        /// <summary>
        /// Remueve un elemento compatible de la lista de la Fabrica, verificando que se haga referencia
        /// a un objeto no nulo y que esté incluída en la Fabrica. (se implementa con el operador "-" de la Fabrica)
        /// </summary>
        /// <param name="obj"></param>
        private void Remover(Producto obj)
        {
            if (obj is null) throw new NullReferenceException();

            int indice = lista.IndexOf(obj);

            if (indice < 0)
            {
                throw new RemoverObjetoException();
            }

            this.lista.RemoveAt(indice);
        }

        /// <summary>
        /// Borra todos los elementos contenidos en la lista de la Fabrica
        /// </summary>
        public void Limpiar()
        {
            this.lista.Clear();
        }

        /// <summary>
        /// Guarda los datos de la Fabrica en un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public bool GuardarComoTexto(string archivo)
        {
            Texto texto = new Texto();
            return texto.Guardar(archivo, this.ToString());
        }

        /// <summary>
        /// Guarda los datos de la lista de la Fabrica en un archivo xml,
        /// que luego podrá usarse para leerse y cargar esos mismos datos
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public bool GuardarComoXml(string archivo)
        {
            Xml<List<Producto>> xml = new Xml<List<Producto>>();
            return xml.Guardar(archivo, lista);
        }

        /// <summary>
        /// Lee un archivo de texto
        /// (TODO: se puede borrar este método ya que no cumple una función necesaria para Fabrica)
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public string LeerArchivoTexto(string archivo)
        {
            Texto texto = new Texto();
            if (texto.Leer(archivo, out string datos))
            {
                return datos;
            }

            return string.Empty;
        }

        /// <summary>
        /// Lee los datos de un archivo xml compatible para la Fabrica
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public List<Producto> LeerArchivoXml(string archivo)
        {
            Xml<List<Producto>> xml = new Xml<List<Producto>>();
            if (xml.Leer(archivo, out List<Producto> datos))
            {
                return datos;
            }

            return null;
        }

        /// <summary>
        /// Guarda un Producto en la base de datos
        /// </summary>
        /// <param name="connectionString">la cadena a donde se hará la conexión a la base</param>
        /// <param name="producto">el producto a guardar</param>
        /// <returns></returns>
        public static bool GuardarEnLaBase(string connectionString, Producto producto)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand comando = connection.CreateCommand();
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("INSERT INTO Productos (Modelo, Ram, Rom, Tamanio, Procesador, Camara, Tipo) VALUES");
            stringBuilder.AppendLine("(@modelo, @ram, @rom, @tamanio, @procesador, @camara, @tipo)");
            
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@modelo", producto.Modelo);
            comando.Parameters.AddWithValue("@ram", producto.Ram);
            comando.Parameters.AddWithValue("@rom", producto.Rom);
            comando.Parameters.AddWithValue("@tamanio", producto.Tamanio);
            comando.Parameters.AddWithValue("@procesador", producto.Procesador);
            comando.Parameters.AddWithValue("@camara", producto.Megapixeles);
            comando.Parameters.AddWithValue("@tipo", producto.GetType().Name);
            comando.CommandText = stringBuilder.ToString();

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

        public static Fabrica LeerDeLaBase(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand comando = connection.CreateCommand();
            StringBuilder stringBuilder = new StringBuilder();
            Fabrica datosDeLaBase = new Fabrica();

            stringBuilder.AppendLine("SELECT Modelo, Ram, Rom, Tamanio, Procesador, Camara, Tipo FROM Productos");
            comando.CommandType = CommandType.Text;
            comando.CommandText = stringBuilder.ToString();

            try
            {
                connection.Open();
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    string modelo = dataReader.GetString(0);
                    string ram = dataReader.GetString(1);
                    string rom = dataReader.GetString(2);
                    string tamanio = dataReader.GetString(3);
                    string procesador = dataReader.GetString(4);
                    string camara = dataReader.GetString(5);
                    string tipo = dataReader.GetString(6);
                    
                    switch (tipo.ToLower())
                    {
                        case "celular":
                            datosDeLaBase += new Celular(modelo, ram, rom, camara, tamanio, procesador);
                            break;
                        case "tablet":
                            datosDeLaBase += new Tablet(modelo, ram, rom, camara, procesador);
                            break;
                        case "smartwatch":
                            datosDeLaBase += new SmartWatch(modelo, ram, rom, procesador);
                            break;
                        default:
                            datosDeLaBase += new Producto(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                                dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5));
                            break;
                    }
                }

                return datosDeLaBase;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Guarda los Productos de la Fabrica en la base de datos
        /// </summary>
        /// <param name="archivo">la cadena a donde se hará la conexión a la base</param>
        /// <param name="datos">objeto Fabrica de la cual se tomará la información para registrar en la base</param>
        /// <returns></returns>
        [Obsolete]
        bool IArchivos<Fabrica>.Guardar(string archivo, Fabrica datos)
        {
            SqlConnection connection = new SqlConnection(archivo);
            SqlCommand comando = connection.CreateCommand();
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("INSERT INTO Productos (Modelo, Ram, Rom, Tamanio, Procesador, Camara) VALUES");
            for (int i = 0; i < datos.lista.Count; i++)
            {
                stringBuilder.AppendFormat("('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                    datos.lista[i].Modelo, datos.lista[i].Ram, datos.lista[i].Rom, datos.lista[i].Tamanio, datos.lista[i].Procesador, datos.lista[i].Megapixeles);

                if (i != datos.lista.Count - 1)
                {
                    stringBuilder.AppendLine(",");
                }
            }

            comando.CommandType = CommandType.Text;
            comando.CommandText = stringBuilder.ToString();

            try
            {
                connection.Open();
                int registrosInsertados = comando.ExecuteNonQuery();
                return registrosInsertados == datos.lista.Count;
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

        /// <summary>
        /// Hace una lectura de la base de datos y recupera la información de la misma dentro de la Fabrica
        /// insertada por parámetro.
        /// </summary>
        /// <param name="archivo">la cadena a donde se hará la conexión a la base</param>
        /// <param name="datos">objeto Fabrica de la cual se adjuntará la información tomada de la base</param>
        /// <returns></returns>
        [Obsolete]
        bool IArchivos<Fabrica>.Leer(string archivo, out Fabrica datos)
        {
            SqlConnection connection = new SqlConnection(archivo);
            SqlCommand comando = connection.CreateCommand();
            StringBuilder stringBuilder = new StringBuilder();
            Fabrica datosDeLaBase = new Fabrica();

            stringBuilder.AppendLine("SELECT Modelo, Ram, Rom, Tamanio, Procesador, Camara FROM Productos");
            comando.CommandType = CommandType.Text;
            comando.CommandText = stringBuilder.ToString();

            try
            {
                connection.Open();
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    datosDeLaBase += new Producto(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
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


                datos = datosDeLaBase;
            }
        }

        /// <summary>
        /// Método para testear la conexión a la base de datos
        /// </summary>
        /// <param name="connectionString">la cadena a donde se hará la conexión a la base</param>
        /// <returns></returns>
        public static bool TestConnectionString(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
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
            }
        }

        /// <summary>
        /// Operador suma de Fabrica.
        /// Implementa el método Agregar.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Fabrica operator +(Fabrica fabrica, Producto obj)
        {
            fabrica.Agregar(obj);

            return fabrica;
        }

        /// <summary>
        /// Operador resta de Fabrica.
        /// Implementa el método Remover.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Fabrica operator -(Fabrica fabrica, Producto obj)
        {
            fabrica.Remover(obj);
            
            return fabrica;
        }
    }
}
