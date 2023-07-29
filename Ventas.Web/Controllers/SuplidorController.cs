using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Ventas.Application.Contract;
using Ventas.Application.Dto.Suplidor;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;
using Ventas.Web.Models;

namespace Ventas.Web.Controllers
{
    public class SuplidorController : Controller
    {

        private readonly ISuplidorService suplidorService;

        public SuplidorController(ISuplidorService suplidorService)
        {
            this.suplidorService = suplidorService;
        }

        // GET: SuplidorController
        public ActionResult Index()
        {
            var suplidor = suplidorService.Get();

            if (!suplidor.Success)
                ViewBag.Message = suplidor.Message;

            var supliList = (List<SuplidorModels>)suplidor.Data;

            return View(supliList);
        }

        // GET: SuplidorController/Details/5
        public ActionResult Details(int id)
        {
            var suplidor = suplidorService.GetById(id);

            if (!suplidor.Success)
                ViewBag.Message = suplidor.Message;

            var supliDetails = (SuplidorModels)suplidor.Data;

            return View(supliDetails);
        }

        // GET: SuplidorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuplidorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(SuplidorAddDto suplidorAddDto)
        {
            try
            {
                var suplidor = this.suplidorService.Save(suplidorAddDto);

                if (!suplidor.Success)
                {
                  ViewBag.Message = suplidor.Message;
                  return View(suplidor);
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
            var suplidor = suplidorService.GetById(id);

            if (!suplidor.Success)
                ViewBag.Message = suplidor.Message;

            var supliEdit = (SuplidorModels)suplidor.Data;

            return View(supliEdit);
        }

        // POST: SuplidorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(SuplidorUpdateDto suplidorUpdateDto)
        {
            try
            {
                var suplidor = this.suplidorService.Update(suplidorUpdateDto);

                if (!suplidor.Success)
                {
                    ViewBag.Message = suplidor.Message;
                    return View(suplidor);
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
            var suplidor = suplidorService.GetById(id);

            if (!suplidor.Success)
                ViewBag.Message = suplidor.Message;

            var supliDelete = (SuplidorModels)suplidor.Data;

            return View(supliDelete);
        }

        // POST: kkkController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuplidorRemoveDto suplidorRemoveDto)
        {
            try
            {
                var suplidor = this.suplidorService.Delete(suplidorRemoveDto);

                if (!suplidor.Success)
                {
                    ViewBag.Message = suplidor.Message;
                    return View(suplidor);
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
