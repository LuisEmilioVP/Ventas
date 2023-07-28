using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Application.Dtos.Venta;

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService ventaService;

        public VentaController(IVentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        [HttpGet("ShowUsers")]
        public IActionResult Get()
        {
            var result = this.ventaService.Get();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("ShowUserById")]
        public IActionResult Get(int id)
        {
            var result = this.ventaService.GetById(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveUser")]
        public IActionResult Post([FromBody] VentaAddDto VentaAdd)
        {
            var result = this.ventaService.Save(VentaAdd);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public IActionResult Put([FromBody] VentaUpdateDto VentaUpdate)
        {
            var result = this.ventaService.Update(VentaUpdate);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveUser")]
        public IActionResult Delete([FromBody] VentaRemoveDto VentaRemove)
        {
            var result = this.ventaService.Remove(VentaRemove);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
