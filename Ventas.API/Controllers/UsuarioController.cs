using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Dtos.Usuario;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        [HttpGet("ShowUsers")]
        public IActionResult Get()
        {
            var users = this.usuarioRepository.GetAllUser();
            return Ok(users);
        }

        [HttpGet("ShowUserById")]
        public IActionResult Get(int id)
        {
            var user = this.usuarioRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("SaveUser")]
        public IActionResult Post([FromBody] UsuarioAddDto usuarioAdd)
        {
            this.usuarioRepository.Add(new Usuario() 
            {
                Nombre = usuarioAdd.Nombre,
                Correo = usuarioAdd.Correo,
                Telefono = usuarioAdd.Telefono,
                UrlFoto = usuarioAdd.UrlFoto,
                NombreFoto = usuarioAdd.NombreFoto,
                Clave = usuarioAdd.Clave,
                EsActivo = usuarioAdd.State,
                FechaRegistro = usuarioAdd.RegisterDateAndTime,
                CreationUser = usuarioAdd.ChangeUser,
                CreationDate = usuarioAdd.ChangeDate,
            });
            return Ok();
        }

        [HttpPut("UpdateUser")]
        public IActionResult Put([FromBody] UsuarioUpdateDto usuarioUpdate)
        {
            Usuario usuarioToUpdate = new Usuario()
            {
                IdUsuario = usuarioUpdate.IdUsuario,
                Nombre = usuarioUpdate.Nombre,
                Telefono = usuarioUpdate.Telefono,
                Correo = usuarioUpdate.Correo,
                UrlFoto = usuarioUpdate.UrlFoto,
                NombreFoto = usuarioUpdate.NombreFoto,
                Clave = usuarioUpdate.Clave,
                EsActivo = usuarioUpdate.State,
                FechaRegistro = usuarioUpdate.RegisterDateAndTime,
                UserMod = usuarioUpdate.ChangeUser,
                ModifyDate = usuarioUpdate.ChangeDate,
            };

            this.usuarioRepository.Update(usuarioToUpdate);
            return Ok();
        }

        [HttpDelete("RemoveUser")]
        public IActionResult Delete([FromBody] UsuarioRevoveDto usuarioRevove)
        {
            Usuario usuarioToDelete = new Usuario()
            {
                IdUsuario = usuarioRevove.IdUsuario,
                UserDeleted = usuarioRevove.ChangeUser,
                DeletedDate = usuarioRevove.ChangeDate,
                Deleted = usuarioRevove.Deleted,
            };

            this.usuarioRepository.Remove(usuarioToDelete);
            return Ok();
        }
    }
}
