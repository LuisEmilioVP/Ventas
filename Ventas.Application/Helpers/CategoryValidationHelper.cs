using Ventas.Application.Core;
using Ventas.Application.Dtos.Categoria;

namespace Ventas.Application.Helpers
{
    public static class CategoryValidationHelper
    {
        public static ServiceResult ValidateCategoryData (CategoriaDto model)
        {
            ServiceResult result = new ServiceResult ();

            if (string.IsNullOrEmpty(model.Descripcion))
            {
                result.Message = "La descripción es requrida";
                result.Success = false;
                return result;
            }

            if(model.Descripcion.Length > 50)
            {
                result.Message = "La descripción es demasiado larga";
                result.Success = false;
                return result;
            }

            return result;
        }
    }
}
