using System;

namespace BL.Common.Scalar
{
    public static class ToStringHelper
    {
        public static string ToString(object value, Type type = null)
        {
            if (value is null) return null;
            if (type is null) type = value.GetType();
            if (type.IsGenericType) type = type.GenericTypeArguments[0].UnderlyingSystemType;
            return type.Name switch
            {
                "DateTime" => ((DateTime)value).ToString("yyyy-MM-dd"),
                _ => value.ToString(),
            };
        }
    }
}
