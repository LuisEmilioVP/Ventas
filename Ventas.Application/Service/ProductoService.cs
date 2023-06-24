

using Microsoft.Extensions.Logging;
using System;
using Ventas.Application.Contract;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Producto;
using Ventas.Application.Extensions;
using Ventas.Application.Help;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Application.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository productoRepository;
        private readonly ILogger<ProductoService> logger;

        public ProductoService(IProductoRepository productoRepository, ILogger<ProductoService> logger)
        {
            this.productoRepository = productoRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var producto = this.productoRepository.GetAllProducto();
                result.Data = producto;
                result.Message = "Productos obtenidos";
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = "Error obteniendo los productos.";
                this.logger.LogError($"{result.Message}", e.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int idproducto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var producto = this.productoRepository.GetProductoById(idproducto);
                result.Data = producto;
                result.Message = "Producto obtenido";
             
            }
            catch(Exception e)
            {
                result.Success = false;
                result.Message = "Error al obtener el producto";
                this.logger.LogError($"{result.Message}", e.ToString());
            }

            return result;

        }

        public ServiceResult Remove(ProductoRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.productoRepository.Remove(new Producto()
                {
                    IdProducto = model.IdProducto,
                    UserDeleted = model.ChangeUser,
                    DeletedDate = model.ChangeDate,
                    Deleted = model.Deleted
                });

                result.Message = "Producto eliminado correctamente";

            }
            catch(Exception e)
            {
                result.Success = false;
                result.Message = "Error al borrar el producto";
                this.logger.LogError($"{result.Message}", e.ToString());

            }

            return result;
        }

        public ServiceResult Add(ProductoAddDto model)
        {
            ServiceResult result = ProductoValidations.ValidateProducto(model);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var producto = model.ConvertDtoAddToEntity();
                this.productoRepository.Add(producto);
                result.Message = "Producto agregado correctamente";
            }
            catch(Exception e)
            {
                result.Success = false;
                result.Message = "Error al agregar el producto";
                this.logger.LogError($"{result.Message}", e.ToString());
            }

            return result;
        }

        public ServiceResult Update(ProductoUpdateDto model)
        {
            ServiceResult result = ProductoValidations.ValidateProducto(model);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var producto = model.ConvertDtoUpdateToEntity();
                this.productoRepository.Update(producto);
                result.Message = "Producto actualizado correctamente";
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = "Error al actualizar el producto";
                this.logger.LogError($"{result.Message}", e.ToString());
            }

            
            return result;
        }
    }
}
