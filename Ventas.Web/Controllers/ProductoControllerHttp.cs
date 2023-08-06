using Microsoft.AspNetCore.Mvc;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Http.Interfaces;
using Ventas.Web.Models.Producto.Request;
using Ventas.Web.Models.Producto.Response;

namespace Ventas.Web.Controllers
{
    public class ProductoControllerHttp : Controller
    {
        private readonly IProductoHttpService productoHttpService;

        public ProductoControllerHttp(IProductoHttpService productoHttpService)
        {
            this.productoHttpService = productoHttpService;
        }
        // GET: ProductoControllerHttp
        public ActionResult Index()
        {
            try
            {
                ProductoListResponse productoList = new();

                productoList = productoHttpService.Get();

                if (!productoList.Success)
                    throw new Exception(productoList.Message);

                return View(productoList.Data);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ProductoControllerHttp/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ProductoDetailsResponse productoDetails = new();

                productoDetails = productoHttpService.GetById(id);

                if (!productoDetails.Success)
                    throw new Exception(productoDetails.Message);

                return View(productoDetails.Data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ProductoControllerHttp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoControllerHttp/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoAddRequest productoAdd)
        {
            try
            {
                var result = productoHttpService.Add(productoAdd);

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

        // GET: ProductoControllerHttp/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ProductoDetailsResponse details = new();

                details = productoHttpService.GetById(id);

                if (!details.Success)
                    throw new Exception(details.Message);

                if (details.Data == null)
                    throw new Exception("No puede ser nulo");

                ProductoUpdateRequest productoUpdate = details.Data.ConverProductoToUpdateRequest();

                return View(productoUpdate);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ProductoControllerHttp/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductoUpdateRequest productoUpdate)
        {
            try
            {
                var result = productoHttpService.Update(productoUpdate);

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

        // GET: ProductoControllerHttp/Delete/5
        public ActionResult Delete(int id)
        {

            ProductoRemoveRequest usuarioRemove = new(id);

            return View(usuarioRemove);
        }

        // POST: ProductoControllerHttp/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductoRemoveRequest productoRemove)
        {
            try
            {
                var result = productoHttpService.Remove(productoRemove);

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
