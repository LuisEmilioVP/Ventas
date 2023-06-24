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
                Descripcion = categoria.Descripcion,
                EsActivo = categoria.EsActivo,
                FechaRegistro = categoria.FechaRegistro
            };

            return categoriaModels;
        }
    }
}
