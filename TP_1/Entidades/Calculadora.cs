using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Genera una operación aritmética entre dos entidades Numero, validando el operador utilizado.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado;

            switch (ValidarOperador(operador[0]))
            {
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                default:
                    resultado = num1 + num2;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida el caracter ingresado para ser usado como operador. Por defecto sera el operador de suma (+).
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(char operador)
        {
            if (operador == '-' || operador == '*' || operador == '/')
            {
                return operador.ToString();
            }
            else
            {
                return "+";
            }
        }
    }
}
