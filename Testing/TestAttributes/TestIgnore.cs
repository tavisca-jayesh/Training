
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestIgnore : Attribute
    {
        public TestIgnore()
        {

        }
    }
}
