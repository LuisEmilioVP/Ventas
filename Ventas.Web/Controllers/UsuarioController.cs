using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Infrastructure.Models;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Models.Usuario.Request;
using Ventas.Web.Models.Usuario.Response;

namespace Ventas.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            try
            {
                var result = usuarioService.Get();

                if (!result.Success)
                    throw new Exception(result.Message);

                var listUser = result.Data as List<UsuarioModels>
                    ?? throw new Exception("No se encontraron usuarios");

                List<UsuarioResponse> usuarioResponses = listUser
                    .Select(use => use.ConverterModelTousuarioResponse()).ToList();

                return View(usuarioResponses);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: UsuarioController/Details/id
        public ActionResult Details(int id)
        {
            try
            {
                var result = usuarioService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var listUserById = result.Data as UsuarioModels
                    ?? throw new Exception("El usuario no existe");

                UsuarioResponse usuarioResponse = listUserById.ConverterModelTousuarioResponse();

                return View(usuarioResponse);
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

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioAddRequest usuarioAdd)
        {
            try
            {
                var user = usuarioAdd.ConvertAddRequestToAddDto();

                var result = this.usuarioService.Save(user);

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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.usuarioService.GetById(id);

           if (!result.Success)
                ViewBag.Message = result.Message;

            var user = result.Data as UsuarioModels
                ?? throw new Exception("No existe el usuario.");

            UsuarioUpdateRequest usuarioUpdate = user.ConvertUsuarioToUpdateRequest();

            return View(usuarioUpdate);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioUpdateRequest usuarioUpdate)
        {
            try
            {
                var user = usuarioUpdate.ConvertUpdateRequestToUpdateDto();

                var result = this.usuarioService.Update(user);

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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            UsuarioRemoveRequest usuarioRemove = new UsuarioRemoveRequest(id);

            return View(usuarioRemove);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioRemoveRequest usuarioRemove)
        {
            try
            {
                var user = usuarioRemove.ConvertRemoveDtoToRemoveRequest();

                var result = this.usuarioService.Remove(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
