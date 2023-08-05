using Microsoft.AspNetCore.Mvc;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Http.Interfaces;
using Ventas.Web.Models.Categoria.Request;
using Ventas.Web.Models.Categoria.Response;

namespace Ventas.Web.Controllers
{
    public class CategoriaHttpController : Controller
    {
        private readonly ICategoriaHttpService categoriaHttp;

        public CategoriaHttpController(ICategoriaHttpService categoriaHttp)
        {
            this.categoriaHttp = categoriaHttp;
        }

        // GET: CategoriaHttpController
        public ActionResult Index()
        {
            try
            {
                CategoriaListResponse categoriaList = new();

                categoriaList = categoriaHttp.Get();

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

        // GET: CategoriaHttpController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                CategoriaDetailsResponse categoriaDetails = new();

                categoriaDetails = categoriaHttp.GetById(id);

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

        // GET: CategoriaHttpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaHttpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaAddRequest categoriaAdd)
        {
            try
            {
                var result = categoriaHttp.Add(categoriaAdd);

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

        // GET: CategoriaHttpController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CategoriaDetailsResponse details = new();

                details = categoriaHttp.GetById(id);

                if (!details.Success)
                    throw new Exception(details.Message);

                if (details.Data == null)
                    throw new Exception("La categoría no puede ser nula");

                CategoriaUpdateRequest categoriaUpdate = details.Data.ConvertCategoriaToUpdateRequest();

                return View(categoriaUpdate);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            
        }

        // POST: CategoriaHttpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriaUpdateRequest categoriaUpdate)
        {
            try
            {
                var result = categoriaHttp.Update(categoriaUpdate);

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

        // GET: CategoriaHttpController/Delete/5
        public ActionResult Delete(int id)
        {
            CategoriaRemoveRequest categoriaRemove = new(id);

            return View(categoriaRemove);
        }

        // POST: CategoriaHttpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoriaRemoveRequest categoriaRemove)
        {
            try
            {
                var result = categoriaHttp.Revome(categoriaRemove);

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
