using System;

namespace Valit.AspNetCore.Extensions
{
    internal static class ReflectionExtensions
    {
        public static object InvokeGenericMethod(this Type target, string methodName, Type genericType, object @object, params object[] parameters)
            =>  target.GetMethod(methodName)
                .MakeGenericMethod(genericType)
                .Invoke(@object, parameters);
    }
}