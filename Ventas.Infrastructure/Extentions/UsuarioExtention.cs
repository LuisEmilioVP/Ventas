using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extentions
{
    public static class UsuarioExtention
    {
        public static UsuarioModels ConvertUserEntityToModel(this Usuario usuario)
        {
            UsuarioModels userModel = new UsuarioModels()
            {
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                UrlFoto = usuario.UrlFoto,
                NombreFoto = usuario.NombreFoto,
                EsActivo = usuario.EsActivo,
                FechaRegistro = usuario.FechaRegistro
            };

            return userModel;
        }
    }
}
