using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using Ventas.Application.Dto.Suplidor;
using Ventas.Domain.Entities;
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
            var suplidor = this.suplidorRepository.GetAllSuplidor();
            return Ok(suplidor);
        }

        // GET api/<SuplidorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var supli = this.suplidorRepository.GetsuplidorById(id);
            return Ok(supli);
        }

        
        [HttpPost("Save")]
        public IActionResult Post([FromBody] SuplidorAddDto suplidorAdd)
        {
            this.suplidorRepository.Add(new Suplidor()
            {
               Nombre = suplidorAdd.Nombre,
               Contacto = suplidorAdd.Contacto,
               Direccion = suplidorAdd.Direccion,
               Ciudad = suplidorAdd.Ciudad,
               Region = suplidorAdd.Region,
               Codigo_postal = suplidorAdd.Codigo_postal,
               Pais = suplidorAdd.Pais,
               Telefono = suplidorAdd.Telefono,
               Fax = suplidorAdd.Fax,
               CreationUser = suplidorAdd.ChangeUser,
               CreationDate = suplidorAdd.ChangeDate,
            });
            return Ok();
        }

       
        [HttpPut("Update")]
        public IActionResult Put([FromBody] SuplidorUpdateDto suplidorUpdate)
        {
           Suplidor suplidorToUpdate = new Suplidor()
            {
                IdSuplidor = suplidorUpdate.IdSuplidor,
                Nombre = suplidorUpdate.Nombre,
                Contacto = suplidorUpdate.Contacto,
                Direccion = suplidorUpdate.Direccion,
                Ciudad = suplidorUpdate.Ciudad,
                Region = suplidorUpdate.Region,
                Codigo_postal = suplidorUpdate.Codigo_postal,
                Pais = suplidorUpdate.Pais,
                Telefono = suplidorUpdate.Telefono,
                Fax = suplidorUpdate.Fax,
                UserMod = suplidorUpdate.ChangeUser,
                ModifyDate = suplidorUpdate.ChangeDate,
            };

            this.suplidorRepository.Update(suplidorToUpdate);
            return Ok();
        }

       
        [HttpDelete("Remove")]
        public IActionResult Delete([FromBody] SuplidorRemoveDto suplidorRemove)
        {
            Suplidor suplidorToDelete = new Suplidor()
            {
                IdSuplidor = suplidorRemove.IdSuplidor,
                UserDeleted = suplidorRemove.ChangeUser,
                DeletedDate = suplidorRemove.ChangeDate,
                Deleted = suplidorRemove.Deleted,
              
            };

            this.suplidorRepository.Update(suplidorToDelete);
            return Ok();
        }
    }
}
