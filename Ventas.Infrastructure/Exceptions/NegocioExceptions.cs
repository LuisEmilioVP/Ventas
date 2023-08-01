using System;

namespace Ventas.Infrastructure.Exceptions
{
    /* Excepción de Negocio duplicado en la base de datos: */
    public class NegocioExceptions : Exception
    {
        public NegocioExceptions(string message) : base(message)
        {
        }
    }

    /* Excepción de Negocio no encontrado en la base de datos */
    public class NegocioNotFoundException : Exception
    {
        public NegocioNotFoundException(string message) : base(message)
        {
        }
    }

    /* Excepción de Error de conexión a la base de datos */
    public class NDatabaseConnectionException : Exception
    {
        public NDatabaseConnectionException(string message) : base(message)
        {
        }
    }
}