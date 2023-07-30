using System;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extentions
{
    public static class CategoriaExtention
    {
        public static CategoriaModels ConvertCategoryEntityToModel(this Categoria categoria)
        {
            CategoriaModels categoriaModels = new CategoriaModels()
            {
                IdCategoria = categoria.IdCategoria,
                Descripcion = categoria.Descripcion,
                EsActivo = categoria.EsActivo,
                FechaRegistro = categoria.FechaRegistro
            };

            return categoriaModels;
        }

        public static Categoria ConvertCategoriaCreateToEntity(this Categoria categoria)
        {
            return new Categoria()
            {
                Descripcion = categoria.Descripcion,
                EsActivo= categoria.EsActivo = true,
                FechaRegistro = categoria.FechaRegistro = DateTime.Now,
                CreationUser = categoria.CreationUser,
                CreationDate = categoria.CreationDate = DateTime.Now,
            };
        }

        public static Categoria ConvertCategoriaUpdateToEntity(this Categoria categoryToUpdate, 
                                                               Categoria categoria)
        {
            categoryToUpdate.IdCategoria = categoria.IdCategoria;
            categoryToUpdate.Descripcion = categoria.Descripcion;
            categoryToUpdate.EsActivo = categoria.EsActivo = true;
            categoryToUpdate.FechaRegistro = categoria.FechaRegistro = DateTime.Now;
            categoryToUpdate.UserMod = categoria.UserMod;
            categoryToUpdate.ModifyDate = categoria.ModifyDate = DateTime.Now;

            return categoryToUpdate;
        }

        public static Categoria ConvertCategoriaRemoveToEntity(this Categoria categoryToRemove,
                                                             Categoria categoria)
        {
            categoryToRemove.EsActivo = false;
            categoryToRemove.Deleted = true;
            categoryToRemove.UserDeleted = categoria.UserDeleted;
            categoryToRemove.DeletedDate = categoria.DeletedDate = DateTime.Now;

            return categoryToRemove;
        }
    }
}
