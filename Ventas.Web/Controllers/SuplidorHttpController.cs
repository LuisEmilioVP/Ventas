using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ventas.Web.Controllers.Extention;
using Ventas.Web.Http.Interface;
using Ventas.Web.Models.Suplidor.Request;
using Ventas.Web.Models.Suplidor.Response;

namespace Ventas.Web.Controllers
{
    public class SuplidorHttpController : Controller
    {

        private readonly ISuplidorHttpService suplidorHttp;

        public SuplidorHttpController(ISuplidorHttpService suplidorHttp)
        {
            this.suplidorHttp = suplidorHttp;
        }

        // GET: SuplidorHttpController
        public ActionResult Index()
        {
            try
            {
                SuplidorListResponse suplidorList = new();

                suplidorList = suplidorHttp.Get();

                if (!suplidorList.Success)
                    throw new Exception(suplidorList.Message);

                return View(suplidorList.Data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: SuplidorHttpController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                SuplidorDetailsResponse suplidorDetails = new();

                suplidorDetails = suplidorHttp.GetById(id);

                if (!suplidorDetails.Success)
                    throw new Exception(suplidorDetails.Message);

                return View(suplidorDetails.Data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: SuplidorHttpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuplidorHttpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuplidorAddRequest suplidorAdd)
        {
            try
            {
                var result = suplidorHttp.Add(suplidorAdd);

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

        // GET: SuplidorHttpController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                SuplidorDetailsResponse details = new();

                details = suplidorHttp.GetById(id);

                if (!details.Success)
                    throw new Exception(details.Message);

                if (details.Data == null)
                    throw new Exception("El suplidor no puede ser nula");

                SuplidorUpdateRequest suplidorUpdate = details.Data.ConvertSuplidorToUpdateRequest();

                return View(suplidorUpdate);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: SuplidorHttpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuplidorUpdateRequest suplidorUpdate)
        {
            try
            {
                var result = suplidorHttp.Update(suplidorUpdate);

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

        // GET: SuplidorHttpController/Delete/5
        public ActionResult Delete(int id)
        {
            SuplidorRemoveRequest suplidorRemove = new(id);

            return View(suplidorRemove);
        }

        // POST: SuplidorHttpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuplidorRemoveRequest suplidorRemove)
        {
            try
            {
                var result = suplidorHttp.Revome(suplidorRemove);

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
