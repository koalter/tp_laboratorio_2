namespace Archivos
{
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
