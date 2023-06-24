using System.Text.RegularExpressions;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Usuario;

namespace Ventas.Application.Helpers
{
    public static class UserValidationHelper
    {
        public static ServiceResult ValidateUserData(UsuarioDto model)
        {
            ServiceResult result = new ServiceResult();

            if(string.IsNullOrEmpty(model.Nombre))
            {
                result.Message = "El nombre del usuario es requerido";
                result.Success = false;
                return result;
            }

            if (model.Nombre.Length > 50)
            {
                result.Message = "El nombre del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValiEmail(model.Correo))
            {
                result.Message = "El correo electrónico es inválido.";
                result.Success = false;
                return result;
            }

            if (model.Correo.Length > 50)
            {
                result.Message = "El correo del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValidPhoneNumber(model.Telefono))
            {
                result.Message = "El número telefónico es inválido. " +
                    "Teléfono válido: (000) 000-0000";
                result.Success = false;
                return result;
            }

            if (model.Telefono.Length > 50)
            {
                result.Message = "El Telefóno del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValidUrl(model.UrlFoto))
            {
                result.Message = "La URL es inválida.";
                result.Success = false;
                return result;
            }

            if (model.Clave.Length > 100)
            {
                result.Message = "El Telefóno del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            return result;
        }

        // Coreo, Teléfono y URL
        private static bool IsValiEmail(string email)
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
    }
}
