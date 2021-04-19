using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        public Numero()
            : this(0)
        {
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Valida que la cadena ingresada sea un número, y lo retorna. Caso contrario, devolverá 0. Sólo utilizado para la propiedad SetNumero.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;

            if (double.TryParse(strNumero, out numero))
            {
                return numero;
            }

            return 0;
        }

        /// <summary>
        /// Valida que la cadena ingresada sea un número binario. En caso de encontrar un caracter distinto de 0 y 1, devolverá false.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private static bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Verifica que la cadena ingresada sea un número binario, y lo devuelve. En caso de fallar la validación devolverá "Valor inválido".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                int resultado = Convert.ToInt32(binario, 2);
                return resultado.ToString();
            }
            else
            {
                return "Valor inválido";
            }

        }

        /// <summary>
        /// Convierte un número decimal a binario. En caso de no poder hacer la conversión, devolverá "Valor inválido".
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            if (numero >= 1)
            {
                int numeroInt = Convert.ToInt32(numero);
                return Convert.ToString(numeroInt, 2);
            }
            else
            {
                return "Valor inválido";
            }
        }

        /// <summary>
        /// Convierte un número decimal a binario. En caso de no poder hacer la conversión, devolverá "Valor inválido".
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            double resultado;

            if (double.TryParse(numero, out resultado))
            {
                return DecimalBinario(resultado);
            }
            else
            {
                return "Valor inválido";
            }
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }

            return n1.numero / n2.numero;
        }
    }
}
