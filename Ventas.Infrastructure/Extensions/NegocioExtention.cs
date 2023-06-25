using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extensions
{
    public static class NegocioExtention
    {
        public static NegocioModel ConvertUserEntityToModel(this Negocio negocio)
        {
            NegocioModel negocioModel = new NegocioModel()
            {
                urlLogo = negocio.urlLogo,
                nombreLogo = negocio.nombreLogo,
                numeroDocumento = negocio.numeroDocumento,
                nombre = negocio.nombre,
                correo = negocio.correo,
                direccion = negocio.direccion,
                porcentajeImpuesto = negocio.porcentajeImpuesto,
                simboloMoneda = negocio.simboloMoneda
            };
            return negocioModel;
        }

    }
}
