using FilterDemo.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.API.Filters;

public class CtmActionFilterAttribute : Attribute, IActionFilter
{
    private readonly ILogger<CtmActionFilterAttribute> _logger;

    private readonly User _user;
    // Common uses:
    // 1. (Recommended) Logger
    // 2. (Recommended) Model validation
    //    Now APIController can do this for us automatically

    public CtmActionFilterAttribute(ILogger<CtmActionFilterAttribute> logger, User user)
    {
        // import via constructor
        _logger = logger;
        _user = user;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // How to import Logger
        // _logger.LogInformation("Test1");

        // var u = _user;
        // cannot activate User unless User is registered if using ServiceFilter

        var path = context.HttpContext.Request.Path;
        var arguments = context.ActionArguments; // new way to get parameter

        // // After .Net3.1, using ApiController will do this for us.
        // if (context.ModelState.IsValid)
        // {
        //     context.Result = new BadRequestObjectResult(context.ModelState);
        // }
        if (arguments.ContainsKey("user"))
        {
            var user = arguments["user"] as User;
            _logger.LogInformation("{} is visiting {} at {}", user.Username, path, DateTime.Now);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }
}