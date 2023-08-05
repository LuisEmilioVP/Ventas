using Microsoft.AspNetCore.Mvc;
using Ventas.Application.Contract;
using Ventas.Infrastructure.Models;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Models.Producto;
using Ventas.Web.Models.Producto.Request;

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

            try
            {
                var result = productoService.Get();

                if (!result.Success)
                    throw new Exception(result.Message);

                var produlist = result.Data as List<ProductoModels>
                        ?? throw new Exception("No se encontro ningun producto.");

                List<BaseProductoModel> productoResponses = produlist
                     .Select(pro => pro.ConverModelToProductoResponse()).ToList();

                return View(productoResponses);
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
            
            
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = productoService.GetById(id);

                if (!result.Success)
                    throw new Exception(result.Message);

                var listproById = result.Data as ProductoModels
                    ?? throw new Exception("El producto no existe");

                BaseProductoModel productoResponse = listproById.ConverModelToProductoResponse();

                return View(productoResponse);
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }

            
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoAddRequest productoAdd)
        {
            try
            {
                var producto = productoAdd.ConverAddRequestToAddDto();

                var result = this.productoService.Add(producto);

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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            var result = productoService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;

            var producto = result.Data as ProductoModels
                ?? throw new Exception("No existe este producto");

            ProductoUpdateRequest updateProducto = producto.ConverProductoToUpdateRequest();

            return View(updateProducto);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductoUpdateRequest productoUpdateRequest)
        {
            try
            {
                var producto = productoUpdateRequest.ConverUpdateRequestToUpdateDto();

                var result = this.productoService.Update(producto);

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
            ProductoRemoveRequest productoRemove = new ProductoRemoveRequest(id);
           
            return View(productoRemove);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductoRemoveRequest productoRemove)
        {
            try
            {
                var producto = productoRemove.ConverRemoveDtoToRemoveRequest();

                var result = this.productoService.Remove(producto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
