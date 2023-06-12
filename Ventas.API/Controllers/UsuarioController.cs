using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("ShowUser_Id")]
        public IActionResult Get(int id)
        {
            var user = this.usuarioRepository.GetUser(id);
            return Ok(user);
        }

        [HttpPost("SaveUser")]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("UpdateUser")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("RemoveUser")]
        public void Delete(int id)
        {
        }
    }
}
