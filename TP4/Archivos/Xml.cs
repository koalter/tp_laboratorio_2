using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Archivos
{
    /// <summary>
    /// Es la clase que va a manejar el guardado y lectura de archivos XML. 
    /// Se usa de manera genérica para que sus métodos sean compatibles con cualquier clase que se implemente.
    /// </summary>
    /// <typeparam name="T">Tipo de dato que va a guardar/leer</typeparam>
    public class Xml<T> : IArchivos<T>
    {
        /// <summary>
        /// Genera un archivo en disco en formato XML. 
        /// </summary>
        /// <param name="archivo">Ruta donde se guardará el archivo.</param>
        /// <param name="datos">Los datos que contendrá el archivo.</param>
        /// <returns>Verifica que se haya generado el archivo deseado.</returns>
        public bool Guardar(string archivo, T datos)
        {
            if (archivo != null && datos != null)
            {
                XmlTextWriter file = new XmlTextWriter(archivo + ".xml", Encoding.UTF8);
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(file, datos);
                file.Close();
            }

            return File.Exists(archivo + ".xml");
        }

        /// <summary>
        /// Lee un archivo en formato XML.
        /// </summary>
        /// <param name="archivo">Ruta donde está ubicado el archivo.</param>
        /// <param name="datos">Datos que contiene el archivo.</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader file = new XmlTextReader(archivo);
            XmlSerializer xml = new XmlSerializer(typeof(T));

            datos = (T)xml.Deserialize(file);
            file.Close();
            return File.Exists(archivo);
        }
    }
}
