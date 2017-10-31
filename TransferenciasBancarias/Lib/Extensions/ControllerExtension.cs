using Microsoft.AspNet.Mvc;
using System.Net;
using TransferenciasBancarias.Lib.Exceptions;

namespace TransferenciasBancarias.Lib.Extensions
{
    public static class ControllerExtension
    {
        public static IActionResult HttpInternalServerError(this Controller controller, ServerException exception)
        {
            var result =  controller.Json(exception.Message);

            result.StatusCode = (int)HttpStatusCode.InternalServerError;

            return result;
        }
    }
}
