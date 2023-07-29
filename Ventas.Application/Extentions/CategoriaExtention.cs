using Ventas.Application.Dtos.Categoria;
using Ventas.Domain.Entities;

namespace Ventas.Application.Extentions
{
    public static class CategoriaExtention
    {
        public static Categoria ConvertDtoAddToEntity (this CategoriaAddDto categoriaAddDto)
        {
            return new Categoria()
            {
                Descripcion = categoriaAddDto.Descripcion,
                EsActivo = categoriaAddDto.State,
                FechaRegistro = categoriaAddDto.RegisterDateAndTime,
                CreationUser = categoriaAddDto.ChangeUser,
                CreationDate = categoriaAddDto.ChangeDate
            };
        }

        public static Categoria ConvertDtoUpdateToEntity (this CategoriaUpdateDto categoriaUpdateDto) 
        {
            return new Categoria()
            {
                IdCategoria = categoriaUpdateDto.IdCategoria,
                Descripcion = categoriaUpdateDto.Descripcion,
                EsActivo = categoriaUpdateDto.State,
                FechaRegistro = categoriaUpdateDto.RegisterDateAndTime,
                UserMod = categoriaUpdateDto.ChangeUser,
                ModifyDate = categoriaUpdateDto.ChangeDate
            };
        }

        public static Categoria ConvertRemoveDtoToEntity (this CategoriaRemoveDto removeDto)
        {
            return new Categoria()
            {
                IdCategoria = removeDto.IdCategoria,
                Deleted = removeDto.Deleted,
                UserDeleted = removeDto.ChangeUser,
                DeletedDate = removeDto.ChangeDate
            };
        }
    }
}
