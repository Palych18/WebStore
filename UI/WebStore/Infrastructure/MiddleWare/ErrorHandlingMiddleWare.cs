using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Infrastructure.MiddleWare
{
    public class ErrorHandlingMiddleWare
    {
        private readonly RequestDelegate _Next;
        private readonly ILogger<ErrorHandlingMiddleWare> _Logger;

        public ErrorHandlingMiddleWare(RequestDelegate Next, ILogger<ErrorHandlingMiddleWare> Logger)
        {
            _Next = Next;
            _Logger = Logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _Next(context);
            }
            catch (Exception e)
            {
                HandleException(e, context);
                throw;
            }
        }

        private void HandleException(Exception error, HttpContext context)
        {
            _Logger.LogError(error, $"Ошибка при обработке запроса к {context.Request.Path}");
        }
    }
}
