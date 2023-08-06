using Microsoft.AspNetCore.Mvc;
using Ventas.Web.Controllers.Extensions;
using Ventas.Web.Http.Interfaces;
using Ventas.Web.Models.Negocio.Request;
using Ventas.Web.Models.Negocio.Response;

namespace Ventas.Web.Controllers
{
    public class NegocioHttpController : Controller
    {

        private readonly INegocioHttpService negocioHttpService;

        public NegocioHttpController(INegocioHttpService negocioHttpService)
        {
            this.negocioHttpService = negocioHttpService;
        }

        // GET: NegocioHttpController
        public ActionResult Index()
        {
            try
            {
                NegocioListResponse negocioList = new();

                negocioList = negocioHttpService.Get();

                if (!negocioList.Success)
                    throw new Exception(negocioList.Message);

                return View(negocioList.Data);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: NegocioHttpController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                NegocioDetailsResponse negocioDetails = new();

                negocioDetails = negocioHttpService.GetById(id);

                if (!negocioDetails.Success)
                    throw new Exception(negocioDetails.Message);

                return View(negocioDetails.Data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: NegocioHttpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NegocioHttpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NegocioAddRequest negocioAdd)
        {
            try
            {
                var result =  negocioHttpService.Add(negocioAdd);

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

        // GET: NegocioHttpController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                NegocioDetailsResponse details = new();

                details = negocioHttpService.GetById(id);

                if (!details.Success)
                    throw new Exception(details.Message);

                if (details.Data == null)
                    throw new Exception("El Negocio no puede ser nulo");

                NegocioUpdateRequest negocioUpdate = details.Data.ConvertNegocioToUpdateRequest();

                return View(negocioUpdate);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: NegocioHttpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NegocioUpdateRequest negocioUpdate)
        {
            try
            {
                var result = negocioHttpService.Update(negocioUpdate);

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

        // GET: NegocioHttpController/Delete/5
        public ActionResult Delete(int id)
        {
            NegocioRemoveRequest negocioRemove = new(id);

            return View(negocioRemove);
        }

        // POST: NegocioHttpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, NegocioRemoveRequest negocioRemove)
        {
            try
            {
                var result = negocioHttpService.Remove(negocioRemove);

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
