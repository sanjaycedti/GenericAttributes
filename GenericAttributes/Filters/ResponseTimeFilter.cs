using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace GenericAttributes.Filters
{
    public class ResponseTimeFilter : IAsyncActionFilter
    {
        private readonly ILogger<ResponseTimeFilter> _logger;

        public ResponseTimeFilter(ILogger<ResponseTimeFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var stopWatch = Stopwatch.StartNew();

            await next();

            stopWatch.Stop();

            _logger.LogInformation("Request took {0} ms to complete", stopWatch.ElapsedMilliseconds);
        }
    }
}
