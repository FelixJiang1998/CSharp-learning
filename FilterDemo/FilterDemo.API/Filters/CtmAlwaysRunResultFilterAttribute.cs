using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.API.Filters;

public class CtmAlwaysRunResultFilterAttribute : Attribute, IAlwaysRunResultFilter
{
    /**
     * an IResultFilter implementation that should run for all action results.
     */
    public void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is StatusCodeResult result
            && result.StatusCode == StatusCodes.Status404NotFound)
        {
            context.Result = new ObjectResult("404")
            {
                StatusCode = StatusCodes.Status404NotFound
            };
        }
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
    }
}