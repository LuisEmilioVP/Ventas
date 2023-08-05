using Microsoft.AspNetCore.Mvc;
using Ventas.Web.APIs.ApiServices.Interfaces;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Models.Producto.Request;
using Ventas.Web.Models.Producto.Response;

namespace Ventas.Web.Controllers
{
    public class ProductoApiControllers : Controller
    {
        private readonly IProductoApiService productoApiService;

        public ProductoApiControllers(IProductoApiService productoApiService)
        {
            this.productoApiService = productoApiService;

        }
        // GET: ProductoApiControllers
        public ActionResult Index()
        {
            try
            {
                ProductoListResponse productoList = new();

                productoList = productoApiService.Get();

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

        // GET: ProductoApiControllers/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ProductoDetailsResponse productoDetails = new();

                productoDetails = productoApiService.GetById(id);

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

        // GET: ProductoApiControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoApiControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoAddRequest productoAdd)
        {
            try
            {
                var result = productoApiService.Add(productoAdd);

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

        // GET: ProductoApiControllers/Edit/5
        public ActionResult Edit(int id)
        {
            ProductoDetailsResponse producto = new();

            producto = productoApiService.GetById(id);

            if (!producto.Success)
                throw new Exception(producto.Message);

            if (producto.Data == null)
                throw new Exception("No puede ser nulo");

            ProductoUpdateRequest productoUpdate = producto.Data.ConverProductoToUpdateRequest();

            return View(productoUpdate);
        }

        // POST: ProductoApiControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductoUpdateRequest productoUpdate)
        {
            try
            {
                var result = productoApiService.Update(productoUpdate);

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

        // GET: ProductoApiControllers/Delete/5
        public ActionResult Delete(int id)
        {
            ProductoRemoveRequest productoRemove = new(id);

            return View(productoRemove);
        }

        // POST: ProductoApiControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductoRemoveRequest productoRemove)
        {
            try
            {
                var result = productoApiService.Remove(productoRemove);

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
