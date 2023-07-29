using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Application.Dtos.Producto;
using Ventas.Infrastructure.Models;

namespace Ventas.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService productoService;

        public ProductoController(IProductoService productoService)
        {
            this.productoService = productoService;
        }


        // GET: HomeController1
        public ActionResult Index()
        {
            var result = productoService.Get();

            if (!result.Success)
                ViewBag.Message = result.Message;

            var produlist = (List<ProductoModels>)result.Data; 

            return View(produlist);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var result = productoService.GetById(id);
            if (!result.Success)
                ViewBag.Message = result.Message;

            var produDetails = (ProductoModels)result.Data;

            return View(produDetails);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoAddDto productoAddDtos)
        {
            try
            {
                var result = this.productoService.Add(productoAddDtos);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View(result);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            var result = productoService.GetById(id);
            if (!result.Success)
                ViewBag.Message = result.Message;

            var produEdit = (ProductoModels)result.Data;

            return View(produEdit);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoUpdateDto productoUpdateDto)
        {
            try
            {
                var result = this.productoService.Update(productoUpdateDto);

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

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
