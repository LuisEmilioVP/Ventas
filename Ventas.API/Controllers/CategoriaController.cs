using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Application.Dtos.Categoria;

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        [HttpGet("ShowCategory")]
        public IActionResult Get()
        {
            var result = this.categoriaService.Get();
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("ShowCategoryById")]
        public IActionResult Get(int id)
        {
            var result = this.categoriaService.GetById(id);
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveCategory")]
        public IActionResult Post([FromBody] CategoriaAddDto categoriaAdd)
        {
            var result = this.categoriaService.Save(categoriaAdd);
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateCategory")]
        public IActionResult Put([FromBody] CategoriaUpdateDto categoriaUpdate)
        {
            var result = this.categoriaService.Update(categoriaUpdate);
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveCategory")]
        public IActionResult Delete(CategoriaRemoveDto categoriaRemove)
        {
            var result = this.categoriaService.Remove(categoriaRemove);
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
