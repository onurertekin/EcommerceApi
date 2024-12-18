﻿using DomainService.Exceptions;
using System.Net;

namespace Host.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            string message = "";
            bool hasError = false;//Hata var mı?

            try
            {
                await _next.Invoke(httpContext);//controller'a git veya başka middleware varsa ona git
            }
            catch (BusinessException bex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = bex.StatusCode;
                message = bex.ErrorMessage;
                hasError = true;
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                message = ex.Message;
                hasError = true;
            }

            if (hasError)
            {
                var errorResultModel = new ErrorResultModel()
                {
                    ErrorMessage = message
                };

                var responseJson = Newtonsoft.Json.JsonConvert.SerializeObject(errorResultModel);
                await httpContext.Response.WriteAsync(responseJson);
            }
        }
    }

    public class ErrorResultModel
    {
        public string ErrorMessage { get; set; }
    }


}
