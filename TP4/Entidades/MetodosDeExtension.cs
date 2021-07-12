using System;

namespace Entidades
{
    public static class MetodosDeExtension
    {
        /// <summary>
        /// Transforma un string de origen para devolver su equivalente EMarca, o en su defecto EMarca.Generico
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
		public static EMarca ToEMarca(this string cadena)
		{
			foreach (EMarca marca in Enum.GetValues(typeof(EMarca)))
            {
				if (cadena.ToLower() == marca.ToString().ToLower())
                {
                    return marca;
                }
            }

            return EMarca.Generico;
		}
	}
}
