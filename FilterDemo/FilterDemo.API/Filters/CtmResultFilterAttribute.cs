using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.API.Filters;

public class CtmResultFilterAttribute : Attribute, IResultFilter
{
    // 围绕操作结果进行
    // 仅当操作(Actions)或者操作过滤器(ActionFilter) 产生结果时生效
    // 不会响应权限过滤器(AuthenticationFilter)和异常过滤器(ExceptionFilter)
    
    // IAlwaysRunResultFilter
    // IAsyncAlwaysResultFilter
    public void OnResultExecuting(ResultExecutingContext context)
    {
        // throw new NotImplementedException();
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        // throw new NotImplementedException();
    }
}