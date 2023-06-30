using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.API.Filters;

public class CtmActionFilterAttribute: Attribute, IActionFilter
{
    private readonly ILogger<CtmActionFilterAttribute> _logger;
    // Common uses:
    // 1. (Recommended) Logger
    // 2. (Recommended) Model validation
    //    Now APIController can do this for us automatically
    
    public CtmActionFilterAttribute(ILogger<CtmActionFilterAttribute> logger)
    {
        // import via constructor
        _logger = logger;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Step1: How to import Logger
        _logger.LogInformation("Test1");
        throw new NotImplementedException();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }
}