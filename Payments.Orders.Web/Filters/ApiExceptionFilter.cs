using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Payments.Orders.Domain.Exceptions;
using Payments.Orders.Domain.Extensions;
using Payments.Orders.Web.Models;
using System.Text.Json;
//кастом статус коды 
namespace Payments.Orders.Web.Filters
{
    public class ApiExceptionFilter(ILogger<ApiExceptionFilter> logger) : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exeption = context.Exception;
            int statusCode = 400;
            ApiErrorRespone? respone;

            switch (true)
            {
                case { } when exeption is DuplicateEntityException:
                {
                        respone = new ApiErrorRespone
                        {
                            Message = exeption.Message,
                            Code = 21,
                            Description = exeption.ToText()
                        };
                   break;
                }
                case { } when exeption is EntityNotFoundException:
                {
                        statusCode = 404;
                        respone = new ApiErrorRespone
                        {
                            Message = exeption.Message,
                            Code = 22,
                            Description = exeption.ToText()
                        };
                   break;
                }
                case { } when exeption is SoftEntityNotFoundExeption:
                    {
                        statusCode = 400;
                        respone = new ApiErrorRespone
                        {
                            Message = exeption.Message,
                            Code = 23,
                            Description = exeption.ToText()
                        };
                        break;
                    }

                default: 
                {
                        respone = new ApiErrorRespone
                        { 
                            Code = 666,
                            Message = exeption.Message,
                            Description = exeption.ToText()
                        };
                  break;
                }
            }

            logger.LogError($"Api method {context.HttpContext.Request.Path} finished with code {statusCode} and error: " +
                $" {JsonSerializer.Serialize(respone)}");
            context.Result = new JsonResult(new { respone }) {StatusCode = statusCode };
        }
    }
}
