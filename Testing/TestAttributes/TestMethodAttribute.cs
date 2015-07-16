using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodAttribute : Attribute
    {
        public static bool Exists(MethodInfo method)
        {
            foreach (var attr in method.GetCustomAttributes(false))
            {
                return attr is TestMethodAttribute;
            }
            return false;
        }
    }

}
