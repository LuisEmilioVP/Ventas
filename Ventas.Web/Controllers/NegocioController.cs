using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Application.Dtos.Negocio;
using Ventas.Infrastructure.Models;

namespace Ventas.Web.Controllers
{
    public class NegocioController : Controller
    {
        private readonly INegocioService negocioService;

        public NegocioController(INegocioService negocioService)
        {
            this.negocioService = negocioService;
        }

        // GET: NegocioController
        public ActionResult Index()
        {
            var result = negocioService.Get();
            if (!result.Success)
                ViewBag.Message = result.Message;

            var negolist = (List<NegocioModel>)result.Data;

            return View(negolist);
        }

        // GET: NegocioController/Details/5
        public ActionResult Details(int id)
        {
            var result = negocioService.GetById(id);
            if (!result.Success)
                ViewBag.Message = result.Message;

            var negoDetails = (NegocioModel)result.Data;

            return View(negoDetails);
        }

        // GET: NegocioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NegocioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NegocioAddDto negocioAddDto)
        {
            try
            {
                var result = this.negocioService.Save(negocioAddDto);


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

        // GET: NegocioController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = negocioService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;

            var negoEdit = (NegocioModel)result.Data;   

            return View(negoEdit);
        }

        // POST: NegocioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NegocioUpdateDto negocioUpdateDto)
        {
            try
            {
                var result = this.negocioService.Update(negocioUpdateDto);

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

        // GET: NegocioController/Delete/5
        public ActionResult Delete(int id)
        {
            var negocio = negocioService.GetById(id);

            if (!negocio.Success)
                ViewBag.Message = negocio.Message;

            var negoDelete = (NegocioModel)negocio.Data;

            return View(negoDelete);
        }

        // POST: NegocioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(NegocioRemoveDto negocioRemoveDto)
        {
            try
            {
                var negocio = this.negocioService.Remove(negocioRemoveDto);

                if (!negocio.Success)
                {
                    ViewBag.Message = negocio.Message;
                    return View(negocio);
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
