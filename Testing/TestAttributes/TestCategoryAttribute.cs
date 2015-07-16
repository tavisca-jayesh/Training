using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestCategoryAttribute : Attribute
    {
        public string Name { get; set; }

        public TestCategoryAttribute(string name)
        {
            Name = name;
        }

        public bool Exists(Type type)
        {
            foreach (var attr in type.GetCustomAttributes(false))
            {
                return attr is TestCategoryAttribute;
            }
            return false;
        }
    }
}
