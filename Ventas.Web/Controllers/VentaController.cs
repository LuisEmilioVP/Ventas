using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Numerics;
using Ventas.Application.Contract;
using Ventas.Application.Dto.Venta;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;
using Ventas.Web.Models;

namespace Ventas.Web.Controllers
{
    public class VentaController : Controller
    {

        private readonly IVentaService VentaService;

        public VentaController(IVentaService VentaService)
        {
            this.VentaService = VentaService;
        }

        // GET: SuplidorController
        public ActionResult Index()
        {
            var Venta = VentaService.Get();

            if (!Venta.Success)
                ViewBag.Message = Venta.Message;

            var VentList = (List<VentaModels>)Venta.Data;

            return View(VentList);
        }

        // GET: VentaController/Details/5
        public ActionResult Details(int id)
        {
            var Venta = VentaService.GetById(id);

            if (!Venta.Success)
                ViewBag.Message = Venta.Message;

            var VentDetails = (VentaModels)Venta.Data;

            return View(VentDetails);
        }

        // GET: VentaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(VentaAddDto VentaAddDto)
        {
            try
            {
                var Venta = this.VentaService.Save(VentaAddDto);

                if (!Venta.Success)
                {
                  ViewBag.Message = Venta.Message;
                  return View(Venta);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuplidorController/Edit/5
        public ActionResult Edit(int id)
        {
            var Venta = VentaService.GetById(id);

            if (!Venta.Success)
                ViewBag.Message = Venta.Message;

            var VentEdit = (VentaModels)Venta.Data;

            return View(VentEdit);
        }

        // POST: SuplidorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(VentaUpdateDto VentaUpdateDto)
        {
            try
            {
                var Venta = this.VentaService.Update(VentaUpdateDto);

                if (!Venta.Success)
                {
                    ViewBag.Message = Venta.Message;
                    return View(Venta);
                }

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: kkkController1/Delete/5
        public ActionResult Delete(int id)
        {
            var Venta = VentaService.GetById(id);

            if (!Venta.Success)
                ViewBag.Message = Venta.Message;

            var VentDelete = (VentaModels)Venta.Data;

            return View(VentDelete);
        }

        // POST: kkkController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(VentaRemoveDto VentaRemoveDto)
        {
            try
            {
                var Venta = this.VentaService.Delete(VentaRemoveDto);

                if (!Venta.Success)
                {
                    ViewBag.Message = Venta.Message;
                    return View(Venta);
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
