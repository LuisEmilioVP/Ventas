using System.Text.RegularExpressions;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Negocio;

namespace Ventas.Application.Validations
{
    public static class NegocioValidator
    {
        public static ServiceResult ValidateIdNegocio(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id <= 0)
            {
                result.Message = $"Id de Negocio inválido {id}";
                result.Success = false;
                return result;
            }

            if (id == null)
            {
                result.Message = $"Un Negocio no puede ser nulo";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateNegocioAdd(NegocioAddDto addDto)
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

            if (string.IsNullOrEmpty(addDto.nombre))
            {
                result.Message = "El nombre del usuario es requerido";
                result.Success = false;
                return result;
            }

            if (addDto.nombre.Length > 50)
            {
                result.Message = "El nombre del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValiEmail(addDto.correo))
            {
                result.Message = "El correo electrónico es inválido.";
                result.Success = false;
                return result;
            }

            if (addDto.correo.Length > 50)
            {
                result.Message = "El correo del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValidPhoneNumber(addDto.telefono))
            {
                result.Message = "El número telefónico es inválido. " +
                    "Teléfono válido: (000) 000-0000";
                result.Success = false;
                return result;
            }

            if (addDto.telefono.Length > 50)
            {
                result.Message = "El Telefóno del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateNegocioUpdate(NegocioUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            if (updateDto.idNegocio != updateDto.idNegocio)
            {
                result.Message = "ID no detectado. Indique el usuario a actualizar";
                result.Success = false;
                return result;
            }

            if (updateDto.idNegocio <= 0)
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

            if (string.IsNullOrEmpty(updateDto.nombre))
            {
                result.Message = "El nombre del usuario es requerido";
                result.Success = false;
                return result;
            }

            if (updateDto.nombre.Length > 50)
            {
                result.Message = "El nombre del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValiEmail(updateDto.correo))
            {
                result.Message = "El correo electrónico es inválido.";
                result.Success = false;
                return result;
            }

            if (updateDto.correo.Length > 50)
            {
                result.Message = "El correo del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            if (!IsValidPhoneNumber(updateDto.telefono))
            {
                result.Message = "El número telefónico es inválido. " +
                    "Teléfono válido: (000) 000-0000";
                result.Success = false;
                return result;
            }

            if (updateDto.telefono.Length > 50)
            {
                result.Message = "El Telefóno del usuario es demasiado largo";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateNegocioRemove(NegocioRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            if (removeDto.idNegocio != removeDto.idNegocio)
            {
                result.Message = "ID no detectado. Indique el usuario a eliminar";
                result.Success = false;
                return result;
            }

            if (removeDto.idNegocio <= 0)
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
    }
}
