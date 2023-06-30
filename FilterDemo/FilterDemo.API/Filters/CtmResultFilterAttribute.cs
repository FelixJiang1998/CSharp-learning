using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.API.Filters;

public class CtmResultFilterAttribute : Attribute, IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        throw new NotImplementedException();
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        throw new NotImplementedException();
    }
}