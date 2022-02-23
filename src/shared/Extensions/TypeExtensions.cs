using System;
using System.Reflection;

namespace Keycloak.Net.Shared.Json
{
    public static class TypeExtensions
    {
        public static object? GetDefault(this Type type)
        {
            return type.GetTypeInfo().IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
