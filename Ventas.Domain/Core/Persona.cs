using System;

namespace Ventas.Domain.Core
{
    public abstract class Persona : BaseEntity
    {
        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
    }
}
