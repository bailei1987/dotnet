using System;
using System.Collections.Generic;
using System.Reflection;

namespace BL.Common.Reflection
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class ParamDescription : Attribute
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsNullable { get; set; }
        public string TypeName { get; set; }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class ReturnFieldDescription : Attribute
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string TypeName { get; set; }
    }
}