using Ventas.Application.Dtos.Negocio;
using Ventas.Domain.Entities;


namespace Ventas.Application.Extensions
{
    public static class NegocioExtention
    {
        public static Negocio ConvertDtoAddToEntity(this NegocioAddDto negocioAddDto)
        {
            return new Negocio()
            {
                urlLogo = negocioAddDto.urlLogo,
                nombreLogo = negocioAddDto.nombreLogo,
                numeroDocumento = negocioAddDto.numeroDocumento,
                nombre = negocioAddDto.nombre,
                correo = negocioAddDto.correo,
                direccion = negocioAddDto.direccion,
                porcentajeImpuesto = negocioAddDto.porcentajeImpuesto,
                simboloMoneda = negocioAddDto.simboloMoneda,
                CreationUser = negocioAddDto.ChangeUser,
                CreationDate = negocioAddDto.ChangeDate
            };
        }

        public static Negocio ConvertDtoUpdateToEntity(this NegocioUpdateDto negocioUpdateDto)
        {

            return new Negocio()
            {
                urlLogo = negocioUpdateDto.urlLogo,
                nombreLogo = negocioUpdateDto.nombreLogo,
                numeroDocumento = negocioUpdateDto.numeroDocumento,
                nombre = negocioUpdateDto.nombre,
                correo = negocioUpdateDto.correo,
                direccion = negocioUpdateDto.direccion,
                porcentajeImpuesto = negocioUpdateDto.porcentajeImpuesto,
                simboloMoneda = negocioUpdateDto.simboloMoneda,
                UserMod = negocioUpdateDto.ChangeUser,
                ModifyDate = negocioUpdateDto.ChangeDate
            };

        }

    }
}
