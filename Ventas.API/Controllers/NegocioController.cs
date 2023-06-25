using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Application.Dtos.Negocio;

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase

    { 
        private readonly INegocioService negocioService;

        public NegocioController(INegocioService negocioService)
        {
            this.negocioService = negocioService;
        }

        [HttpGet("ShowNegocio")]
        public IActionResult Get()
        {
            var result = this.negocioService.Get();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("ShowNegocioById")]
        public IActionResult Get(int id)
        {
            var result = this.negocioService.GetById(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveNegocio")]
        public IActionResult Post([FromBody] NegocioAddDto NegocioAdd)
        {
            var result = this.negocioService.Save(NegocioAdd);
            if(!result.Success)
                return BadRequest(result);

            return Ok();
        }

        [HttpPut("UpdateNegocio")]
        public IActionResult Put([FromBody] NegocioUpdateDto NegocioUpdate)
        {
            var result = this.negocioService.Update(NegocioUpdate);
            if (!result.Success)
                return BadRequest(result);

            return Ok();

        }

        [HttpDelete("RemoveNegocio")]
        public IActionResult Delete([FromBody] NegocioRemoveDto negocioRemove)
        {
            var result = this.negocioService.Remove(negocioRemove);
            if (!result.Success)
                return BadRequest(result);

            return Ok();
        }
    }
}