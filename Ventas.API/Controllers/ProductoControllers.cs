using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Dtos.Producto;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public IActionResult Get()
        {
            var producto = this.productoRepository.GetAllProducto();
            return Ok(producto);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int idproducto)
        {
            var produ = this.productoRepository.GetProductoById(idproducto);
            return Ok(produ);
        }

        // POST api/<ProductoController>
        [HttpPost("Save")]
        public IActionResult Post([FromBody] ProductoAddDto productoAdd)
        {
            //this.productoRepository.Add();

            return Ok();

        }

        // PUT api/<ProductoController>/5
        [HttpPost("Update")]
        public IActionResult Put([FromBody] ProductoUpdateDto productoUpdate)
        {
            Producto ProductoUpdateDto = new Producto()
            {

                IdProducto = productoUpdate.IdProducto,
                CodigoBarra = productoUpdate.CodigoBarra,
                Marca = productoUpdate.Marca,
                ProductoDescripcion = productoUpdate.ProductoDescripcion,
                Stock = productoUpdate.Stock,
                Precio = productoUpdate.Precio,
                UrlImagen = productoUpdate.UrlImagen,
                NombreImagen = productoUpdate.NombreImagen,
                FechaRegistro = productoUpdate.FechaRegistro,
                UserMod = productoUpdate.ChangeUser,
                ModifyDate = productoUpdate.ChangeDate
            };

            this.productoRepository.Update(ProductoUpdateDto);
            return Ok();
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("Remove")]
        public IActionResult Delete([FromBody] ProductoRemoveDto productoRemove)
        {
            Producto productoRemoveDto = new Producto()
            {
                IdProducto = productoRemove.IdProducto,
                UserDeleted = productoRemove.ChangeUser,
                DeletedDate = productoRemove.ChangeDate,
                Deleted = productoRemove.Deleted
            };

            this.productoRepository.Remove(productoRemoveDto);
            return Ok();
        }
    }
}

