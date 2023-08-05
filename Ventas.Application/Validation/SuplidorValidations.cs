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
        public static ServiceResult ValidateIdSuplidor(int idSupli)
        {
            ServiceResult result = new ServiceResult();

            if (idSupli <= 0)
            {
                result.Message = $"ID INVALIDO {idSupli}";
                result.Success = false;
                return result;
            }

            if (idSupli == null)
            {
                result.Message = $"El suplidor no puede ser nulo";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidateSuplidorAdd(SuplidorAddDto suplidorAdd)
        {
            ServiceResult result = new ServiceResult();

            if (suplidorAdd.ChangeUser != suplidorAdd.ChangeUser)
            {
                result.Message = "ID no encontrado, especifique quién creara el nuevo suplidor";
                result.Success = false;
                return result;
            }

            if (suplidorAdd.ChangeUser <= 0)
            {
                result.Message = "ID INVALIDO";
                result.Success = false;
                return result;
            }

            //Nombre
            if (suplidorAdd.Nombre.Length > 40)
            {
                result.Message = "Has excedido el maximo de caractres en el nombre";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorAdd.Nombre))
            {
                result.Message = "Se requiere un nombre";
                result.Success = false;
                return result;
            }

            // Contacto
            if (suplidorAdd.Contacto.Length > 30)
            {
                result.Message = "Has excedido el maximo de caractres en el contacto";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorAdd.Contacto))
            {
                result.Message = "Se requiere un contacto";
                result.Success = false;
                return result;
            }

            // Direccion
            if (suplidorAdd.Direccion.Length > 60)
            {
                result.Message = "Has excedido el maximo de caractres en la direccion";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorAdd.Direccion))
            {
                result.Message = "Se requiere una direccion";
                result.Success = false;
                return result;
            }


            // Ciudad
            if (suplidorAdd.Ciudad.Length > 60)
            {
                result.Message = "Has excedido el maximo de caractres en la ciudad";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorAdd.Ciudad))
            {
                result.Message = "Se requiere una Ciudad";
                result.Success = false;
                return result;
            }

            //Region
            if (suplidorAdd.Region.Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en la region";
                result.Success = false;
                return result;
            }

            //Codigo_postal
            if (suplidorAdd.Codigo_postal.Length > 10)
            {
                result.Message = "Has excedido el maximo de caractres en el Codigo_postal";
                result.Success = false;
                return result;
            }

            //Pais
            if (suplidorAdd.Pais.Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en el Pais";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorAdd.Pais))
            {
                result.Message = "Se requiere un Pais";
                result.Success = false;
                return result;
            }

            //Telefono
            if (suplidorAdd.Telefono.Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en el numero de telefono";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorAdd.Telefono))
            {
                result.Message = "Se requiere un numero de telefono";
                result.Success = false;
                return result;
            }


            // Fax
            if (suplidorAdd.Fax.Length > 24)
            {
                result.Message = "Has excedido el maximo de caractres en el Fax";
                result.Success = false;
                return result;
            }

            return result;

        }

        public static ServiceResult ValidateSuplidorUpdate(SuplidorUpdateDto suplidorUpdate)
        {
            ServiceResult result = new ServiceResult();

            if (suplidorUpdate.IdSuplidor != suplidorUpdate.IdSuplidor)
            {
                result.Message = "ID no encontrado, especifique el suplidor a modificar";
                result.Success = false;
                return result;
            }

            if (suplidorUpdate.IdSuplidor <= 0)
            {
                result.Message = "ID INVALIDO";
                result.Success = false;
                return result;
            }

            if (suplidorUpdate.ChangeUser == null)
            {
                result.Message = "ID no encotrado, por favor especifique quien actualizara";
                result.Success = false;
                return result;
            }

            if (suplidorUpdate.ChangeUser <= 0)
            {
                result.Message = "ID INVALIDO";
                result.Success = false;
                return result;
            }

            //Nombre
            if (suplidorUpdate.Nombre.Length > 40)
            {
                result.Message = "Has excedido el maximo de caractres en el nombre";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorUpdate.Nombre))
            {
                result.Message = "Se requiere un nombre";
                result.Success = false;
                return result;
            }

            // Contacto
            if (suplidorUpdate.Contacto.Length > 30)
            {
                result.Message = "Has excedido el maximo de caractres en el contacto";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorUpdate.Contacto))
            {
                result.Message = "Se requiere un contacto";
                result.Success = false;
                return result;
            }

            // Direccion
            if (suplidorUpdate.Direccion.Length > 60)
            {
                result.Message = "Has excedido el maximo de caractres en la direccion";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorUpdate.Direccion))
            {
                result.Message = "Se requiere una direccion";
                result.Success = false;
                return result;
            }


            // Ciudad
            if (suplidorUpdate.Ciudad.Length > 60)
            {
                result.Message = "Has excedido el maximo de caractres en la ciudad";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorUpdate.Ciudad))
            {
                result.Message = "Se requiere una Ciudad";
                result.Success = false;
                return result;
            }

            //Region
            if (suplidorUpdate.Region.Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en la region";
                result.Success = false;
                return result;
            }

            //Codigo_postal
            if (suplidorUpdate.Codigo_postal.Length > 10)
            {
                result.Message = "Has excedido el maximo de caractres en el Codigo_postal";
                result.Success = false;
                return result;
            }

            //Pais
            if (suplidorUpdate.Pais.Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en el Pais";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorUpdate.Pais))
            {
                result.Message = "Se requiere un Pais";
                result.Success = false;
                return result;
            }

            //Telefono
            if (suplidorUpdate.Telefono.Length > 15)
            {
                result.Message = "Has excedido el maximo de caractres en el numero de telefono";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(suplidorUpdate.Telefono))
            {
                result.Message = "Se requiere un numero de telefono";
                result.Success = false;
                return result;
            }


            // Fax
            if (suplidorUpdate.Fax.Length > 24)
            {
                result.Message = "Has excedido el maximo de caractres en el Fax";
                result.Success = false;
                return result;
            }

            return result;

        }

        public static ServiceResult ValidateSuplidorRemove(SuplidorRemoveDto suplidorRemove)
        {
            ServiceResult result = new ServiceResult();

            if (suplidorRemove.IdSuplidor != suplidorRemove.IdSuplidor)
            {
                result.Message = "ID no encontrado, por favor especifique el Suplidor a eliminar";
                result.Success = false;
                return result;
            }

            if (suplidorRemove.IdSuplidor <= 0)
            {
                result.Message = "ID INVALIDO";
                result.Success = false;
                return result;
            }

            if (suplidorRemove.ChangeUser == null)
            {
                result.Message = "ID no encontrado, especifique quien eliminara";
                result.Success = false;
                return result;
            }

            if (suplidorRemove.ChangeUser <= 0)
            {
                result.Message = "ID INVALIDO";
                result.Success = false;
                return result;
            }

            return result;
        }
    }
}

