using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Application.Dtos.Usuario;

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet("ShowUsers")]
        public IActionResult Get()
        {
            var result = this.usuarioService.Get();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("ShowUserById")]
        public IActionResult Get(int id)
        {
            var result = this.usuarioService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveUser")]
        public IActionResult Post([FromBody] UsuarioAddDto usuarioAdd)
        {
            var result = this.usuarioService.Save(usuarioAdd);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public IActionResult Put([FromBody] UsuarioUpdateDto usuarioUpdate)
        {
            var result = this.usuarioService.Update(usuarioUpdate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveUser")]
        public IActionResult Delete([FromBody] UsuarioRevoveDto usuarioRevove)
        {
            var result = this.usuarioService.Remove(usuarioRevove);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
