using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Infrastructure.Models;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Models.Categoria;
using Ventas.Web.Models.Categoria.Request;

namespace Ventas.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        // GET: CategoriaController
        public ActionResult Index()
        {
            try
            {
                var result = categoriaService.Get();

                if (!result.Success)
                    throw new Exception(result.Message);

                var listCat = result.Data as List<CategoriaModels>
                    ?? throw new Exception("No se encontraron usuarios");

                List<BaseCategoriaModel> categoriaResponses = listCat
                    .Select(cat => cat.ConverterModelToCategoriaResponse()).ToList();

                return View(categoriaResponses);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = categoriaService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var listCatById = result.Data as CategoriaModels
                    ?? throw new Exception("El usuario no existe");

                BaseCategoriaModel categoriaResponse = listCatById.ConverterModelToCategoriaResponse();

                return View(categoriaResponse);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaAddRequest categoriaAdd)
        {
            try
            {
                var user = categoriaAdd.ConvertAddRequestToAddDto();

                var result = this.categoriaService.Save(user);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.categoriaService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;

            var category = result.Data as CategoriaModels
                ?? throw new Exception("No existe el usuario.");

            CategoriaUpdateRequest categoriaUpdate = category.ConvertCategoriaToUpdateRequest();

            return View(categoriaUpdate);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriaUpdateRequest categoriaUpdate)
        {
            try
            {
                var user = categoriaUpdate.ConvertUpdateRequestToUpdateDto();

                var result = this.categoriaService.Update(user);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            CategoriaRemoveRequest categoriaRemove = new(id);

            return View(categoriaRemove);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoriaRemoveRequest categoriaRemove)
        {
            try
            {
                var user = categoriaRemove.ConvertRemoveDtoToRemoveRequest();

                var result = this.categoriaService.Remove(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
