using Microsoft.AspNetCore.Mvc;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Http.Interfaces;
using Ventas.Web.Models.Venta.Request;
using Ventas.Web.Models.Venta.Response;

namespace Ventas.Web.Controllers
{
    public class VentaHttpController : Controller
    {
        private readonly IVentaHttpService ventaHttpService;

        public VentaHttpController(IVentaHttpService ventaHttpService)
        {
            this.ventaHttpService = ventaHttpService;
        }

        // GET: VentaHttpController
        public ActionResult Index()
        {
            try
            {
                VentaListResponse ventaList = new();

                ventaList = ventaHttpService.Get();

                if (!ventaList.Success)
                    throw new Exception(ventaList.Message);

                return View(ventaList.Data);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: VentaHttpController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                VentaDetailsResponse ventaDetails = new();

                ventaDetails = ventaHttpService.GetById(id);

                if (!ventaDetails.Success)
                    throw new Exception(ventaDetails.Message);

                return View(ventaDetails.Data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: VentaHttpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentaHttpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VentaAddRequest ventaAdd)
        {
            try
            {
                var result = ventaHttpService.Add(ventaAdd);

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

        // GET: VentaHttpController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                VentaDetailsResponse details = new();

                details = ventaHttpService.GetById(id);

                if (!details.Success)
                    throw new Exception(details.Message);

                if (details.Data == null)
                    throw new Exception("La Venta no puede ser nula");

                VentaUpdateRequest ventaUpdate = details.Data.ConvertVentaToUpdateRequest();

                return View(ventaUpdate);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: VentaHttpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VentaUpdateRequest ventaUpdate)
        {
            try
            {
                var result = ventaHttpService.Update(ventaUpdate);

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

        // GET: VentaHttpController/Delete/5
        public ActionResult Delete(int id)
        {
            VentaRemoveRequest ventaRemove = new(id);

            return View(ventaRemove);
        }

        // POST: VentaHttpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VentaRemoveRequest ventaRemove)
        {
            try
            {
                var result = ventaHttpService.Remove(ventaRemove);

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
