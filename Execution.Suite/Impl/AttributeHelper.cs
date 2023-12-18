using System.Reflection;

namespace Execution.Suite.Impl;

internal static class AttributeHelper
{
    public static bool TryGetMethodAttributeValue<TAttribute, TValue>(MethodBase methodBase, Func<TAttribute, TValue> valueSelector, out TValue? value)
        where TAttribute : Attribute
    {
        var attr = methodBase?.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
        if (attr != null)
        {
            value = valueSelector(attr);
            return true;
        }

        value = default(TValue);
        return false;
    }

    public static bool TryGetTypeAttributeValue<TAttribute, TValue>(Type type, Func<TAttribute, TValue> valueSelector, out TValue? value)
        where TAttribute : Attribute
    {
        var attr = type?.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
        if (attr != null)
        {
            value = valueSelector(attr);
            return true;
        }

        value = default(TValue);
        return false;
    }

    public static bool IsMethodContainsAttribute<TAttribute>(MethodBase methodBase)
        where TAttribute : Attribute
    {
        var attr = methodBase?.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
        return attr != null;
    }
}
