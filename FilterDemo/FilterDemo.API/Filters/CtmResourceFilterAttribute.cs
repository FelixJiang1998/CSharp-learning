using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.API.Filters;

public class CtmResourceFilterAttribute: Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        throw new NotImplementedException();
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        throw new NotImplementedException();
    }
}