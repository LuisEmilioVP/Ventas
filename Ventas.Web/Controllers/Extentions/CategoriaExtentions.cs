using Ventas.Application.Dtos.Categoria;
using Ventas.Infrastructure.Models;
using Ventas.Web.Models.Categoria.Request;
using Ventas.Web.Models.Categoria.Response;

namespace Ventas.Web.Controllers.Extentions
{
    public static class CategoriaExtentions
    {
        public static CategoriaResponse ConverterModelToCategoriaResponse(this CategoriaModels categoria)
        {
            return new CategoriaResponse
            {
                IdCategoria = categoria.IdCategoria,
                Descripcion = categoria.Descripcion,
                EsActivo = categoria.EsActivo,
                FechaRegistro = categoria.FechaRegistro
            };
        }

        public static CategoriaAddDto ConvertAddRequestToAddDto(this CategoriaAddRequest categoriaAdd)
        {
            return new CategoriaAddDto()
            {
                Descripcion = categoriaAdd.Descripcion,
                ChangeUser = categoriaAdd.ChangeUser,
                ChangeDate = categoriaAdd.ChangeDate
            };
        }

        public static CategoriaUpdateRequest ConvertCategoriaToUpdateRequest(this CategoriaModels categoria)
        {
            return new CategoriaUpdateRequest()
            {
                IdCategoria = categoria.IdCategoria,
                Descripcion = categoria.Descripcion
            };
        }

        public static CategoriaUpdateDto ConvertUpdateRequestToUpdateDto(this CategoriaUpdateRequest categoriaUpdate)
        {
            return new CategoriaUpdateDto()
            {
                IdCategoria = categoriaUpdate.IdCategoria,
                Descripcion = categoriaUpdate.Descripcion,
                ChangeUser = categoriaUpdate.ChangeUser,
                ChangeDate = categoriaUpdate.ChangeDate
            };
        }

        public static CategoriaRemoveDto ConvertRemoveDtoToRemoveRequest(this CategoriaRemoveRequest categoriaRemove)
        {
            return new CategoriaRemoveDto()
            {
                IdCategoria = categoriaRemove.IdCategoria,
                Deleted = categoriaRemove.Deleted,
                ChangeUser = categoriaRemove.ChangeUser,
                ChangeDate = categoriaRemove.ChangeDate
            };
        }
    }
}
