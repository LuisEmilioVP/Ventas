using System;

namespace Ventas.Infrastructure
{
    public class ProductoExceptions : Exception
    {
        public ProductoExceptions(string message) : base(message)
        {
        }
    }

    public class DbConnectionException : Exception
    {
        public DbConnectionException(string message) : base(message)
        {
        }
    }

    public class ProductoNotFoundException : Exception
    {
        public ProductoNotFoundException(string message) : base(message)
        {
        }
    }
}

