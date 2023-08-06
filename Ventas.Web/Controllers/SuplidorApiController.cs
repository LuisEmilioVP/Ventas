using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ventas.Web.API.ApiServices.Interface;
using Ventas.Web.Controllers.Extention;
using Ventas.Web.Models.Suplidor.Request;
using Ventas.Web.Models.Suplidor.Response;

namespace Ventas.Web.Controllers
{
    public class SuplidorApiController : Controller
    {

        private readonly ISuplidorApiService suplidorApiService;

        public SuplidorApiController(ISuplidorApiService suplidorApiService)
        {
            this.suplidorApiService = suplidorApiService;

        }

        // GET: SuplidorApiController
        public ActionResult Index()
            {
                try
                {
                    SuplidorListResponse suplidorList = new();

                    suplidorList = suplidorApiService.Get();

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

            // GET: SuplidorApiController/Details/5
            public ActionResult Details(int id)
                {
                    try
                    {
                        SuplidorDetailsResponse suplidorDetails = new();

                        suplidorDetails = suplidorApiService.GetById(id);

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

        // GET: SuplidorApiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuplidorApiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuplidorAddRequest suplidorAdd)
        {
            try
            {
                var result = suplidorApiService.Add(suplidorAdd);

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

        // GET: SuplidorApiController/Edit/5
        public ActionResult Edit(int id)
        {
            SuplidorDetailsResponse suplidor = new();

            suplidor = suplidorApiService.GetById(id);

            if (!suplidor.Success)
                throw new Exception(suplidor.Message);

            if (suplidor.Data == null)
                throw new Exception("El suplidor no debe ser nulo");

            SuplidorUpdateRequest suplidorUpdate = suplidor.Data.ConvertSuplidorToUpdateRequest();

            return View(suplidorUpdate);
        }

        // POST: SuplidorApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuplidorUpdateRequest suplidorUpdate)
        {
            try
            {
                var result = suplidorApiService.Update(suplidorUpdate);

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

        // GET: SuplidorApiController/Delete/5
        public ActionResult Delete(int id)
        {
            SuplidorRemoveRequest suplidorRemove = new(id);

            return View(suplidorRemove);
        }

        // POST: SuplidorApiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuplidorRemoveRequest suplidorRemove)
        {
            try
            {
                var result = suplidorApiService.Remove(suplidorRemove);

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
