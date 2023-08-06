using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Ventas.Application.Contract;
using Ventas.Application.Dto.Suplidor;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;
using Ventas.Web.Controllers.Extention;
using Ventas.Web.Models;
using Ventas.Web.Models.Suplidor;
using Ventas.Web.Models.Suplidor.Request;
using Ventas.Web.Models.Suplidor.Response;

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
            try
            {
                var result = suplidorService.Get();

                if (!result.Success)
                    throw new Exception(result.Message);

                var listSupl = result.Data as List<SuplidorModels>
                    ?? throw new Exception("No se encontraron usuarios");

                List<BaseSuplidorModel> suplidorResponses = listSupl
                    .Select(cat => cat.ConverterModelToSuplidorResponse()).ToList();

                return View(suplidorResponses);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: SuplidorController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = suplidorService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var listSuplById = result.Data as SuplidorModels
                    ?? throw new Exception("El Suplidor no existe");

                BaseSuplidorModel suplidorResponse = listSuplById.ConverterModelToSuplidorResponse();

                return View(suplidorResponse);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuplidorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(SuplidorAddRequest suplidorAdd)
        {
            try
            {
                var supli = suplidorAdd.ConvertAddRequestToAddDto();

                var result = this.suplidorService.Save(supli);

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

        // GET: SuplidorController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.suplidorService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;

            var suplidor = result.Data as SuplidorModels
                ?? throw new Exception("Suplidor no existente.");

            SuplidorUpdateRequest suplidorUpdate = suplidor.ConvertSuplidorToUpdateRequest();

            return View(suplidorUpdate);
        }


        // POST: SuplidorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, SuplidorUpdateRequest suplidorUpdate)
        {
            try
            {
                var supli = suplidorUpdate.ConvertUpdateRequestToUpdateDto();

                var result = this.suplidorService.Update(supli);

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

        // GET: kkkController1/Delete/5
        public ActionResult Delete(int id)
        {
            SuplidorRemoveRequest suplidorRemove = new(id);

            return View(suplidorRemove);
        }

        // POST: kkkController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuplidorRemoveRequest suplidorRemove)
        {
            try
            {
                var supli = suplidorRemove.ConvertRemoveDtoToRemoveRequest();

                var result = this.suplidorService.Delete(supli);
                  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
