using Ventas.Application.Dtos.Usuario;
using Ventas.Domain.Entities;

namespace Ventas.Application.Extentions
{
    public static class UsuarioExtention
    {
        public static Usuario ConvertDtoAddToEntity(this UsuarioAddDto usuarioAddDto)
        {
            return new Usuario()
            {
                Nombre = usuarioAddDto.Nombre,
                Correo = usuarioAddDto.Correo,
                Telefono = usuarioAddDto.Telefono,
                UrlFoto = usuarioAddDto.UrlFoto,
                NombreFoto = usuarioAddDto.NombreFoto,
                Clave = usuarioAddDto.Clave,
                EsActivo = usuarioAddDto.State,
                FechaRegistro = usuarioAddDto.RegisterDateAndTime,
                CreationUser = usuarioAddDto.ChangeUser,
                CreationDate = usuarioAddDto.ChangeDate
            };
        }

        public static Usuario ConvertDtoUpdateToEntity (this UsuarioUpdateDto usuarioUpdateDto)
        {
            return new Usuario()
            {
                IdUsuario = usuarioUpdateDto.IdUsuario,
                Nombre = usuarioUpdateDto.Nombre,
                Correo = usuarioUpdateDto.Correo,
                Telefono = usuarioUpdateDto.Telefono,
                UrlFoto = usuarioUpdateDto.UrlFoto,
                NombreFoto = usuarioUpdateDto.NombreFoto,
                Clave = usuarioUpdateDto.Clave,
                EsActivo = usuarioUpdateDto.State,
                FechaRegistro = usuarioUpdateDto.RegisterDateAndTime,
                UserMod = usuarioUpdateDto.ChangeUser,
                ModifyDate = usuarioUpdateDto.ChangeDate
            };
        }

        public static Usuario ConvertRemoveDtoToEntity (this UsuarioRevoveDto usuarioRevoveDto)
        {
            return new Usuario()
            {
                IdUsuario = usuarioRevoveDto.IdUsuario,
                Deleted = usuarioRevoveDto.Deleted,
                UserDeleted = usuarioRevoveDto.ChangeUser,
                DeletedDate = usuarioRevoveDto.ChangeDate
            };
        }
    }
}
