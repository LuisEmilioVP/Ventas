using System;

namespace Ventas.Infrastructure.Exceptions
{
    /* Excepción de Usuario duplicado en la base de datos: */
    public class CategoriaExceptions : Exception
    {
        public CategoriaExceptions(string message) : base(message) 
        {
        }
    }

    /* Excepción de Usuario no encontrado en la base de datos */
    public class CategoriaNotFoundException : Exception
    {
        public CategoriaNotFoundException(string message) : base(message)
        {
        }
    }

    /* Excepción de Error de conexión a la base de datos */
    public class CDatabaseConnectionException : Exception
    {
        public CDatabaseConnectionException(string message) : base(message)
        {
        }
    }
}
