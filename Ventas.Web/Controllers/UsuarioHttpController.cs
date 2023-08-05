using Microsoft.AspNetCore.Mvc;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Http.Interfaces;
using Ventas.Web.Models.Usuario.Request;
using Ventas.Web.Models.Usuario.Response;

namespace Ventas.Web.Controllers
{
    public class UsuarioHttpController : Controller
    {
        private readonly IUsuarioHttpService usuarioHttpService;

        public UsuarioHttpController(IUsuarioHttpService usuarioHttpService)
        {
            this.usuarioHttpService = usuarioHttpService;
        }

        // GET: UsuarioHttpController
        public ActionResult Index()
        {
            try
            {
                UsuarioListResponse usuarioList = new();

                usuarioList = usuarioHttpService.Get();

                if (!usuarioList.Success)
                    throw new Exception(usuarioList.Message);

                return View(usuarioList.Data);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: UsuarioHttpController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                UsuarioDetailsResponse usuarioDetails = new();

                usuarioDetails = usuarioHttpService.GetById(id);

                if (!usuarioDetails.Success)
                    throw new Exception(usuarioDetails.Message);

                return View(usuarioDetails.Data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: UsuarioHttpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioHttpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioAddRequest usuarioAdd)
        {
            try
            {
                var result = usuarioHttpService.Add(usuarioAdd);

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

        // GET: UsuarioHttpController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                UsuarioDetailsResponse details = new();

                details = usuarioHttpService.GetById(id);

                if (!details.Success)
                    throw new Exception(details.Message);

                if (details.Data == null)
                    throw new Exception("El Usuario no puede ser nulo");

                UsuarioUpdateRequest usuarioUpdate = details.Data.ConvertUsuarioToUpdateRequest();

                return View(usuarioUpdate);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: UsuarioHttpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioUpdateRequest usuarioUpdate)
        {
            try
            {
                var result = usuarioHttpService.Update(usuarioUpdate);

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

        // GET: UsuarioHttpController/Delete/5
        public ActionResult Delete(int id)
        {
            UsuarioRemoveRequest usuarioRemove = new(id);

            return View(usuarioRemove);
        }

        // POST: UsuarioHttpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioRemoveRequest usuarioRemove)
        {
            try
            {
                var result = usuarioHttpService.Revome(usuarioRemove);

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
