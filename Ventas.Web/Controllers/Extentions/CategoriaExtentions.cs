using Ventas.Application.Dtos.Categoria;
using Ventas.Infrastructure.Models;
using Ventas.Web.Models.Categoria;
using Ventas.Web.Models.Categoria.Request;

namespace Ventas.Web.Controllers.Extentions
{
    public static class CategoriaExtentions
    {
        //* Para Api y sin Api
        public static BaseCategoriaModel ConverterModelToCategoriaResponse(this CategoriaModels categoria)
        {
            return new BaseCategoriaModel
            {
                IdCategoria = categoria.IdCategoria,
                Descripcion = categoria.Descripcion,
                EsActivo = categoria.EsActivo,
                FechaRegistro = categoria.FechaRegistro
            };
        }
        //* Sin Api
        public static CategoriaUpdateRequest ConvertCategoriaToUpdateRequest(this CategoriaModels categoria)
        {
            return new CategoriaUpdateRequest()
            {
                IdCategoria = categoria.IdCategoria,
                Descripcion = categoria.Descripcion
            };
        }
        //* Con Api
        public static CategoriaUpdateRequest ConvertCategoriaToUpdateRequest(this BaseCategoriaModel baseCategoria)
        {
            return new CategoriaUpdateRequest()
            {
                IdCategoria = baseCategoria.IdCategoria,
                Descripcion = baseCategoria.Descripcion
            };
        }
        //* Para Api y sin Api
        public static CategoriaAddDto ConvertAddRequestToAddDto(this CategoriaAddRequest categoriaAdd)
        {
            return new CategoriaAddDto()
            {
                Descripcion = categoriaAdd.Descripcion,
                ChangeUser = categoriaAdd.ChangeUser,
                ChangeDate = categoriaAdd.ChangeDate
            };
        }
        //* Para Api y sin Api
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
        //* Para Api y sin Api
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
