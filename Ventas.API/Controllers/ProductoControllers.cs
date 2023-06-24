using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Application.Dtos.Producto;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService productoService;

        public ProductoController(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.productoService.Get();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.productoService.GetById(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST api/<ProductoController>
        [HttpPost("Save")]
        public IActionResult Post([FromBody] ProductoAddDto productoAdd)
        {
            var result = this.productoService.Add(productoAdd);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("Update")]
        public IActionResult Put([FromBody] ProductoUpdateDto productoUpdate)
        {

            var result = this.productoService.Update(productoUpdate);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("Remove")]
        public IActionResult Delete([FromBody] ProductoRemoveDto productoRemove)
        {
            var result = this.productoService.Remove(productoRemove);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

