using Microsoft.AspNetCore.Mvc;
using Ventas.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuplidorController : ControllerBase
    {
        private readonly ISuplidorRepository suplidorRepository;

        public SuplidorController(ISuplidorRepository suplidorRepository) 
        {
            this.suplidorRepository = suplidorRepository;
        }

        // GET: api/<SuplidorController>
        [HttpGet]
        public IActionResult Get()
        {
            var suplidor = this.suplidorRepository.GetEntities();
            return Ok(suplidor);
        }

        // GET api/<SuplidorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SuplidorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SuplidorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuplidorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
