using System;

namespace Cerberus.Dashboard.Api.Authorize
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    {

    }
}
