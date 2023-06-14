using System;

namespace Ventas.Infrastructure.Exceptions
{
    /* Excepción de Usuarios */
    public class UsuarioExceptions : Exception
    {
        public UsuarioExceptions(string message) : base(message) 
        {
        }
    }

    /* Excepción de Usuario no encontrado en la base de datos */
    public class UsuarioNotFoundException : Exception
    {
        public UsuarioNotFoundException(string message) : base(message)
        {
        }
    }

    /* Excepción de Error de conexión a la base de datos */
    public class UDatabaseConnectionException : Exception
    {
        public UDatabaseConnectionException(string message) : base(message)
        {
        }
    }
}
