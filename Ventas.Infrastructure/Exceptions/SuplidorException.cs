using System;

namespace Ventas.Infrastructure.Exceptions
{
    public class SuplidorException : Exception
    {
        public SuplidorException(string message) : base(message)
        {

        }

        // Excepción Se produjo un error al establecer la conexión con la base de datos. 
        public class ConnectionException : Exception
        {
            public ConnectionException(string message) : base(message)
            {
            }

        }
    }
}
