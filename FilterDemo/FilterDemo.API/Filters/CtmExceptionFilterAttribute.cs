using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.API.Filters;

public class CtmExceptionFilterAttribute : Attribute, IExceptionFilter
{
    // 非常适合捕获发生在操作中的异常(ActionFilter, Action) 
    // 建议使用中间件处理异常
    private readonly ILogger<CtmExceptionFilterAttribute> _logger;

    public CtmExceptionFilterAttribute(ILogger<CtmExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception.Message);
        context.Result = new ContentResult
        {
            Content = context.Exception.Message
        };
    }
}