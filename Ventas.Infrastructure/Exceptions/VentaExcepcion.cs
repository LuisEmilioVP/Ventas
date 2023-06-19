using System;

namespace Ventas.Infrastructure
{
    public class VentaExceptions : Exception
    {
        public VentaExceptions(string message) : base(message)
        {
        }
    }

    public class DbConnectionException : Exception
    {
        public DbConnectionException(string message) : base(message)
        {
        }
    }

    public class VentaNotFoundException : Exception
    {
        public VentaNotFoundException(string message) : base(message)
        {
        }
    }
}
