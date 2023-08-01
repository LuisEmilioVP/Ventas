using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Application.Dto.Venta;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;



namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService VentaService;

        public VentaController(IVentaService VentaService) 
        {
            this.VentaService = VentaService;
        }

        // GET: api/<VentaController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.VentaService.Get();
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<VentaController>/5
        [HttpGet("ID")]
        public IActionResult Get(int id)
        {
            var result = this.VentaService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        
        [HttpPost("Save")]
        public IActionResult Post([FromBody] VentaAddDto VentaAdd)
        {
            var result = this.VentaService.Save(VentaAdd);

            if (!result.Success)
                return BadRequest(result);
            return Ok();
        }

       
        [HttpPut("Update")]
        public IActionResult Put([FromBody] VentaUpdateDto VentaUpdate)
        {
            var result = this.VentaService.Update(VentaUpdate);

            if (!result.Success)
                return BadRequest(result);
            return Ok();            
        }

       
        [HttpDelete("Remove")]
        public IActionResult Delete([FromBody] VentaRemoveDto VentaRemove)
        {
            var result = this.VentaService.Delete(VentaRemove);

            if (!result.Success)
                return BadRequest(result);
            return Ok();
         }
    }
}
