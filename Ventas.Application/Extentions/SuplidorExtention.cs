
using Ventas.Application.Dto.Suplidor;
using Ventas.Domain.Entities;

namespace Ventas.Application.Extentions
{
    public static class SuplidorExtention
    {
        public static Suplidor ConvertDtoAddToEntity(this SuplidorAddDto suplidorAddDto)
        {
            return new Suplidor()
            {
                 Nombre = suplidorAddDto.Nombre,
                 Contacto = suplidorAddDto.Contacto,
                 Direccion = suplidorAddDto.Direccion,
                 Ciudad = suplidorAddDto.Ciudad,
                 Region = suplidorAddDto.Region,
                 Codigo_postal = suplidorAddDto.Codigo_postal,
                 Pais = suplidorAddDto.Pais,
                 Telefono = suplidorAddDto.Telefono,
                 Fax = suplidorAddDto.Fax,
            };
        }

        public static Suplidor ConvertDtoUpdateToEntity(this SuplidorUpdateDto suplidorUpdate)
        {
            return new Suplidor()
            {
                IdSuplidor = suplidorUpdate.IdSuplidor,
                Nombre = suplidorUpdate.Nombre,
                Contacto = suplidorUpdate.Contacto,
                Direccion = suplidorUpdate.Direccion,
                Ciudad = suplidorUpdate.Ciudad,
                Region = suplidorUpdate.Region,
                Codigo_postal = suplidorUpdate.Codigo_postal,
                Pais = suplidorUpdate.Pais,
                Telefono = suplidorUpdate.Telefono,
                Fax = suplidorUpdate.Fax,


            };
        }



    }
}
