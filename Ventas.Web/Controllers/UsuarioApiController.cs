using Microsoft.AspNetCore.Mvc;
using Ventas.Web.APIs.ApiServices.Interfaces;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Models.Usuario.Request;
using Ventas.Web.Models.Usuario.Response;

namespace Ventas.Web.Controllers
{

    public class UsuarioApiController : Controller
    {
        private readonly IUsuarioApiService usuarioApiService;

        public UsuarioApiController(IUsuarioApiService usuarioApiService)
        {
            this.usuarioApiService = usuarioApiService;
        }

        // GET: UsuarioApiController
        public ActionResult Index()
        {
            try
            {
                UsuarioListResponse usuarioList = new();
                
                usuarioList = usuarioApiService.Get();
                
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

        // GET: UsuarioApiController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                UsuarioDetailsResponse usuarioDetails = new();

                usuarioDetails = usuarioApiService.GetById(id);

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

        // GET: UsuarioApiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioApiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioAddRequest usuarioAdd)
        {
            try
            {
                var result = usuarioApiService.Add(usuarioAdd);

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

        // GET: UsuarioApiController/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioDetailsResponse user = new();

            user = usuarioApiService.GetById(id);

            if (!user.Success)
                throw new Exception(user.Message);

            if (user.Data == null)
                throw new Exception("El usuario no puede ser nulo");

            UsuarioUpdateRequest userUpdate = user.Data.ConvertUsuarioToUpdateRequest();

            return View(userUpdate);
        }

        // POST: UsuarioApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioUpdateRequest usuarioUpdate)
        {
            try
            {
                var result = usuarioApiService.Update(usuarioUpdate);

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

        // GET: UsuarioApiController/Delete/5
        public ActionResult Delete(int id)
        {
            UsuarioRemoveRequest usuarioRemove = new(id);

            return View(usuarioRemove);
        }

        // POST: UsuarioApiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioRemoveRequest usuarioRemove)
        {
            try
            {
                var result = usuarioApiService.Remove(usuarioRemove);

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
