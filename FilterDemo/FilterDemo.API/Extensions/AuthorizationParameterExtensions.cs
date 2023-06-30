using System;

namespace FilterDemo.API.Extensions;

public static class AuthorizationParameterExtensions
{
    public static Dictionary<string, object> GetParamDict(this string value)
    {
        var param = value.Replace("?", "");

        var paramArr = param.Split("&");
        Dictionary<string, object> paramDict = new();
        foreach (var item in paramArr)
        {
            var res = item.Split("=");
            // paramDict[res[0]] = res[1];
            paramDict.Add(res[0].Trim(), res[1].Trim());
        }

        return paramDict;
    }
}