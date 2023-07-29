﻿
using System.ComponentModel.DataAnnotations;
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Suplidor : BaseEntity
    {

        [Key] public int IdSuplidor { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string? Region { get; set; }
        public string? Codigo_postal { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string? Fax { get; set; }


    }
}