using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Dtos.Negocio;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase

    { 
        private readonly INegocioRepository NegocioRepository;

        public NegocioController(INegocioRepository NegocioRepository)
        {
            this.NegocioRepository = NegocioRepository;
        }

        [HttpGet("ShowNegocio")]
        public IActionResult Get()
        {
            var negocios = this.NegocioRepository.GetAllNegocio();
            return Ok(negocios);
        }

        [HttpGet("ShowNegocioById")]
        public IActionResult Get(int id)
        {
            var negocio = this.NegocioRepository.GetNegocio(id);
            return Ok(negocio);
        }

        [HttpPost("SaveNegocio")]
        public IActionResult Post([FromBody] NegocioAddDto NegocioAdd)
        {
            this.NegocioRepository.Add(new Negocio()
            {
                urlLogo = NegocioAdd.urlLogo,
                nombreLogo = NegocioAdd.nombreLogo,
                numeroDocumento = NegocioAdd.numeroDocumento,
                nombre = NegocioAdd.nombre,
                correo = NegocioAdd.correo,
                direccion = NegocioAdd.direccion,
                porcentajeImpuesto = NegocioAdd.porcentajeImpuesto,
                simboloMoneda = NegocioAdd.simboloMoneda,
                CreationUser = NegocioAdd.ChangeUser,
                CreationDate = NegocioAdd.ChangeDate,
            });

            return Ok();
        }

        [HttpPut("UpdateNegocio")]
        public IActionResult Put([FromBody] NegocioUpdateDto NegocioUpdate)
        {
            Negocio NegocioToUpdate = new Negocio()
            {
                idNegocio = NegocioUpdate.idNegocio,
                urlLogo = NegocioUpdate.urlLogo,
                nombreLogo = NegocioUpdate.nombreLogo,
                numeroDocumento = NegocioUpdate.numeroDocumento,
                nombre = NegocioUpdate.nombre,
                correo = NegocioUpdate.correo,
                direccion = NegocioUpdate.direccion,
                porcentajeImpuesto = NegocioUpdate.porcentajeImpuesto,
                simboloMoneda = NegocioUpdate.simboloMoneda,
                UserMod = NegocioUpdate.ChangeUser,
                ModifyDate = NegocioUpdate.ChangeDate,
            };

            this.NegocioRepository.Update(NegocioToUpdate);
            return Ok();
        }

        [HttpDelete("RemoveNegocio")]
        public IActionResult Delete(NegocioRemoveDto NegocioRemove)
        {
            Negocio NegocioToDelete = new Negocio()
            {
                idNegocio = NegocioRemove.idNegocio,
                UserDeleted = NegocioRemove.ChangeUser,
                DeletedDate = NegocioRemove.ChangeDate,
                Deleted = NegocioRemove.Deleted,
            };

            this.NegocioRepository.Remove(NegocioToDelete);
            return Ok();
        }
    }
}