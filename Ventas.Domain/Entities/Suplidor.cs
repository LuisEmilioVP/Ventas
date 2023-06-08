﻿using System;
using System.Runtime.CompilerServices;
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Suplidor : SeconEntity
    {

        public int IdSuplidor { get; set; }
        public string Contacto { get; set; }
        public string Ciudad { get; set; }
        public string? Region { get; set; }
        public string? Codigo_postal { get; set; }
        public string Pais { get; set; }
        public string? Fax { get; set; }

    }
}
