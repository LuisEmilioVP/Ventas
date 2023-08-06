using Ventas.Application.Dtos.Negocio;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;
using Ventas.Web.Models.Negocio;
using Ventas.Web.Models.Negocio.Request;

namespace Ventas.Web.Controllers.Extensions
{
    public static class NegocioExtensions
    {
        //* Para Api y sin Api
        public static BaseNegocioModel ConverterModelToNegocioResponse(this NegocioModel negocio)
        {
            return new BaseNegocioModel
            {
                idNegocio = negocio.idNegocio,
                urlLogo = negocio.urlLogo,
                nombreLogo = negocio.nombreLogo,
                numeroDocumento = negocio.numeroDocumento,
                nombre = negocio.nombre,
                correo = negocio.correo,
                direccion = negocio.direccion,
                telefono = negocio.telefono,
                porcentajeImpuesto = negocio.porcentajeImpuesto,
                simboloMoneda = negocio.simboloMoneda
            };
        }

        //*Sin Api
        public static NegocioUpdateRequest ConvertNegocioUpdateRequest(this NegocioModel negocio)
        {
            return new NegocioUpdateRequest()
            {
                idNegocio = negocio.idNegocio,
                urlLogo = negocio.urlLogo,
                nombreLogo = negocio.nombreLogo,
                numeroDocumento = negocio.numeroDocumento,
                nombre = negocio.nombre,
                correo = negocio.correo,
                direccion = negocio.direccion,
                telefono = negocio.telefono,
                porcentajeImpuesto = negocio.porcentajeImpuesto,
                simboloMoneda = negocio.simboloMoneda
            };
        }

        //*Con Api y Http

        public static NegocioUpdateRequest ConvertNegocioToUpdateRequest(this BaseNegocioModel negocio)
        {
            return new NegocioUpdateRequest()
            {
                idNegocio = negocio.idNegocio,
                urlLogo = negocio.urlLogo,
                nombreLogo = negocio.nombreLogo,
                numeroDocumento = negocio.numeroDocumento,
                nombre = negocio.nombre,
                correo = negocio.correo,
                direccion = negocio.direccion,
                telefono = negocio.telefono,
                porcentajeImpuesto = negocio.porcentajeImpuesto,
                simboloMoneda = negocio.simboloMoneda
            };
        }

        //* Para Api y sin Api
        public static NegocioAddDto ConvertAddRequestToAddDto(this NegocioAddRequest negocioAdd)
        {
            return new NegocioAddDto()
            {
                urlLogo = negocioAdd.urlLogo,
                nombreLogo = negocioAdd.nombreLogo,
                numeroDocumento = negocioAdd.numeroDocumento,
                nombre = negocioAdd.nombre,
                correo = negocioAdd.correo,
                direccion = negocioAdd.direccion,
                telefono = negocioAdd.telefono,
                porcentajeImpuesto = negocioAdd.porcentajeImpuesto,
                simboloMoneda = negocioAdd.simboloMoneda,
                ChangeUser = negocioAdd.ChangeUser,
                ChangeDate = negocioAdd.ChangeDate
            };
        }

        //*Para Api y sin api

        public static NegocioUpdateDto ConvertUpdateRequestToUpdateDto(this NegocioUpdateRequest negocioUpdate)
        {
            return new NegocioUpdateDto()
            {
                urlLogo = negocioUpdate.urlLogo,
                nombreLogo = negocioUpdate.nombreLogo,
                numeroDocumento = negocioUpdate.numeroDocumento,
                nombre = negocioUpdate.nombre,
                correo = negocioUpdate.correo,
                direccion = negocioUpdate.direccion,
                telefono = negocioUpdate.telefono,
                porcentajeImpuesto = negocioUpdate.porcentajeImpuesto,
                simboloMoneda = negocioUpdate.simboloMoneda,
                ChangeUser = negocioUpdate.ChangeUser,
                ChangeDate = negocioUpdate.ChangeDate
            };
        }

        public static NegocioRemoveDto ConvertRemoveDtoToRemoveRequest(this NegocioRemoveRequest negocioRemove)
        {
            return new NegocioRemoveDto()
            {
                idNegocio = negocioRemove.idNegocio,
                Deleted = negocioRemove.Deleted,
                ChangeUser = negocioRemove.ChangeUser,
                ChangeDate = negocioRemove.ChangeDate
            };
        }
    }
}
