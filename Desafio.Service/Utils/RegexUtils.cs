using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Service.Utils
{
    public class RegexUtils
    {
        /// <summary>
        /// Método <c>GetCPFValidationRegex</c> retorna string que valida 
        /// CPF, tanto 123.456.789-00, quanto 12345678900.
        /// </summary>
        /// <returns>
        /// string com regex de validação de CPF.
        /// </returns>
        public static string GetCPFValidationRegex()
        {
            return "(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)";
        }

        /// <summary>
        /// Método <c>GetCNPJValidationRegex</c> retorna string que valida 
        /// CNPJ, tanto 12.345.678/0001-00, quanto 12345678000100.
        /// </summary>
        /// <returns>
        /// string com regex de validação de CNPJ.
        /// </returns>
        public static string GetCNPJValidationRegex()
        {
            return "(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)";
        }

        /// <summary>
        /// Método <c>GetCEPValidationRegex</c> retorna string que valida 
        /// CEP com traço sendo opicional.
        /// </summary>
        /// <returns>
        /// string com regex de validação de CEP.
        /// </returns>
        public static string GetCEPValidationRegex()
        {
            return "(^[0-9]{5})-?([0-9]{3}$)";
        }

        /// <summary>
        /// Método <c>GetTelefoneValidationRegex</c> retorna string que valida 
        /// Telefone com DDD obrigatório, parenteses, espaço e traço sendo 
        /// opicionais.
        /// </summary>
        /// <returns>
        /// string com regex de validação de telefone.
        /// </returns>
        public static string GetTelefoneValidationRegex()
        {
            return "(^\\({1})?([0-9]{2})(\\){1})?(\\s)?([0-9]{5})(-{1})?([0-9]{4}$)";
        }

        /// <summary>
        /// Método <c>GetEmailValidationRegex</c> retorna string que valida 
        /// E-mail.
        /// </summary>
        /// <returns>
        /// string com regex de validação de e-mail.
        /// </returns>
        public static string GetEmailValidationRegex()
        {
            return "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
        }
    }
}
