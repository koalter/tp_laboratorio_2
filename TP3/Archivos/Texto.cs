using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    /// <summary>
    /// Es la clase que va a manejar el guardado y lectura de archivos de texto. 
    /// En el sentido del TP, va a permitir guardar la información de la lista de Productos en un archivo de texto.
    /// </summary>
    public class Texto : IArchivos<string>
    {
        /// <summary>
        /// Genera un archivo en disco, en formato de cadena de caracteres.
        /// </summary>
        /// <param name="archivo">Ruta donde se guardará el archivo.</param>
        /// <param name="datos">Los datos que contendrá el archivo.</param>
        /// <returns>Verifica que se haya generado el archivo deseado.</returns>
        public bool Guardar(string archivo, string datos)
        {
            if (archivo != null && datos != null)
            {
                StreamWriter sw = new StreamWriter(archivo);
                sw.Write(datos);
                sw.Close();
            }

            return File.Exists(archivo);
        }

        /// <summary>
        /// Lee un archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta donde está ubicado el archivo.</param>
        /// <param name="datos">Datos que contiene el archivo.</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            if (File.Exists(archivo))
            {
                StreamReader sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                sr.Close();
                return true;
            }

            datos = string.Empty;
            return false;
        }
    }
}
