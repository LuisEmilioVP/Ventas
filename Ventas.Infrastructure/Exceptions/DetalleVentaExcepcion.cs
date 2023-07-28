using System;

namespace DetalleVentas.Infrastructure
{
    public class DetalleVentaExceptions : Exception
    {
        public DetalleVentaExceptions(string message) : base(message)
        {
        }
    }

    public class DbConnectionException : Exception
    {
        public DbConnectionException(string message) : base(message)
        {
        }
    }

    public class DetalleVentaNotFoundException : Exception
    {
        public DetalleVentaNotFoundException(string message) : base(message)
        {
        }
    }
}
