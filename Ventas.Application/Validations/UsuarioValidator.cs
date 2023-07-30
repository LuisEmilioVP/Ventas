using System.Text.RegularExpressions;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Usuario;

namespace Ventas.Application.Validations
{
    public static class UsuarioValidator
    {
        public static ServiceResult ValidateIdUsuario(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id <= 0) 
            {
                result.Message = $"Id de usuario inválido {id}";
                result.Success = false;
                return result;
            }

            if (id == null)
            {
                result.Message = $"Un usuario no puede ser nulo";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateUsuarioAdd(UsuarioAddDto addDto)
        {
            ServiceResult result = new ServiceResult();

            if (addDto.ChangeUser == null)
            {
                result.Message = "ID no detectado. Indique quién creará un usuario";
                result.Success = false;
                return result;
            }

            if (addDto.ChangeUser <= 0)
            {
                result.Message = "Id de usuario inválido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(addDto.Nombre))
            {
                result.Message = "El nombre del usuario es requerido";
                result.Success = false;
                return result;
            }

            if (addDto.Nombre.Length > 50)
            {
                result.Message = "El nombre del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValiEmail(addDto.Correo))
            {
                result.Message = "El correo electrónico es inválido.";
                result.Success = false;
                return result;
            }

            if (addDto.Correo.Length > 50)
            {
                result.Message = "El correo del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValidPhoneNumber(addDto.Telefono))
            {
                result.Message = "El número telefónico es inválido. " +
                    "Teléfono válido: (000) 000-0000";
                result.Success = false;
                return result;
            }

            if (addDto.Telefono.Length > 50)
            {
                result.Message = "El Telefóno del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValidUrl(addDto.UrlFoto))
            {
                result.Message = "La URL es inválida.";
                result.Success = false;
                return result;
            }

            if (addDto.UrlFoto.Length > 500)
            {
                result.Message = "La URL es demasiado larga";
                result.Success = false;
                return result;
            }

            if (addDto.NombreFoto.Length > 100)
            {
                result.Message = "El nombre de la foto es demasiado largo";
                result.Success = false;
                return result;
            }

            if (addDto.Clave.Length > 100)
            {
                result.Message = "El Telefóno del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateUsuarioUpdate(UsuarioUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            if (updateDto.IdUsuario != updateDto.IdUsuario)
            {
                result.Message = "ID no detectado. Indique el usuario a actualizar";
                result.Success = false;
                return result;
            }

            if (updateDto.IdUsuario <= 0)
            {
                result.Message = "Id de usuario inválido";
                result.Success = false;
                return result;
            }

            if (updateDto.ChangeUser == null)
            {
                result.Message = "ID no detectado. Indique quien actualizara";
                result.Success = false;
                return result;
            }

            if (updateDto.ChangeUser <= 0)
            {
                result.Message = "Id de usuario inválido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(updateDto.Nombre))
            {
                result.Message = "El nombre del usuario es requerido";
                result.Success = false;
                return result;
            }

            if (updateDto.Nombre.Length > 50)
            {
                result.Message = "El nombre del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValiEmail(updateDto.Correo))
            {
                result.Message = "El correo electrónico es inválido.";
                result.Success = false;
                return result;
            }

            if (updateDto.Correo.Length > 50)
            {
                result.Message = "El correo del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValidPhoneNumber(updateDto.Telefono))
            {
                result.Message = "El número telefónico es inválido. " +
                    "Teléfono válido: (000) 000-0000";
                result.Success = false;
                return result;
            }

            if (updateDto.Telefono.Length > 50)
            {
                result.Message = "El Telefóno del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValidUrl(updateDto.UrlFoto))
            {
                result.Message = "La URL es inválida.";
                result.Success = false;
                return result;
            }

            if (updateDto.UrlFoto.Length > 500)
            {
                result.Message = "La URL es demasiado larga";
                result.Success = false;
                return result;
            }

            if (updateDto.NombreFoto.Length > 100)
            {
                result.Message = "El nombre de la foto es demasiado largo";
                result.Success = false;
                return result;
            }

            if (updateDto.Clave.Length > 100)
            {
                result.Message = "El Telefóno del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateUsuarioRemove(UsuarioRevoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            if (removeDto.IdUsuario != removeDto.IdUsuario)
            {
                result.Message = "ID no detectado. Indique el usuario a eliminar";
                result.Success = false;
                return result;
            }

            if (removeDto.IdUsuario <= 0)
            {
                result.Message = "Id de usuario inválido";
                result.Success = false;
                return result;
            }

            if (removeDto.ChangeUser == null)
            {
                result.Message = "ID no detectado. Indique quien eliminara";
                result.Success = false;
                return result;
            }

            if (removeDto.ChangeUser <= 0)
            {
                result.Message = "Id de usuario inválido";
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
