using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Dtos.Categoria;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        [HttpGet("ShowCategory")]
        public IActionResult Get()
        {
            var cats = this.categoriaRepository.GetAllCategory();
            return Ok(cats);
        }

        [HttpGet("ShowCategoryById")]
        public IActionResult Get(int id)
        {
            var cat = this.categoriaRepository.GetCategoryById(id);
            return Ok(cat);
        }

        [HttpPost("SaveCategory")]
        public IActionResult Post([FromBody] CategoriaAddDto categoriaAdd)
        {
            this.categoriaRepository.Add(new Categoria()
            {
                Descripcion = categoriaAdd.Descripcion,
                EsActivo = categoriaAdd.State,
                FechaRegistro = categoriaAdd.RegisterDateAndTime,
                CreationUser = categoriaAdd.ChangeUser,
                CreationDate = categoriaAdd.ChangeDate,
            });

            return Ok();
        }

        [HttpPut("UpdateCategory")]
        public IActionResult Put([FromBody] CategoriaUpdateDto categoriaUpdate)
        {
            Categoria categoriaToUpdate = new Categoria()
            {
                IdCategoria = categoriaUpdate.IdCategoria,
                Descripcion = categoriaUpdate.Descripcion,
                EsActivo = categoriaUpdate.State,
                FechaRegistro = categoriaUpdate.RegisterDateAndTime,
                UserMod = categoriaUpdate.ChangeUser,
                ModifyDate = categoriaUpdate.ChangeDate,
            };

            this.categoriaRepository.Update(categoriaToUpdate);
            return Ok();
        }

        [HttpDelete("RemoveCategory")]
        public IActionResult Delete(CategoriaRemoveDto categoriaRemove)
        {
            Categoria categoriaToDelete = new Categoria()
            {
                IdCategoria = categoriaRemove.IdCategoria,
                UserDeleted = categoriaRemove.ChangeUser,
                DeletedDate = categoriaRemove.ChangeDate,
                Deleted = categoriaRemove.Deleted,
            };

            this.categoriaRepository.Remove(categoriaToDelete);
            return Ok();
        }
    }
}
