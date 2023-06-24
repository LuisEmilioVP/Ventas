
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extentions
{
    public static class ProductoExtension
    {
        public static ProductoModels ConvertUserEntityToModel(this Producto pro)
        {
            ProductoModels Producto = new ProductoModels()
            {
                CodigoBarra = pro.CodigoBarra,
                Marca = pro.Marca,
                Descripcion = pro.Descripcion,
                Stock = pro.Stock,
                UrlImagen = pro.UrlImagen,
                NombreImagen = pro.NombreImagen,
                Precio = pro.Precio,
                EsActivo = pro.EsActivo,
                FechaRegistro = pro.FechaRegistro
            };

            return Producto;
        }
    }
}
