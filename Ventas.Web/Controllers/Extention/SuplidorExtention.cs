using Ventas.Application.Dto.Suplidor;
using Ventas.Domain.Core;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;
using Ventas.Web.Models.Suplidor.Request;
using Ventas.Web.Models.Suplidor.Response;

namespace Ventas.Web.Controllers.Extention
{
    public static class SuplidorExtention 
    {
        public static SuplidorResponse ConverterModelToSuplidorResponse(this SuplidorModels suplidorModels)
        {
            return new SuplidorResponse
            {

                IdSuplidor = suplidorModels.IdSuplidor,
                Nombre = suplidorModels.Nombre,
                Contacto = suplidorModels.Contacto,
                Direccion = suplidorModels.Direccion,
                Ciudad = suplidorModels.Ciudad,
                Region = suplidorModels.Region,
                Codigo_postal = suplidorModels.Codigo_postal,
                Pais = suplidorModels.Pais,
                Telefono = suplidorModels.Telefono,
                Fax = suplidorModels.Fax
            };
        }

        public static SuplidorAddDto ConvertAddRequestToAddDto(this SuplidorAddRequest suplidorAddRequest)
        {
            return new SuplidorAddDto()
            {
                Nombre = suplidorAddRequest.Nombre,
                Contacto = suplidorAddRequest.Contacto,
                Direccion = suplidorAddRequest.Direccion,
                Ciudad = suplidorAddRequest.Ciudad,
                Region = suplidorAddRequest.Region,
                Codigo_postal = suplidorAddRequest.Codigo_postal,
                Pais = suplidorAddRequest.Pais,
                Telefono = suplidorAddRequest.Telefono,
                Fax = suplidorAddRequest.Fax,
                ChangeUser = suplidorAddRequest.ChangeUser,
                ChangeDate = DateTime.Now
            };
        }



        public static SuplidorUpdateRequest ConvertUsuarioToUpdateRequest(this SuplidorModels suplidorModels)
        {
            return new SuplidorUpdateRequest()
            {

                IdSuplidor = suplidorModels.IdSuplidor,
                Nombre = suplidorModels.Nombre,
                Contacto = suplidorModels.Contacto,
                Direccion = suplidorModels.Direccion,
                Ciudad = suplidorModels.Ciudad,
                Region = suplidorModels.Region,
                Codigo_postal = suplidorModels.Codigo_postal,
                Pais = suplidorModels.Pais,
                Telefono = suplidorModels.Telefono,
                Fax = suplidorModels.Fax

            };
        }

        public static SuplidorUpdateDto ConvertUpdateRequestToUpdateDto(this SuplidorUpdateRequest suplidorUpdateRequest)
        {
            return new SuplidorUpdateDto()
            {

                IdSuplidor = suplidorUpdateRequest.IdSuplidor,
                Nombre = suplidorUpdateRequest.Nombre,
                Contacto = suplidorUpdateRequest.Contacto,
                Direccion = suplidorUpdateRequest.Direccion,
                Ciudad = suplidorUpdateRequest.Ciudad,
                Region = suplidorUpdateRequest.Region,
                Codigo_postal = suplidorUpdateRequest.Codigo_postal,
                Pais = suplidorUpdateRequest.Pais,
                Telefono = suplidorUpdateRequest.Telefono,
                Fax = suplidorUpdateRequest.Fax,
                ChangeUser = suplidorUpdateRequest.ChangeUser,
                ChangeDate = DateTime.Now
            };
        }


        public static SuplidorRemoveDto ConvertRemoveDtoToRemoveRequest(this SuplidorRemoveRequest suplidorRemoveRequest)
        {
            return new SuplidorRemoveDto()

            {
                IdSuplidor = suplidorRemoveRequest.IdSuplidor,
                Deleted = suplidorRemoveRequest.Deleted,
                ChangeUser = suplidorRemoveRequest.ChangeUser,
                ChangeDate = DateTime.Now
            };
        }

    }
}