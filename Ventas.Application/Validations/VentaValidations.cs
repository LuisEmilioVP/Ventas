using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Ventas.Application.Core;
using Ventas.Application.Dto.Venta;

namespace Ventas.Application.Validations
{
    public static class VentaValidations
    {
        public static ServiceResult ValidateVenta(VentaDto model)
        {
            ServiceResult result = new ServiceResult();

            //Nombre
            if (model.NumeroVenta.Length > 40)
            {
                result.Message = "Has excedido el maximo de caractres en el nombre";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.NumeroVenta))
            {
                result.Message = "Se requiere un nombre";
                result.Success = false;
                return result;
            }

            // Contacto
            if (model.IdTipoDocumentoVenta.ToString().Length > 30)
            {
                result.Message = "Has excedido el maximo de caractres en el contacto";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.IdTipoDocumentoVenta.ToString()))
            {
                result.Message = "Se requiere un contacto";
                result.Success = false;
                return result;
            }

            // Direccion
            if (model.FechaRegistro.ToString().Length > 60)
            {
                result.Message = "Has excedido el maximo de caractres en la direccion";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.FechaRegistro.ToString()))
            {
                result.Message = "Se requiere una direccion";
                result.Success = false;
                return result;
            }


            // Ciudad
            if (model.DocumentoCliente.Length > 60)
            {
                result.Message = "Has excedido el maximo de caractres en la ciudad";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.DocumentoCliente))
            {
                result.Message = "Se requiere una Ciudad";
                result.Success = false;
                return result;
            }

            //Region
            if (model.NombreCliente.Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en la region";
                result.Success = false;
                return result;
            }

            //Codigo_postal
            if (model.NombreCliente.Length > 10)
            {
                result.Message = "Has excedido el maximo de caractres en el Codigo_postal";
                result.Success = false;
                return result;
            }

            //Pais
            if (model.SubTotal.ToString().Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en el Pais";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.SubTotal.ToString()))
            {
                result.Message = "Se requiere un Pais";
                result.Success = false;
                return result;
            }

            //Telefono
            if (model.ImpuestoTotal.ToString().Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en el numero de telefono";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.ImpuestoTotal.ToString()))
            {
                result.Message = "Se requiere un numero de telefono";
                result.Success = false;
                return result;
            }


            // Fax
            if (model.Total.ToString().Length > 240)
            {
                result.Message = "Total";
                result.Success = false;
                return result;
            }

            return result;

        }
    }
}

