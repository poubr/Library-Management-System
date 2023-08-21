using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Service.src.Shared
{
    public class ExceptionHandler : Exception
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public ExceptionHandler(int statusCode = 500, string message = "Internal server error.")
        {
            StatusCode = statusCode;
            ErrorMessage = message;
        }

        public static ExceptionHandler NotFoundException(string message = "Item/s cannot be found.")
        {
            return new ExceptionHandler(404, message);
        }

        public static ExceptionHandler UnauthorizedException(string message = "Unauthorized access.")
        {
            return new ExceptionHandler(401, message);
        }

        public static ExceptionHandler CreateAdminException(string message = "Failed to create admin.")
        {
            return new ExceptionHandler(400, message);
        }

        public static ExceptionHandler UpdatePasswordException(string message = "Failed to update password.")
        {
            return new ExceptionHandler(400, message);
        }

        public static ExceptionHandler CreateException(string message = "Failed to create item.")
        {
            return new ExceptionHandler(400, message);
        }

        public static ExceptionHandler UpdateException(string message = "Failed to update item.")
        {
            return new ExceptionHandler(400, message);
        }
    }
}
