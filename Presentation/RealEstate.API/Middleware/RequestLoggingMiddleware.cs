using log4net;
using System.Reflection;

namespace RealEstate.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        public RequestLoggingMiddleware(RequestDelegate next) { 
        
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.Info("Processing request...");
            await _next(context);
        }
    }
}
