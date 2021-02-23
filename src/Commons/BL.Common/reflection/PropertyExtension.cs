using System;
using System.Collections.Generic;

namespace BL.Common.Reflection
{
    public static class PropertyExtension
    {
        public static Dictionary<string, PropertyMarkAttribute> GetPropertyMarks(this Type type)
        {
            if (type.IsGenericType) type = type.GenericTypeArguments[0].UnderlyingSystemType;
            var props = type.GetProperties();
            Dictionary<string, PropertyMarkAttribute> dic = new();
            foreach (var item in props)
            {
                var v = (PropertyMarkAttribute[])item.GetCustomAttributes(typeof(PropertyMarkAttribute), false);
                if (v.Length > 0)
                {
                    dic.Add(item.Name, v[0]);
                }
            }
            return dic;
        }
    }

}
