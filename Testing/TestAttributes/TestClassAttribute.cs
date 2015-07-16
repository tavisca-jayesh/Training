using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestClassAttribute : Attribute
    {
        public static bool Exists(Type type)
        {
            foreach (var attr in type.GetCustomAttributes(false))
            {
                return attr is TestClassAttribute;
            }
            return false;
        }
    }

}
