using FilterDemo.API.Constants;
using FilterDemo.API.Extensions;
using FilterDemo.API.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.API.Filters;

public class CtmAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // two way to get parameters from query string
        var parameters = context.ActionDescriptor.Parameters;

        var queryString = context.HttpContext.Request.QueryString;
        // var param = queryString.Value.Replace("?", "");
        //
        // var paramArr = param.Split("&");
        // Dictionary<string, object> paramDict = new();
        // foreach (var item in paramArr)
        // {
        //     var res = item.Split("=");
        //     // paramDict[res[0]] = res[1];
        //     paramDict.Add(res[0].Trim(), res[1].Trim());
        // }

        var paramDict = context.HttpContext.Request.QueryString.Value.GetParamDict();

        // var userId = paramDict["UserId"].ToString();  // not good
        // var userId = paramDict[AuthConst.USERID].ToString();  // Better but not good enough
        var hasValue = paramDict.TryGetValue(AuthConst.USERID, out object value);
        if (hasValue)
        {
            int userId = Convert.ToInt32(value);
            var actions = Actions.GetActionByUserId(userId);

            string actionName = context.RouteData.Values["action"].ToString();
            string controllerName = context.RouteData.Values["controller"].ToString();
            if (!actions.Any(m => m.ActionName == actionName && m.ControllerName == controllerName))
            {
                throw new Exception("No Authorization");
            }
        }
        else
            throw new Exception("No Value");
    }
}