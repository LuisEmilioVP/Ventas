using Ventas.Application.Dtos.Usuario;
using Ventas.Infrastructure.Models;
using Ventas.Web.Models.Usuario.Request;
using Ventas.Web.Models.Usuario.Response;

namespace Ventas.Web.Controllers.Extentions
{
    public static class UsuarioExtentions
    {
        public static UsuarioResponse ConverterModelTousuarioResponse(this UsuarioModels usuario)
        {
            return new UsuarioResponse
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                Clave = usuario.Clave,
                UrlFoto = usuario.UrlFoto,
                NombreFoto = usuario.NombreFoto,
                EsActivo = usuario.EsActivo,
                FechaRegistro = usuario.FechaRegistro
            };
        }

        public static UsuarioAddDto ConvertAddRequestToAddDto (this UsuarioAddRequest usuarioAdd)
        {
            return new UsuarioAddDto()
            {
                Nombre = usuarioAdd.Nombre,
                Correo = usuarioAdd.Correo,
                Telefono = usuarioAdd.Telefono,
                Clave = usuarioAdd.Clave,
                UrlFoto = usuarioAdd.UrlFoto,
                NombreFoto = usuarioAdd.NombreFoto,
                ChangeUser = usuarioAdd.ChangeUser,
                ChangeDate = usuarioAdd.ChangeDate
            };
        }

        public static UsuarioUpdateRequest ConvertUsuarioToUpdateRequest (this UsuarioModels usuario)
        {
            return new UsuarioUpdateRequest()
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                Clave = usuario.Clave,
                UrlFoto= usuario.UrlFoto,
                NombreFoto = usuario.NombreFoto
            };
        }

        public static UsuarioUpdateDto ConvertUpdateRequestToUpdateDto (this UsuarioUpdateRequest usuarioUpdate)
        {
            return new UsuarioUpdateDto()
            {
                IdUsuario = usuarioUpdate.IdUsuario,
                Nombre = usuarioUpdate.Nombre,
                Correo = usuarioUpdate.Correo,
                Telefono = usuarioUpdate.Telefono,
                Clave = usuarioUpdate.Clave,
                UrlFoto = usuarioUpdate.UrlFoto,
                NombreFoto = usuarioUpdate.NombreFoto,
                ChangeUser = usuarioUpdate.ChangeUser,
                ChangeDate = usuarioUpdate.ChangeDate
            };
        }

        public static UsuarioRevoveDto ConvertRemoveDtoToRemoveRequest (this UsuarioRemoveRequest usuarioRemove)
        {
            return new UsuarioRevoveDto()
            {
                IdUsuario = usuarioRemove.IdUsuario,
                Deleted = usuarioRemove.Deleted,
                ChangeUser = usuarioRemove.ChangeUser,
                ChangeDate = usuarioRemove.ChangeDate
            };
        }
    }
}
