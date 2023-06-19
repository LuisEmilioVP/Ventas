using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Dtos.Venta;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaRepository ventaRepository;

        public VentaController(IVentaRepository ventaRepository)
        {
            this.ventaRepository = ventaRepository;
        }

        [HttpGet("ShowVentas")]
        public IActionResult Get()
        {
            var venta = this.ventaRepository.GetAllVentas();
            return Ok(venta);
        }

        [HttpGet("ShowVentaById")]
        public IActionResult Get(int id)
        {
            var venta = this.ventaRepository.GetVentaById(id);
            return Ok(venta);
        }

        [HttpPost("SaveVenta")]
        public IActionResult Post([FromBody] VentaAddDto ventaAdd)
        {
            this.ventaRepository.Add(new Ventas.Domain.Entities.Venta()
            {
                NumeroVenta = ventaAdd.NumeroVenta,
                IdTipoDocumentoVenta = ventaAdd.IdTipoDocumentoVenta,
                IdUsuario = ventaAdd.IdUsuario,
                DocumentoCliente = ventaAdd.DocumentoCliente,
                NombreCliente = ventaAdd.NombreCliente,
                SubTotal = ventaAdd.SubTotal,
                ImpuestoTotal = ventaAdd.ImpuestoTotal,
                Total = ventaAdd.Total,
                FechaRegistro = ventaAdd.FechaRegistro
            });
            return Ok();
        }

        [HttpPut("UpdateVenta")]
        public IActionResult Put([FromBody] VentaUpdateDto ventaUpdate)
        {
            Ventas.Domain.Entities.Venta ventaToUpdate = new Ventas.Domain.Entities.Venta()
            {
                IdVenta = ventaUpdate.IdVenta,
                NumeroVenta = ventaUpdate.NumeroVenta,
                IdTipoDocumentoVenta = ventaUpdate.IdTipoDocumentoVenta,
                IdUsuario = ventaUpdate.IdUsuario,
                DocumentoCliente = ventaUpdate.DocumentoCliente,
                NombreCliente = ventaUpdate.NombreCliente,
                SubTotal = ventaUpdate.SubTotal,
                ImpuestoTotal = ventaUpdate.ImpuestoTotal,
                Total = ventaUpdate.Total,
                FechaRegistro = ventaUpdate.FechaRegistro
            };

            this.ventaRepository.Update(ventaToUpdate);
            return Ok();
        }

        [HttpDelete("RemoveVenta")]
        public IActionResult Delete([FromBody] VentaRevoveDto ventaRevove)
        {
            Ventas.Domain.Entities.Venta ventaToDelete = new Ventas.Domain.Entities.Venta()
            {
                IdVenta = ventaRevove.IdVenta,
                UserDeleted = ventaRevove.ChangeUser,
                DeletedDate = ventaRevove.ChangeDate,
                Deleted = ventaRevove.Deleted
            };

            this.ventaRepository.Remove(ventaToDelete);
            return Ok();
        }
    }
}
