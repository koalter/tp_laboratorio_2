namespace Archivos
{
    /// <summary>
    /// Interface que declara los métodos Guardar y Leer, 
    /// apuntado a archivos que puedan ser consumidos por la aplicación. 
    /// Asimismo, hace uso de tipos genéricos.
    /// Se implementa en las clases Xml y Texto.
    /// </summary>
    /// <typeparam name="T">Tipo de dato que va a manejar la interface y las clases que la implementen</typeparam>
    public interface IArchivos<T>
    {
        /// <summary>
        /// Genera un archivo en disco.
        /// </summary>
        /// <param name="archivo">Ruta donde se guardará el archivo.</param>
        /// <param name="datos">Los datos que contendrá el archivo.</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Lee un archivo específico.
        /// </summary>
        /// <param name="archivo">Ruta donde está ubicado el archivo.</param>
        /// <param name="datos">Datos que contiene el archivo.</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
    }
}
