using Ventas.Application.Core;
using Ventas.Application.Dtos.Categoria;

namespace Ventas.Application.Validations
{
    public static class CategoriaValidator
    {
        public static ServiceResult ValidateIdCategoria(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id <= 0)
            {
                result.Message = $"Id de categoría inválido {id}";
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

        public static ServiceResult ValidateCategoriaAdd(CategoriaAddDto addDto)
        {
            ServiceResult result = new ServiceResult();

            if (addDto.ChangeUser != addDto.ChangeUser)
            {
                result.Message = "ID no detectado. Indique quién creará la categoría";
                result.Success = false;
                return result;
            }

            if (addDto.ChangeUser <= 0)
            {
                result.Message = "Id de usuario inválido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(addDto.Descripcion))
            {
                result.Message = "La descripción es requrida";
                result.Success = false;
                return result;
            }

            if (addDto.Descripcion.Length > 50)
            {
                result.Message = "La descripción es demasiado larga";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateCategoriaUpdate(CategoriaUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            if (updateDto.IdCategoria != updateDto.IdCategoria)
            {
                result.Message = "ID no detectado. Indique la categoría a actualizar";
                result.Success = false;
                return result;
            }

            if (updateDto.IdCategoria <= 0)
            {
                result.Message = "Id de categoría inválido";
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

            if (string.IsNullOrEmpty(updateDto.Descripcion))
            {
                result.Message = "La descripción es requrida";
                result.Success = false;
                return result;
            }

            if (updateDto.Descripcion.Length > 50)
            {
                result.Message = "La descripción es demasiado larga";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateCategoriaRemove(CategoriaRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            if (removeDto.IdCategoria != removeDto.IdCategoria)
            {
                result.Message = "ID no detectado. Indique la categoría a eliminar";
                result.Success = false;
                return result;
            }

            if (removeDto.IdCategoria <= 0)
            {
                result.Message = "Id de categoría inválido";
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
    }
}
