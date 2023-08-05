using Ventas.Application.Dtos.Usuario;
using Ventas.Infrastructure.Models;
using Ventas.Web.Models.Usuario;
using Ventas.Web.Models.Usuario.Request;

namespace Ventas.Web.Controllers.Extentions
{
    public static class UsuarioExtentions
    {
        //* Para Api y sin Api
        public static BaseUsuarioModel ConverterModelTousuarioResponse(this UsuarioModels usuario)
        {
            return new BaseUsuarioModel
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                Clave = usuario.Clave,
                EsActivo = usuario.EsActivo,
                FechaRegistro = usuario.FechaRegistro
            };
        }
        //* Sin Api
        public static UsuarioUpdateRequest ConvertUsuarioToUpdateRequest (this UsuarioModels usuario)
        {
            return new UsuarioUpdateRequest()
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                Clave = usuario.Clave
            };
        }
        //* Con Api Y Http
        public static UsuarioUpdateRequest ConvertUsuarioToUpdateRequest(this BaseUsuarioModel usuario)
        {
            return new UsuarioUpdateRequest()
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                Clave = usuario.Clave,
            };
        }
        //* Para Api y sin Api
        public static UsuarioAddDto ConvertAddRequestToAddDto(this UsuarioAddRequest usuarioAdd)
        {
            return new UsuarioAddDto()
            {
                Nombre = usuarioAdd.Nombre,
                Correo = usuarioAdd.Correo,
                Telefono = usuarioAdd.Telefono,
                Clave = usuarioAdd.Clave,
                ChangeUser = usuarioAdd.ChangeUser,
                ChangeDate = usuarioAdd.ChangeDate
            };
        }
        //* Para Api y sin Api
        public static UsuarioUpdateDto ConvertUpdateRequestToUpdateDto (this UsuarioUpdateRequest usuarioUpdate)
        {
            return new UsuarioUpdateDto()
            {
                IdUsuario = usuarioUpdate.IdUsuario,
                Nombre = usuarioUpdate.Nombre,
                Correo = usuarioUpdate.Correo,
                Telefono = usuarioUpdate.Telefono,
                Clave = usuarioUpdate.Clave,
                ChangeUser = usuarioUpdate.ChangeUser,
                ChangeDate = usuarioUpdate.ChangeDate
            };
        }
        //* Para Api y sin Api
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
