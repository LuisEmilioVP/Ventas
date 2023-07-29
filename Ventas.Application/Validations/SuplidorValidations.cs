using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Ventas.Application.Core;
using Ventas.Application.Dto.Suplidor;

namespace Ventas.Application.Validations
{
    public static class SuplidorValidations
    {
        public static ServiceResult ValidateSuplidor(SuplidorDto model)
        {
            ServiceResult result = new ServiceResult();

            //Nombre
            if (model.Nombre.Length > 40)
            {
                result.Message = "Has excedido el maximo de caractres en el nombre";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.Nombre))
            {
                result.Message = "Se requiere un nombre";
                result.Success = false;
                return result;
            }

            // Contacto
            if (model.Contacto.Length > 30)
            {
                result.Message = "Has excedido el maximo de caractres en el contacto";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.Contacto))
            {
                result.Message = "Se requiere un contacto";
                result.Success = false;
                return result;
            }

            // Direccion
            if (model.Direccion.Length > 60)
            {
                result.Message = "Has excedido el maximo de caractres en la direccion";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.Direccion))
            {
                result.Message = "Se requiere una direccion";
                result.Success = false;
                return result;
            }


            // Ciudad
            if (model.Ciudad.Length > 60)
            {
                result.Message = "Has excedido el maximo de caractres en la ciudad";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.Ciudad))
            {
                result.Message = "Se requiere una Ciudad";
                result.Success = false;
                return result;
            }

            //Region
            if (model.Region.Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en la region";
                result.Success = false;
                return result;
            }

            //Codigo_postal
            if (model.Codigo_postal.Length > 10)
            {
                result.Message = "Has excedido el maximo de caractres en el Codigo_postal";
                result.Success = false;
                return result;
            }

            //Pais
            if (model.Pais.Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en el Pais";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.Pais))
            {
                result.Message = "Se requiere un Pais";
                result.Success = false;
                return result;
            }

            //Telefono
            if (model.Telefono.Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en el numero de telefono";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.Telefono))
            {
                result.Message = "Se requiere un numero de telefono";
                result.Success = false;
                return result;
            }


            // Fax
            if (model.Fax.Length > 24)
            {
                result.Message = "Has excedido el maximo de caractres en el Fax";
                result.Success = false;
                return result;
            }

            return result;

        }
    }
}

