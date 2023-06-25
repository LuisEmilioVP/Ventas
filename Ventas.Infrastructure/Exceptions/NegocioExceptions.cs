using System;

namespace Ventas.Infrastructure.Exceptions
{
    /* Excepción de Categoria duplicado en la base de datos: */
    public class NegocioExceptions : Exception
    {
        public NegocioExceptions(string message) : base(message)
        {
        }
    }

    /* Excepción de Categoria no encontrado en la base de datos */
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