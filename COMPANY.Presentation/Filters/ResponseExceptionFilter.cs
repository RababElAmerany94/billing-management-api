namespace COMPANY.Presentation.Filters
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Tools;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// a class describe HTTP response exception
    /// </summary>
    public class ResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        private readonly ILogger _logger;

        public ResponseExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ExceptionFilter");
        }

        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                if (context.Exception is NotFoundException notFoundException)
                {
                    _logger.LogError(LogEvent.GetItemNotFound, notFoundException, notFoundException.Message);
                    var response = Result.Failed(notFoundException, notFoundException.Message, notFoundException.MessageCode.ToString());
                    context.Result = new NotFoundObjectResult(response);
                }
                else if (context.Exception is UnAuthorizedException authorizedException)
                {
                    _logger.LogError(LogEvent.UnAuthorizedException, authorizedException, authorizedException.Message);
                    context.Result = new UnauthorizedResult();
                }
                else if (context.Exception is JsonException jsonException)
                {
                    _logger.LogError(LogEvent.JsonException, jsonException, jsonException.Message);
                    context.Result = new StatusCodeResult(500);
                }
                else if (context.Exception is UnAcceptableRequestException unAcceptableRequest)
                {
                    var response = Result.Failed(unAcceptableRequest, unAcceptableRequest.Message, unAcceptableRequest.MessageCode.ToString());
                    _logger.LogError(LogEvent.JsonException, unAcceptableRequest, unAcceptableRequest.Message);
                    context.Result = new BadRequestObjectResult(response);
                }
                else
                {
                    var unhandledException = context.Exception;
                    _logger.LogError(LogEvent.UnHandledException, unhandledException, "Unhandled Exception throws because of {message}", unhandledException.Message);
                    context.Result = new StatusCodeResult(500);
                }
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        { }
    }
}
