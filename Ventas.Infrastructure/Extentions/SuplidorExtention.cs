
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extentions
{
    public static class SuplidorExtention
    {
        public static SuplidorModels ConvertSuplidorEntityToModel(this Suplidor suplidor)
        {
             SuplidorModels suplidorModels = new SuplidorModels()
             {
              Nombre = suplidor.Nombre,
              Contacto = suplidor.Contacto,
              Direccion = suplidor.Direccion,
              Ciudad = suplidor.Ciudad,
              Region = suplidor.Region,
              Codigo_postal = suplidor.Codigo_postal,
              Pais = suplidor.Pais, 
              Telefono = suplidor.Telefono,
              Fax = suplidor.Fax

        };
            return suplidorModels;
        }
    }
}
