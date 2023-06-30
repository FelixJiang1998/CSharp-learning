using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.API.Filters;

public class CtmResourceFilterAttribute : Attribute, IResourceFilter
{
    // Suitable for cache handling
    // 短路器(shortCircuit)
    // if `result`(context.result) is not null, it means that the short-cut is triggered.
    // the model binding would not be executed
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        // get the path of current request
        var path = context.HttpContext.Request.Path;
        // check if the path is in the `_dicCache`
        if (_dicCache.ContainsKey(path))
        {
            // if the path is in the `_dicCache`, then return the result directly
            context.Result = _dicCache[path] as ObjectResult;
        }
    }

    private static Dictionary<string, object> _dicCache = new();

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // how to judge the current visit has appeared before.
        var path = context.HttpContext.Request.Path;
        // store the result into the dict
        _dicCache[path] = context.Result as ObjectResult;
    }
}