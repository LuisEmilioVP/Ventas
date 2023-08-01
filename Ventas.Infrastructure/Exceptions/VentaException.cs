using System;

namespace Ventas.Infrastructure.Exceptions
{
    public class VentaException : Exception
    {
        public VentaException(string message) : base(message)
        {

        }

        // Excepción Se produjo un error al establecer la conexión con la base de datos. 
        public class ConnectionException : Exception
        {
            public ConnectionException(string message) : base(message)
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
}
