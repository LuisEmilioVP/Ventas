using System.Text.RegularExpressions;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Negocio;

namespace Ventas.Application.Helpers
{
    public static class NegocioValidationHelper
    {
        public static ServiceResult ValidateNegocioData(NegocioDto model)
        {
            ServiceResult result = new ServiceResult();

            if (model.urlLogo.Length > 500)
            {
                result.Message = "La URl es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValidUrl(model.urlLogo))
            {
                result.Message = "La URL es invalida";
                result.Success = false;
                return result;
            }

            if (model.nombreLogo.Length > 100)
            {
                result.Message = "El nombre del logo es demasiado largo";
                result.Success = false;
                return result;
            }

            if (model.numeroDocumento.Length > 100)
            {
                result.Message = "El numero del documento es demasiado largo";
                result.Success = false;
                return result;
            }

            if (model.nombre.Length > 50)
            {
                result.Message = "El nombre del negocio es demasiado largo";
                result.Success = false;
                return result;
            }


            if (model.correo.Length > 50)
            {
                result.Message = "El nombre del negocio es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValidEmail(model.correo))
            {
                result.Message = "El correo electrónico es inválido.";
                result.Success = false;
                return result;
            }

            if (model.correo.Length > 50)
            {
                result.Message = "El nombre del negocio es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValidImpuesto((decimal)model.porcentajeImpuesto))
            {
                result.Message = "El porcentaje es invalido";
                result.Success = false;
                return result;
            }

            if (!IsValidMoneda(model.simboloMoneda))
            {
                result.Message = "El simbolo de la moneda es invalido";
                result.Success = false;
                return result;
            }

        }

        // Coreo, Teléfono y URL
        private static bool IsValidEmail(string email)
        {
            // Expresión regular para validar el formato de un correo electrónico
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Validar el formato del correo electrónico usando la expresión regular
            return Regex.IsMatch(email, emailPattern);
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Expresión regular para validar el formato de un número telefónico
            string phonePattern = @"^\(\d{3}\)\s\d{3}-\d{4}$";

            // Validar el formato del número telefónico usando la expresión regular
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        private static bool IsValidUrl(string url)
        {
            // Expresión regular para validar el formato de una URL
            string urlPattern = @"^(http|https)://([\w-]+(\.[\w-]+)+)([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?$";

            // Validar el formato de la URL usando la expresión regular
            return Regex.IsMatch(url, urlPattern);
        }

        private static bool IsValidImpuesto(decimal Impuesto)
        {
            string pattern = @"^(([1-9]\d{0,1}(\.\d{2})?)|100(\.00)?)$";
            string numberString = Impuesto.ToString();

            return Regex.IsMatch(numberString, pattern);
        }

        public static bool IsValidMoneda(string input)
        {
            string pattern = @"^(?:\$|€|£|¥|₣|₤|₹|₽|₱)$";
            return Regex.IsMatch(input, pattern);
        }

    }
}
    

