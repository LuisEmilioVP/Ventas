using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Application.Dto.Suplidor;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;



namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuplidorController : ControllerBase
    {
        private readonly ISuplidorService suplidorService;

        public SuplidorController(ISuplidorService suplidorService) 
        {
            this.suplidorService = suplidorService;
        }

        // GET: api/<SuplidorController>
        [HttpGet("GetSuplidor")]
        public IActionResult Get()
        {
            var result = this.suplidorService.Get();
            if(!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        // GET api/<SuplidorController>/5
        [HttpGet("IdSuplidor")]
        public IActionResult Get(int id)
        {
            var result = this.suplidorService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        
        [HttpPost("SaveSuplidor")]
        public IActionResult Post([FromBody] SuplidorAddDto suplidorAdd)
        {
            var result = this.suplidorService.Save(suplidorAdd);

            if (!result.Success)
                return BadRequest(result);
            return Ok();
        }

       
        [HttpPost("UpdateSuplidor")]
        public IActionResult Put([FromBody] SuplidorUpdateDto suplidorUpdate)
        {
            var result = this.suplidorService.Update(suplidorUpdate);

            if (!result.Success)
                return BadRequest(result);
            return Ok();            
        }

       
        [HttpPost("RemoveSuplidor")]
        public IActionResult Delete([FromBody] SuplidorRemoveDto suplidorRemove)
        {
            var result = this.suplidorService.Delete(suplidorRemove);

            if (!result.Success)
                return BadRequest(result);
            return Ok();
         }
    }
}
