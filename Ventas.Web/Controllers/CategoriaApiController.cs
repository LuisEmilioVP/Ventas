using Microsoft.AspNetCore.Mvc;
using Ventas.Web.APIs.ApiServices.Interfaces;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Models.Categoria.Request;
using Ventas.Web.Models.Categoria.Response;

namespace Ventas.Web.Controllers
{
    public class CategoriaApiController : Controller
    {
        private readonly ICategoriaApiService categoriaApiService;

        public CategoriaApiController(ICategoriaApiService categoriaApiService)
        {
            this.categoriaApiService = categoriaApiService;
        }

        // GET: CategoriaApiController
        public ActionResult Index()
        {
            try
            {
                CategoriaListResponse categoriaList = new();

                categoriaList = categoriaApiService.Get();

                if (!categoriaList.Success)
                    throw new Exception(categoriaList.Message);

                return View(categoriaList.Data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CategoriaApiController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CategoriaDetailsResponse categoriaDetails = new();

                categoriaDetails = categoriaApiService.GetById(id);

                if (!categoriaDetails.Success)
                    throw new Exception(categoriaDetails.Message);

                return View(categoriaDetails.Data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CategoriaApiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaApiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaAddRequest categoriaAdd)
        {
            try
            {
                var result = categoriaApiService.Add(categoriaAdd);

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

        // GET: CategoriaApiController/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriaDetailsResponse category = new();

            category = categoriaApiService.GetById(id);

            if (!category.Success)
                throw new Exception(category.Message);

            if (category.Data == null)
                throw new Exception("El usuario no puede ser nulo");

            CategoriaUpdateRequest categoriaUpdate = category.Data.ConvertUsuarioToUpdateRequest();

            return View(categoriaUpdate);
        }

        // POST: CategoriaApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriaUpdateRequest categoriaUpdate)
        {
            try
            {
                var result = categoriaApiService.Update(categoriaUpdate);

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

        // GET: CategoriaApiController/Delete/5
        public ActionResult Delete(int id)
        {
            CategoriaRemoveRequest categoriaRemove = new(id);

            return View(categoriaRemove);
        }

        // POST: CategoriaApiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoriaRemoveRequest categoriaRemove)
        {
            try
            {
                var result = categoriaApiService.Remove(categoriaRemove);

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
    }
}
